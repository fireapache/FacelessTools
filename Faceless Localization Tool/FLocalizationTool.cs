using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacelessLocalizationTool.Forms;
using FacelessUtils;

namespace FacelessLocalizationTool
{
    static class FLocalizationTool
    {
        private static LocalizationStartupForm _StartupForm;
        private static LocalizationFileEditorForm _FileEditorForm;

        public static List<FLocalizationEntry> LocalizationFiles = new List<FLocalizationEntry>();

        public static string FilesPath = null;

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
