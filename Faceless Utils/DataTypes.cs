
using System.Collections.Generic;

namespace FacelessTools.Utils
{
    public class FNarrationTable
    {
        public string SoundAssetsFolderPath;
        public List<FNarrationSoundAsset> SoundAssets;

        public FNarrationTable()
        {
            SoundAssets = new List<FNarrationSoundAsset>();
        }

        public FNarrationTable(List<FNarrationLine> narrationLines)
        {
            SoundAssets = new List<FNarrationSoundAsset>();

            if (narrationLines.Count > 0)
            {
                SoundAssetsFolderPath = "";
                char[] separators = { '\'', '.', '/' };

                foreach (FNarrationLine line in narrationLines)
                {
                    if (line.FMODEvent == "None")
                    {
                        SoundAssets.Add(new FNarrationSoundAsset(line));
                    }
                    else
                    {
                        string[] strPieces = line.FMODEvent.Split(separators);

                        if (SoundAssetsFolderPath == "")
                        {
                            for (int i = 5; i < strPieces.Length - 3; i++)
                            {
                                SoundAssetsFolderPath += strPieces[i] + '/';
                            }
                        }

                        SoundAssets.Add(new FNarrationSoundAsset(line, strPieces[strPieces.Length - 2]));
                    }
                }
            }
        }
    }

    public class FNarrationSoundAsset
    {
        public string FileName;
        public List<FNarrationLinePart> Lines;

        public FNarrationSoundAsset(string defaultFileName = "None")
        {
            FileName = defaultFileName;
            Lines = new List<FNarrationLinePart>();
        }

        public FNarrationSoundAsset(FNarrationLine narrationLine, string defaultFileName = "None")
        {
            FileName = defaultFileName;
            Lines = narrationLine.Texts;
        }

    }
    
    public class FNarrationJsonFile
    {
        public List<FNarrationLine> NarrationLines;
    }

    public abstract class FDataTableItem
    {
        public string Name;
    }

    public class FNarrationLine : FDataTableItem
    {
        public string FMODEvent;
        public List<FNarrationLinePart> Texts;

        public FNarrationLine()
        {
            Texts = new List<FNarrationLinePart>();
        }

    }

    public class FNarrationLinePart
    {
        public float Time;
        public string Text;
    }

    public class FLocalizationEntry
    {
        public string Language;
        public FLocalizationFile FileContents;

        public FLocalizationEntry(string Language = "None", FLocalizationFile FileContents = null)
        {
            this.Language = Language;
            this.FileContents = FileContents;
        }
    }

    public class FLocalizationFile
    {
        public int FileVersion;
        public List<FLocalizationFileEntry> Entries;

        public FLocalizationFile()
        {
            Entries = new List<FLocalizationFileEntry>();
        }
    }

    public class FLocalizationFileEntry
    {
        public string Key;
        public string Value;
    }

    public class FTextNote : FDataTableItem
    {
        public string Title;
        public string Text;
    }
}