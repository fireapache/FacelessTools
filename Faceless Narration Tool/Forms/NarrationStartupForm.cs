using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using FacelessTools.Utils;

namespace FacelessTools.Narration
{
    public partial class NarrationStartupForm : Form
    {
        public NarrationStartupForm()
        {
            InitializeComponent();
        }

        private void LoadNarrationTable()
        {
            var result = FacelessTools.Utils.StaticFunctions.GetNarrationFiles();

            if (result != null)
            {
                FNarrationTool.JsonFilePath = result.FilePath;
                FNarrationTool.OpenEditor(new FNarrationTable(result.NarrationFiles));
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadNarrationTable();
        }

        private void StartupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FNarrationTool.OpenEditor(new FNarrationTable());
        }
    }

}
