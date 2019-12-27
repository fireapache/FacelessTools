using FacelessUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FacelessLocalizationTool.Forms
{
    public partial class LocalizationFileEditorForm : DarkUI.Forms.DarkForm
    {
        private int _languageIndex = -1;

        public LocalizationFileEditorForm()
        {
            InitializeComponent();
            UpdateLanguageList();
            cbLanguage.SelectedIndex = 0;
            sslState.Text = "";
        }

        private void UpdateLanguageList()
        {
            foreach (var FileEntry in FLocalizationTool.LocalizationFiles)
            {
                cbLanguage.Items.Add(FileEntry.Language);
            }
        }

        private void UpdateGridRows(FLocalizationEntry Entry)
        {
            string tempStr;

            dgContent.Rows.Clear();

            var color = System.Drawing.Color.AliceBlue;

            foreach (var StringEntry in Entry.FileContents.Entries)
            {
                tempStr = StringEntry.Value.Replace("\t", "\\t");
                tempStr = tempStr.Replace("\n", "\\n");
                tempStr = tempStr.Replace("\r", string.Empty);
                _ = dgContent.Rows.Add(StringEntry.Key, tempStr);
            }

            //foreach (DataGridViewRow row in dgContent.Rows)
            //{
            //    row.Cells[0].Style.BackColor = color;
            //}
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

        private FLocalizationFile SaveCurrentGridView(int index)
        {
            if (index < 0 || index >= cbLanguage.Items.Count)
            {
                return null;
            }

            FLocalizationFile locFile = new FLocalizationFile
            {
                FileVersion = 1,
                Entries = new List<FLocalizationFileEntry>()
            };

            foreach (DataGridViewRow row in dgContent.Rows)
            {
                if (row.Index != dgContent.Rows.GetLastRow(DataGridViewElementStates.Visible))
                {
                    locFile.Entries.Add(new FLocalizationFileEntry
                    {
                        Key = row.Cells[0].Value.ToString(),
                        Value = row.Cells[1].Value.ToString().Replace("\\n", "\n")
                    });
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
            
            dgContent.EndEdit();

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

                ShowStateText("Saved!");
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

        private void ShowStateText(string text)
        {
            sslState.Text = text;
            timerClearState.Start();
        }

        private void timerClearState_Tick(object sender, EventArgs e)
        {
            sslState.Text = string.Empty;
            timerClearState.Stop();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FLocalizationTool.UpdateSaveDirectory())
            {
                SerializeCurrentGridView();
            }
        }

    }
}
