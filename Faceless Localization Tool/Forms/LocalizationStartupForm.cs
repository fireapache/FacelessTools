using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DarkUI.Forms;
using FacelessTools.Utils;
using Newtonsoft.Json;

namespace FacelessTools.Localization
{
    public partial class LocalizationStartupForm : DarkForm
    {
        public LocalizationStartupForm()
        {
            InitializeComponent();
        }

        private List<FLocalizationEntry> LoadLocalizationFile()
        {
            Stream jsonStream = null;
            List<FLocalizationEntry> result = null;

            OpenFileDialog jsonFileDialog = new OpenFileDialog()
            {
                Filter = "Json files (*.json)|*.json",
                RestoreDirectory = true,
                Multiselect = true
            };

            if (jsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                result = new List<FLocalizationEntry>();

                FLocalizationTool.FilesPath = Path.GetDirectoryName(jsonFileDialog.FileName);

                try
                {
                    foreach (var file in jsonFileDialog.FileNames)
                    {
                        jsonFileDialog.FileName = file;
                        jsonStream = jsonFileDialog.OpenFile();

                        using (jsonStream)
                        {
                            byte[] fileBytes = new byte[jsonStream.Length];

                            jsonStream.Read(fileBytes, 0, Convert.ToInt32(jsonStream.Length));

                            string fileString = Encoding.UTF8.GetString(fileBytes);

                            var localizationFile = JsonConvert.DeserializeObject<FLocalizationFile>(fileString);

                            if (localizationFile != null)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(jsonFileDialog.FileName);
                                result.Add(new FLocalizationEntry(fileName, localizationFile));
                            }
                            else
                            {
                                MessageBox.Show("Error: Json file in wrong format! " + file);
                            }
                        }

                        jsonStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return result;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FLocalizationTool.LoadEditor();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FLocalizationTool.LoadEditor(LoadLocalizationFile());
        }
    }
}
