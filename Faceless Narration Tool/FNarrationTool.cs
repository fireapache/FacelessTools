using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacelessUtils;
using System.IO;

namespace FacelessNarrationTool
{
    static class FNarrationTool
    {
        private static StartupForm _StartupForm;
        private static FileEditorForm _FileEditorForm;
        private static LineEditorForm _LineEditorForm;

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
            Application.Run(_StartupForm = new StartupForm());
        }

        internal static void OpenEditor(FNarrationTable narrationTable)
        {
            if (narrationTable != null)
            {
                _NarrationTable = narrationTable;

                if (_FileEditorForm == null)
                {
                    _FileEditorForm = new FileEditorForm();
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

            _LineEditorForm = new LineEditorForm(lines, (response) =>
            {
                _NarrationTable.Files[fileIndex].Lines = response;
            });

            _LineEditorForm.ShowDialog();

        }

    }
}
