
using System.Collections.Generic;

namespace FacelessUtils
{
    public class FNarrationTable
    {
        public string FMODFolderPath;
        public List<FNarrationEvent> Files;

        public FNarrationTable()
        {
            Files = new List<FNarrationEvent>();
        }

        public FNarrationTable(List<FNarrationFile> narrationFiles)
        {
            Files = new List<FNarrationEvent>();

            if (narrationFiles.Count > 0)
            {
                FMODFolderPath = "";
                char[] separators = { '\'', '.', '/' };

                foreach (FNarrationFile file in narrationFiles)
                {
                    if (file.FMODEvent == "None")
                    {
                        Files.Add(new FNarrationEvent());
                    }
                    else
                    {
                        string[] strPieces = file.FMODEvent.Split(separators);

                        if (FMODFolderPath == "")
                        {
                            for (int i = 5; i < strPieces.Length - 3; i++)
                            {
                                FMODFolderPath += strPieces[i] + '/';
                            }
                        }

                        Files.Add(new FNarrationEvent(file, strPieces[strPieces.Length - 2]));
                    }
                }
            }
        }
    }

    public class FNarrationEvent
    {
        public string FileName;
        public List<FNarrationLine> Lines;

        public FNarrationEvent(string defaultFileName = "None")
        {
            FileName = defaultFileName;
            Lines = new List<FNarrationLine>();
        }

        public FNarrationEvent(FNarrationFile narrationFile, string defaultFileName = "None")
        {
            FileName = defaultFileName;
            Lines = narrationFile.Texts;
        }

    }
    
    public class FNarrationJsonFile
    {
        public List<FNarrationFile> NarrationFiles;
    }

    public class FNarrationFile
    {
        public string Name;
        public string FMODEvent;
        public List<FNarrationLine> Texts;

        public FNarrationFile()
        {
            Texts = new List<FNarrationLine>();
        }

    }

    public class FNarrationLine
    {
        public float Time;
        public string Text;
    }

}