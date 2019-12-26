using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacelessUtils;
using System.IO;
using Newtonsoft.Json;

namespace FacelessNarrationTool.Forms
{
    public partial class NarrationFileEditorForm : Form
    {
        public NarrationFileEditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;

            if (narrationTable == null)
            {
                MessageBox.Show("Error: No input data!");
                Application.Exit();
            }

            tbFMODPath.Text = narrationTable.FMODFolderPath;

            UpdateDataGrid();
            
        }

        private void EditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDataGrid()
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;

            if (narrationTable != null)
            {
                dgNarrationFiles.Rows.Clear();

                foreach (FNarrationEvent file in narrationTable.Files)
                {
                    dgNarrationFiles.Rows.Add(file.FileName, file.Lines.Count);
                }

            }
            else
            {
                MessageBox.Show("Error: Can not update Data Grid due to the lack of input data!");
            }

        }

        private void AddNarrationFile()
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;
            int rowIndex;

            if (narrationTable != null)
            {
                if (dgNarrationFiles.CurrentRow == null)
                {
                    rowIndex = -1;
                }
                else
                {
                    rowIndex = dgNarrationFiles.CurrentRow.Index;
                }
                
                narrationTable.Files.Insert(rowIndex + 1, new FNarrationEvent() { FileName = "INSERT_NAME" });
            }

            UpdateDataGrid();
        }

        private void UpdateFMODPath(string newPath)
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;

            if (narrationTable != null)
            {
                narrationTable.FMODFolderPath = newPath;
            }
        }

        private void RemoveNarrationFile()
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;

            if (narrationTable != null && dgNarrationFiles.CurrentRow != null)
            {
                int rowIndex = dgNarrationFiles.CurrentRow.Index;
                narrationTable.Files.RemoveAt(rowIndex);
            }

            UpdateDataGrid();
        }

        private void SaveJsonFile()
        {
            if (FNarrationTool.JsonFilePath != null)
            {
                FNarrationTable narrationTable = FNarrationTool.NarrationTable;
                string FMODBasePath = FNarrationTool.FMODBasePath;

                if (narrationTable != null)
                {
                    List<FNarrationEvent> events = narrationTable.Files;
                    List<FNarrationFile> files = new List<FNarrationFile>();
                    string FMODFolderPath = narrationTable.FMODFolderPath;
                    string name, FMODPath;

                    for (int i = 0; i < events.Count; i++)
                    {
                        name = i.ToString();
                        FMODPath = FMODBasePath + FMODFolderPath + events[i].FileName + '.' + events[i].FileName + '\'';
                        files.Add(new FNarrationFile
                        {
                            Name = name,
                            FMODEvent = FMODPath,
                            Texts = events[i].Lines
                        });
                    }

                    StreamWriter jsonStreamWriter;

                    try
                    {
                        jsonStreamWriter = new StreamWriter(FNarrationTool.JsonFilePath);

                        using (jsonStreamWriter)
                        {
                            jsonStreamWriter.WriteLine(JsonConvert.SerializeObject(files));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Error: Could not load Narration Table.");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("No file path to save!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PreviewTable()
        {
            NarrationCSVPreviewerForm csvPreviewer = new NarrationCSVPreviewerForm(FNarrationTool.NarrationTable, FNarrationTool.FMODBasePath);
            csvPreviewer.ShowDialog();
        }

        private void SaveJsonFileAs()
        {
            SaveFileDialog jsonFileDialog = new SaveFileDialog()
            {
                Filter = "Json files (*.json)|*.json",
                RestoreDirectory = true
            };

            if (jsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream jsonStream = jsonFileDialog.OpenFile();

                if (jsonStream != null)
                {
                    jsonStream.Close();
                    FNarrationTool.JsonFilePath = jsonFileDialog.FileName;
                    SaveJsonFile();
                }
                else
                {
                    MessageBox.Show("Error: Could not create File Stream!");
                }
            }

        }

        private void dgNarrationFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsNarrationFiles.Show(Cursor.Position);
            }
        }

        private void dgNarrationFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                FNarrationTable narrationTable = FNarrationTool.NarrationTable;

                if (narrationTable != null && e.RowIndex >= 0 && e.RowIndex < narrationTable.Files.Count)
                {
                    narrationTable.Files[e.RowIndex].FileName = dgNarrationFiles.Rows[e.RowIndex].Cells[0].Value.ToString();
                }

            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveJsonFile();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveJsonFileAs();
        }

        private void tsmiAddFile_Click(object sender, EventArgs e)
        {
            AddNarrationFile();
        }

        private void tsmiRemoveFile_Click(object sender, EventArgs e)
        {
            RemoveNarrationFile();
        }

        private void tsmiEditLines_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgNarrationFiles.CurrentRow;

            if (currentRow != null)
            {
                FNarrationTool.OpenLineEditor(currentRow.Index);
                UpdateDataGrid();
            }

        }

        private void tsmiPreviewTable_Click(object sender, EventArgs e)
        {
            PreviewTable();
        }

        private void TbFMODPath_Leave(object sender, EventArgs e)
        {
            string correctedPath;
            char[] trimChars = { ' ', '.', ',' };
            char[] trimStartChars = { '/' };

            correctedPath = tbFMODPath.Text.Trim(trimChars);
            correctedPath = correctedPath.TrimStart(trimStartChars);
            correctedPath = correctedPath.TrimEnd(trimStartChars);

            string tmpStr = correctedPath;

            do
            {
                correctedPath = tmpStr;
                tmpStr = correctedPath.Replace("//", "/");
            } while (tmpStr.Length != correctedPath.Length);

            correctedPath += '/';

            tbFMODPath.Text = correctedPath;

            UpdateFMODPath(tbFMODPath.Text);
        }
    }
}
