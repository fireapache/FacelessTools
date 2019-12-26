using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FacelessLocalizationTool.Forms;
using FacelessUtils;

namespace FacelessLocalizationTool
{
    static class FLocalizationTool
    {
        private static LocalizationStartupForm _StartupForm;
        private static LocalizationFileEditorForm _FileEditorForm;

        public static List<FLocalizationEntry> LocalizationFiles { get; } = new List<FLocalizationEntry>();

        private static string _filesPath = null;

        public static string FilesPath
        {
            get
            {
                if (Directory.Exists(_filesPath) == false)
                {
                    _filesPath = null;
                }

                if (_filesPath == null)
                {
                    FilesPath = GetSaveDirectory();
                }

                return _filesPath;
            }

            set
            {
                _filesPath = value;
            }
        }

        private static string GetSaveDirectory()
        {
            string result = null;

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult dialogResult = fbd.ShowDialog();

                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    result = fbd.SelectedPath;
                }
                else if (dialogResult != DialogResult.Cancel)
                {
                    MessageBox.Show("Not a valid folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }

        public static bool UpdateSaveDirectory()
        {
            string path = GetSaveDirectory();

            if (path != null)
            {
                FilesPath = path;
            }

            return path != null;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_StartupForm = new LocalizationStartupForm());
        }

        static public void LoadEditor()
        {
            var fileNameDialog = new LocalizationTextBox("Enter language name!");

            var dialogResult = fileNameDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                LocalizationFiles.Add(new FLocalizationEntry(fileNameDialog.TextResult, new FLocalizationFile()));
                ShowEditor();
            }
            else
            {
                MessageBox.Show("Failed to get language name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void LoadEditor(List<FLocalizationEntry> localizationFile)
        {
            if (localizationFile == null)
            {
                MessageBox.Show("Invalid localization file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LocalizationFiles.AddRange(localizationFile);
            ShowEditor();
        }

        private static void ShowEditor()
        {
            _StartupForm?.Hide();

            if (_FileEditorForm == null)
            {
                _FileEditorForm = new LocalizationFileEditorForm();
            }

            _FileEditorForm.Show();
        }
    }
}
