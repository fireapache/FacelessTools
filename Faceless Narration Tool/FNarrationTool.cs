using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacelessTools.Utils;
using FacelessTools.Narration.Forms;

namespace FacelessTools.Narration
{
    static class FNarrationTool
    {
        private static NarrationStartupForm _StartupForm;
        private static NarrationFileEditorForm _FileEditorForm;
        private static NarrationLineEditorForm _LineEditorForm;

        private static string _FMODBasePath = "FMODEvent'/Game/FMOD/Events/";
        public static string FMODBasePath
        {
            get { return _FMODBasePath; }
        }

        private static FNarrationTable _NarrationTable;
        public static FNarrationTable NarrationTable
        {
            get { return _NarrationTable; }
        }

        private static string _JsonFilePath;
        public static string JsonFilePath
        {
            get { return _JsonFilePath; }
            set { _JsonFilePath = value; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_StartupForm = new NarrationStartupForm());
        }

        internal static void OpenEditor(FNarrationTable narrationTable)
        {
            if (narrationTable != null)
            {
                _NarrationTable = narrationTable;

                if (_FileEditorForm == null)
                {
                    _FileEditorForm = new NarrationFileEditorForm();
                }

                _FileEditorForm.Show();

                if (_StartupForm != null)
                {
                    _StartupForm.Hide();
                }
            }
            
        }

        internal static void OpenLineEditor(int fileIndex)
        {
            List<FNarrationLine> lines = _NarrationTable.Files[fileIndex].Lines;

            _LineEditorForm = new NarrationLineEditorForm(lines, (response) =>
            {
                _NarrationTable.Files[fileIndex].Lines = response;
            });

            _LineEditorForm.ShowDialog();

        }

    }
}
