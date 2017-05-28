using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using FacelessUtils;

namespace FacelessNarrationTool
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void LoadNarrationTable()
        {
            Stream jsonStream = null;

            OpenFileDialog jsonFileDialog = new OpenFileDialog()
            {
                Filter = "Json files (*.json)|*.json",
                RestoreDirectory = true
            };

            if (jsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    jsonStream = jsonFileDialog.OpenFile();

                    using (jsonStream)
                    {
                        FNarrationTool.JsonFilePath = jsonFileDialog.FileName;

                        byte[] fileBytes = new byte[jsonStream.Length];

                        jsonStream.Read(fileBytes, 0, Convert.ToInt32(jsonStream.Length));

                        string fileString = Encoding.UTF8.GetString(fileBytes);

                        FNarrationTable narrationTable = JsonConvert.DeserializeObject<FNarrationTable>(fileString);

                        if (narrationTable != null)
                        {
                            FNarrationTool.OpenEditor(narrationTable);
                        }
                        else
                        {
                            MessageBox.Show("Error: Json file in wrong format!");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadNarrationTable();
        }

        private void StartupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FNarrationTool.OpenEditor(new FNarrationTable());
        }
    }
}
