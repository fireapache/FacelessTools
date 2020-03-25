using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FacelessTools.Utils
{
    abstract class ImportResultBase
    {
        public string filePath { get; set; }
    }

    class NarrationLinesResult : ImportResultBase
    {
        public List<FNarrationLine> narrationLines { get; set; }

        public NarrationLinesResult()
        {
            filePath = string.Empty;
            narrationLines = new List<FNarrationLine>();
        }
    }

    class TextNotesResult : ImportResultBase
    {
        public List<FTextNote> TextNotes { get; set; }

        public TextNotesResult()
        {
            filePath = string.Empty;
            TextNotes = new List<FTextNote>();
        }
    }

    class StaticFunctions
    {
        private class FJsonFile
        {
            public string filePath;
        }

        private class FJsonStream : FJsonFile
        {
            public Stream fileStream;
        }

        private class FJsonContent : FJsonFile
        {
            public string content;
        }

        private static FJsonStream GetJsonStream()
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return new FJsonStream
            {
                filePath = jsonFileDialog.FileName,
                fileStream = jsonStream
            };
        }

        private static FJsonContent GetJsonContent()
        {
            string filePath = null;
            string jsonContent = null;

            var jsonStream = GetJsonStream();

            if (jsonStream != null && jsonStream.fileStream != null)
            {
                try
                {
                    byte[] fileBytes = new byte[jsonStream.fileStream.Length];
                    jsonStream.fileStream.Read(fileBytes, 0, Convert.ToInt32(jsonStream.fileStream.Length));
                    jsonContent = Encoding.UTF8.GetString(fileBytes);
                    filePath = jsonStream.filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                jsonStream.fileStream.Close();
            }

            return new FJsonContent
            {
                filePath = filePath,
                content = jsonContent
            };
        }

        public static NarrationLinesResult GetNarrationFiles()
        {
            NarrationLinesResult narrationFilesResult = null;

            var jsonContent = GetJsonContent();

            if (jsonContent != null && jsonContent.content != null)
            {
                List<FNarrationLine> fileNarrationLines = null;

                try
                {
                    fileNarrationLines = JsonConvert.DeserializeObject<List<FNarrationLine>>(jsonContent.content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (fileNarrationLines != null)
                {
                    narrationFilesResult = new NarrationLinesResult()
                    {
                        filePath = jsonContent.filePath,
                        narrationLines = fileNarrationLines
                    };
                }
                else
                {
                    MessageBox.Show("Error: Json file in wrong format!");
                }
            }

            return narrationFilesResult;
        }

        public static TextNotesResult GetTextNotes()
        {
            TextNotesResult textNotesResult = null;

            var jsonContent = GetJsonContent();

            if (jsonContent != null && jsonContent.content != null)
            {
                List<FTextNote> fileTextNotes = null;

                try
                {
                    fileTextNotes = JsonConvert.DeserializeObject<List<FTextNote>>(jsonContent.content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (fileTextNotes != null)
                {
                    textNotesResult = new TextNotesResult()
                    {
                        filePath = jsonContent.filePath,
                        TextNotes = fileTextNotes
                    };
                }
                else
                {
                    MessageBox.Show("Error: Json file in wrong format!");
                }
            }

            return textNotesResult;
        }

    }
}
