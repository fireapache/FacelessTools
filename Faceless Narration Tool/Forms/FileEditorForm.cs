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
    public partial class FileEditorForm : Form
    {
        public FileEditorForm()
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

        private void ExportJSONFile()
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

                SaveFileDialog csvFileDialog = new SaveFileDialog()
                {
                    Filter = "JSON file (*.json)|*.json",
                    RestoreDirectory = true
                };

                if (csvFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter csvFile;
                    
                    try
                    {
                        string filename = csvFileDialog.FileName;
                        csvFile = new StreamWriter(filename);

                        using (csvFile)
                        {
                            
                            csvFile.WriteLine(JsonConvert.SerializeObject(files));
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            else
            {
                MessageBox.Show("Error: Could not load Narration Table.");
                Close();
            }
        }

        private void PreviewTable()
        {
            CSVPreviewerForm csvPreviewer = new CSVPreviewerForm(FNarrationTool.NarrationTable, FNarrationTool.FMODBasePath);
            csvPreviewer.ShowDialog();
        }

        private void SaveFile()
        {
            FNarrationTable narrationTable = FNarrationTool.NarrationTable;
            string jsonFilePath = FNarrationTool.JsonFilePath;

            if (jsonFilePath != null)
            {
                FileStream jsonStream = File.Open(FNarrationTool.JsonFilePath, FileMode.Create);

                if (jsonStream == null)
                {
                    MessageBox.Show("Error: Can not open target file!");
                }
                else if (narrationTable != null)
                {
                    string jsonString = JsonConvert.SerializeObject(narrationTable);

                    byte[] jsonBytes = Encoding.ASCII.GetBytes(jsonString);

                    using (jsonStream)
                    {
                        jsonStream.Write(jsonBytes, 0, jsonBytes.Length);
                    }

                    MessageBox.Show("File Saved Successfully!");

                }
                else
                {
                    MessageBox.Show("Error: Narration Table is missing!");
                }

            }
            else
            {
                SaveFileAs();
            }
            
        }

        private void SaveFileAs()
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
                    SaveFile();
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
            SaveFile();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
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

        private void tsmiExportTable_Click(object sender, EventArgs e)
        {
            ExportJSONFile();
        }
        
        private void tbFMODPath_TextChanged(object sender, EventArgs e)
        {
            UpdateFMODPath(tbFMODPath.Text);
        }
    }
}
