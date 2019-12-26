﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacelessLocalizationTool.Forms
{
    public partial class LocalizationTextBox : Form
    {
        public string TextResult = null;

        public LocalizationTextBox(string Title = "Enter Text")
        {
            InitializeComponent();
            btnOK.Enabled = false;
            this.Text = Title;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string fineStr;
            char[] trimChars = { ' ', '.', ',' };
            char[] trimStartChars = { '/' };

            fineStr = textBox.Text.Trim(trimChars);
            fineStr = fineStr.TrimStart(trimStartChars);
            fineStr = fineStr.TrimEnd(trimStartChars);

            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                fineStr = fineStr.Replace(c.ToString(), "");
            }

            if (textBox.Text != fineStr)
            {
                textBox.Text = fineStr;
            }
            
            btnOK.Enabled = textBox.Text.Length > 0;
        }

    }
}
