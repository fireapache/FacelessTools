
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

    }

    public class FNarrationEvent
    {
        public string FileName;
        public List<FNarrationLine> Lines;

        public FNarrationEvent()
        {
            Lines = new List<FNarrationLine>();
        }

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