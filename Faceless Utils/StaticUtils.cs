using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FacelessTools.Utils
{
    class NarrationFilesResult
    {
        public string FilePath { get; set; }
        public List<FNarrationFile> NarrationFiles { get; set; }

        public NarrationFilesResult()
        {
            FilePath = string.Empty;
            NarrationFiles = new List<FNarrationFile>();
        }
    }

    class StaticFunctions
    {
        public static NarrationFilesResult GetNarrationFiles()
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

                    NarrationFilesResult narrationFilesResult = null;

                    using (jsonStream)
                    {
                        byte[] fileBytes = new byte[jsonStream.Length];

                        jsonStream.Read(fileBytes, 0, Convert.ToInt32(jsonStream.Length));

                        string fileString = Encoding.UTF8.GetString(fileBytes);

                        List<FNarrationFile> narrationFiles = JsonConvert.DeserializeObject<List<FNarrationFile>>(fileString);

                        if (narrationFiles != null)
                        {
                            narrationFilesResult = new NarrationFilesResult()
                            {
                                FilePath = jsonFileDialog.FileName,
                                NarrationFiles = narrationFiles
                            };
                        }
                        else
                        {
                            MessageBox.Show("Error: Json file in wrong format!");
                        }

                        jsonStream.Close();
                    }

                    return narrationFilesResult;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return null;
        }

    }
}
