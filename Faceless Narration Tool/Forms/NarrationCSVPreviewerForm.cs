using FacelessUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacelessNarrationTool.Forms
{
    public partial class NarrationCSVPreviewerForm : Form
    {
        private FNarrationTable _NarrationTable;
        private string _FMODBasePath;

        public NarrationCSVPreviewerForm()
        {
            InitializeComponent();
        }

        public NarrationCSVPreviewerForm(FNarrationTable narrationTable, string FMODBasePath)
        {
            InitializeComponent();

            _NarrationTable = narrationTable;
            _FMODBasePath = FMODBasePath;

            BuildDataGrid();
        }

        private void BuildDataGrid()
        {
            string index, FMODPath, lines;

            dgCSVViewer.Rows.Clear();

            if (_NarrationTable != null)
            {
                List<FNarrationEvent> files = _NarrationTable.Files;
                string FMODFolderPath = _NarrationTable.FMODFolderPath;

                for (int i = 0; i < files.Count; i++)
                {
                    index = i.ToString();
                    FMODPath = _FMODBasePath + FMODFolderPath + files[i].FileName + '.' + files[i].FileName + '\'';
                    lines = JsonConvert.SerializeObject(files[i].Lines).Replace("[{","({").Replace("}]","})");
                    dgCSVViewer.Rows.Add(index, FMODPath, lines);
                }
            }
            else
            {
                MessageBox.Show("Error: Could not load Narration Table.");
                Close();
            }
        }
    }
}
