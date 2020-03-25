using FacelessTools.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FacelessTools.Localization.Forms
{
    public partial class LocalizationFileEditorForm : DarkUI.Forms.DarkForm
    {
        private int _languageIndex = -1;
        private Dictionary<string, List<DataGridViewRow>> keyEntries;

        public LocalizationFileEditorForm()
        {
            InitializeComponent();
            keyEntries = new Dictionary<string, List<DataGridViewRow>>();
            UpdateLanguageList();
            cbLanguage.SelectedIndex = 0;
            sslStatus.Text = "";
        }

        private void UpdateLanguageList()
        {
            foreach (var FileEntry in FLocalizationTool.LocalizationFiles)
            {
                cbLanguage.Items.Add(FileEntry.Language);
            }
        }

        private void AddGridRows(List<FLocalizationFileEntry> fileEntries)
        {
            foreach (var stringEntry in fileEntries)
            {
                if (keyEntries.ContainsKey(stringEntry.Key))
                {
                    MessageBox.Show("Key \"" + stringEntry.Key +
                        "\" duplicated! Keeping the first entry value", "Duplicated Keys!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string tempStr = stringEntry.Value.Replace("\t", "\\t");
                    tempStr = tempStr.Replace("\n", "\\n");
                    tempStr = tempStr.Replace("\r", string.Empty);

                    int lastRowIndex = dgContent.Rows.Add(stringEntry.Key, tempStr); ;

                    var rowList = new List<DataGridViewRow>()
                    {
                        dgContent.Rows[lastRowIndex]
                    };

                    keyEntries.Add(stringEntry.Key, rowList);
                }

            }
        }

        private void ClearGridRows()
        {
            dgContent.Rows.Clear();
            keyEntries.Clear();
        }

        private void UpdateGridRows(FLocalizationEntry Entry)
        {
            ClearGridRows();
            AddGridRows(Entry.FileContents.Entries);
        }

        private void LocalizationFileEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _ = SaveCurrentGridView(_languageIndex);
            _languageIndex = cbLanguage.SelectedIndex;
            List<FLocalizationEntry> Entries = FLocalizationTool.LocalizationFiles;
            UpdateGridRows(Entries[cbLanguage.SelectedIndex]);
        }

        private void dgContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                
            }
        }

        private bool ValidateRow(DataGridViewRow row, Dictionary<string, List<DataGridViewRow>> checkUp = null)
        {
            bool keyValidation = ValidateCell(row, true, false);
            
            if (keyValidation && checkUp != null && checkUp.ContainsKey(row.Cells[0].Value.ToString()))
            {
                ShowKeyDuplicatedWarning(row.Cells[0], false);
            }

            bool valueValidation = ValidateCell(row, false, false);
            return keyValidation && valueValidation;
        }

        private bool ValidateCell(DataGridViewRow row, bool isKey, bool silent = true)
        {
            DataGridViewCell cell = row.Cells[isKey ? 0 : 1];
            string context = isKey ? "Key" : "Value";
            string warning;

            if (cell.Value == null)
            {
                warning = context + " missing in row " + row.Index + " !";

                if (silent)
                {
                    ShowStatus(warning, EStatusType.Warning);
                }
                else
                {
                    MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SetCellStyle(cell, ECellStyle.Missing);
                return false;
            }
            else if (cell.Value.ToString().Trim().Length <= 0)
            {
                warning = "Invalid " + context + " in row " + row.Index + " !";

                if (silent)
                {
                    ShowStatus(warning, EStatusType.Warning);
                }
                else
                {
                    MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SetCellStyle(cell, ECellStyle.Missing);
                return false;
            }

            return true;
        }

        private FLocalizationFile SaveCurrentGridView(int index)
        {
            if (index < 0 || index >= cbLanguage.Items.Count)
            {
                return null;
            }

            dgContent.EndEdit();

            FLocalizationFile locFile = new FLocalizationFile
            {
                FileVersion = 1,
                Entries = new List<FLocalizationFileEntry>()
            };

            var localDictionary = new Dictionary<string, List<DataGridViewRow>>();

            foreach (DataGridViewRow row in dgContent.Rows)
            {
                if (row.Index == dgContent.Rows.GetLastRow(DataGridViewElementStates.Visible))
                {
                    break;
                }

                if (ValidateRow(row, localDictionary))
                {
                    string key = row.Cells[0].Value.ToString();

                    if (localDictionary.ContainsKey(key) == false)
                    {
                        localDictionary.Add(key, new List<DataGridViewRow>());
                    }

                    if (localDictionary[key].Count <= 1)
                    {
                        localDictionary[key].Add(row);

                        locFile.Entries.Add(new FLocalizationFileEntry
                        {
                            Key = row.Cells[0].Value.ToString(),
                            Value = row.Cells[1].Value.ToString().Replace("\\n", "\n")
                        });
                    }
                    
                }
            }

            FLocalizationTool.LocalizationFiles[index].FileContents = locFile;

            return locFile;
        }

        private void SerializeCurrentGridView()
        {
            string directoryPath = FLocalizationTool.FilesPath;

            if (directoryPath == null)
            {
                MessageBox.Show("Invalid directory path, can't save file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int index = cbLanguage.SelectedIndex;

            var locFile = SaveCurrentGridView(index);

            string jsonString = JsonConvert.SerializeObject(locFile, Formatting.Indented);

            string filePath = Path.Combine(directoryPath, cbLanguage.Text + ".json");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(jsonString);
                    writer.Close();
                }

                ShowStatus("Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SerializeCurrentGridView();
        }

        enum EStatusType
        {
            Normal,
            Warning,
            Error
        }

        private void ShowStatus(string text, EStatusType type = EStatusType.Normal)
        {
            System.Drawing.Color color = System.Drawing.Color.Empty;

            switch (type)
            {
                case EStatusType.Normal:
                    color = System.Drawing.Color.White;
                    break;
                case EStatusType.Warning:
                    color = System.Drawing.Color.Yellow;
                    break;
                case EStatusType.Error:
                    color = System.Drawing.Color.OrangeRed;
                    break;
                default:
                    color = System.Drawing.Color.Empty;
                    break;
            }

            sslStatus.Text = text;
            sslStatus.ForeColor = color;
            timerClearState.Start();
        }

        private void timerClearState_Tick(object sender, EventArgs e)
        {
            sslStatus.Text = string.Empty;
            timerClearState.Stop();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FLocalizationTool.UpdateSaveDirectory())
            {
                SerializeCurrentGridView();
            }
        }

        private void goToRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileNameDialog = new LocalizationTextBox("Enter Row Number...");
            var dialogResult = fileNameDialog.ShowDialog();
            int rowNumber;

            if (dialogResult == DialogResult.OK && Int32.TryParse(fileNameDialog.TextResult, out rowNumber))
            {
                if (rowNumber <= dgContent.Rows.Count)
                {
                    dgContent.Rows[rowNumber].Cells[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Invalid row number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        enum ECellStyle
        {
            Normal,
            Invalid,
            Missing
        }

        private void SetCellStyle(DataGridViewCell cell, ECellStyle cellStyle)
        {
            switch (cellStyle)
            {
                case ECellStyle.Normal:
                    cell.Style.ForeColor = System.Drawing.Color.Empty;
                    cell.Style.BackColor = System.Drawing.Color.Empty;
                    break;
                case ECellStyle.Invalid:
                    cell.Style.ForeColor = System.Drawing.Color.OrangeRed;
                    cell.Style.BackColor = System.Drawing.Color.Empty;
                    break;
                case ECellStyle.Missing:
                    cell.Style.ForeColor = System.Drawing.Color.Empty;
                    cell.Style.BackColor = System.Drawing.Color.Red;
                    break;
            }
        }

        private void ShowKeyDuplicatedWarning(DataGridViewCell cell, bool silent = true)
        {
            string warning = "Key " + cell.Value.ToString() + " already exists!";

            if (silent)
            {
                ShowStatus(warning, EStatusType.Warning);
            }
            else
            {
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SetCellStyle(cell, ECellStyle.Invalid);
        }

        private string KeyAtBeginEdit = string.Empty;

        private void dgContent_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SetCellStyle(dgContent.CurrentCell, ECellStyle.Normal);

            if (e.ColumnIndex == 0 && dgContent.CurrentCell.Value != null)
            {
                string key = KeyAtBeginEdit = dgContent.CurrentCell.Value.ToString();

                if (keyEntries.ContainsKey(key))
                {
                    keyEntries[key].Remove(dgContent.CurrentRow);
                }

            }
        }

        private void dgContent_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgContent.Rows.Count - 1)
            {
                return;
            }

            if (dgContent.CurrentCell.ColumnIndex == 0)
            {
                if (keyEntries.ContainsKey(KeyAtBeginEdit) && keyEntries[KeyAtBeginEdit] != null)
                {
                    bool invalidKey = keyEntries[KeyAtBeginEdit].Count > 1;

                    foreach (DataGridViewRow row in keyEntries[KeyAtBeginEdit])
                    {
                        SetCellStyle(row.Cells[0], invalidKey ? ECellStyle.Invalid : ECellStyle.Normal);
                    }
                }

                if (ValidateCell(dgContent.CurrentRow, true))
                {
                    if (dgContent.CurrentCell.Value != null)
                    {
                        string key = dgContent.CurrentCell.Value.ToString();

                        if (keyEntries.ContainsKey(key))
                        {
                            keyEntries[key].Add(dgContent.CurrentRow);
                        }
                        else
                        {
                            keyEntries.Add(key, new List<DataGridViewRow>()
                        {
                            dgContent.CurrentRow
                        });
                        }

                        bool duplicatedKeys = keyEntries[key].Count > 1;

                        if (duplicatedKeys)
                        {
                            ShowKeyDuplicatedWarning(dgContent.CurrentCell);
                        }

                        foreach (DataGridViewRow row in keyEntries[key])
                        {
                            SetCellStyle(row.Cells[0], duplicatedKeys ? ECellStyle.Invalid : ECellStyle.Normal);
                        }

                    }
                }

            }
            else if (dgContent.CurrentCell.ColumnIndex == 1 && ValidateCell(dgContent.CurrentRow, false))
            {

            }
        }

        private void importNarrationLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = FacelessTools.Utils.StaticFunctions.GetNarrationFiles();

            if (result != null)
            {
                List<FLocalizationFileEntry> fileEntries = new List<FLocalizationFileEntry>();

                foreach (var narrationLine in result.narrationLines)
                {
                    var vs = narrationLine.FMODEvent.Split('.');
                    string keyBase = "LOC_NL_" + vs[vs.Length - 1].ToUpper().Replace("'", "");
                    int entryIndex = 0;

                    foreach (var narrationLinePart in narrationLine.Texts)
                    {
                        var fileEntry = new FLocalizationFileEntry()
                        {
                            Key = keyBase + "_" + entryIndex.ToString(),
                            Value = narrationLinePart.Text
                        };

                        fileEntries.Add(fileEntry);

                        narrationLinePart.Text = fileEntry.Key;

                        entryIndex++;
                    }
                }

                AddGridRows(fileEntries);

                try
                {
                    var jsonStreamWriter = new StreamWriter(result.filePath);

                    using (jsonStreamWriter)
                    {
                        jsonStreamWriter.WriteLine(JsonConvert.SerializeObject(result.narrationLines, Formatting.Indented));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void importTextNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = FacelessTools.Utils.StaticFunctions.GetTextNotes();

            if (result != null)
            {
                List<FLocalizationFileEntry> fileEntries = new List<FLocalizationFileEntry>();

                foreach (var textNote in result.TextNotes)
                {
                    var fileEntry = new FLocalizationFileEntry
                    {
                        Key = "LOC_" + textNote.Name,
                        Value = textNote.Text
                    };

                    textNote.Text = fileEntry.Key;

                    fileEntries.Add(fileEntry);
                }

                AddGridRows(fileEntries);

                try
                {
                    var jsonStreamWriter = new StreamWriter(result.filePath);

                    using (jsonStreamWriter)
                    {
                        jsonStreamWriter.WriteLine(JsonConvert.SerializeObject(result.TextNotes, Formatting.Indented));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
