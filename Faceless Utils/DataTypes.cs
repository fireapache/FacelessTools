
using System.Collections.Generic;

namespace FacelessUtils
{
    public class FNarrationTable
    {
        public string FMODFolderPath;
        public List<FNarractionFile> Files;

        public FNarrationTable()
        {
            Files = new List<FNarractionFile>();
        }

    }

    public class FNarractionFile
    {
        public string FileName;
        public List<FNarrationLine> Lines;

        public FNarractionFile()
        {
            Lines = new List<FNarrationLine>();
        }

    }

    public class FNarrationLine
    {
        public float Time;
        public string Text;
    }

}