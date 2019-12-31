namespace FacelessTools.Narration
{
    partial class NarrationLineEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarrationLineEditorForm));
            this.dgNarrationLines = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msLineEditor = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveLines = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiscardLines = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNarrationLines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveLines = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgNarrationLines)).BeginInit();
            this.msLineEditor.SuspendLayout();
            this.cmsNarrationLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgNarrationLines
            // 
            this.dgNarrationLines.AllowUserToAddRows = false;
            this.dgNarrationLines.AllowUserToDeleteRows = false;
            this.dgNarrationLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNarrationLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNarrationLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.TextLine});
            this.dgNarrationLines.Location = new System.Drawing.Point(13, 27);
            this.dgNarrationLines.Name = "dgNarrationLines";
            this.dgNarrationLines.Size = new System.Drawing.Size(959, 222);
            this.dgNarrationLines.TabIndex = 0;
            this.dgNarrationLines.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgNarrationLines_MouseClick);
            // 
            // Time
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle1;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 60;
            // 
            // TextLine
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TextLine.DefaultCellStyle = dataGridViewCellStyle2;
            this.TextLine.HeaderText = "Text Line";
            this.TextLine.Name = "TextLine";
            this.TextLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TextLine.Width = 800;
            // 
            // msLineEditor
            // 
            this.msLineEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.msLineEditor.Location = new System.Drawing.Point(0, 0);
            this.msLineEditor.Name = "msLineEditor";
            this.msLineEditor.Size = new System.Drawing.Size(984, 24);
            this.msLineEditor.TabIndex = 1;
            this.msLineEditor.Text = "Line Editor Menu";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveLines,
            this.tsmiDiscardLines});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmiSaveLines
            // 
            this.tsmiSaveLines.Name = "tsmiSaveLines";
            this.tsmiSaveLines.Size = new System.Drawing.Size(113, 22);
            this.tsmiSaveLines.Text = "Save";
            this.tsmiSaveLines.Click += new System.EventHandler(this.tsmiSaveLines_Click);
            // 
            // tsmiDiscardLines
            // 
            this.tsmiDiscardLines.Name = "tsmiDiscardLines";
            this.tsmiDiscardLines.Size = new System.Drawing.Size(113, 22);
            this.tsmiDiscardLines.Text = "Discard";
            this.tsmiDiscardLines.Click += new System.EventHandler(this.tsmiDiscardLines_Click);
            // 
            // cmsNarrationLines
            // 
            this.cmsNarrationLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddLine,
            this.tsmiRemoveLines});
            this.cmsNarrationLines.Name = "cmsNarrationFiles";
            this.cmsNarrationLines.Size = new System.Drawing.Size(156, 48);
            // 
            // tsmiAddLine
            // 
            this.tsmiAddLine.Name = "tsmiAddLine";
            this.tsmiAddLine.Size = new System.Drawing.Size(155, 22);
            this.tsmiAddLine.Text = "Add Line";
            this.tsmiAddLine.Click += new System.EventHandler(this.tsmiAddLine_Click);
            // 
            // tsmiRemoveLines
            // 
            this.tsmiRemoveLines.Name = "tsmiRemoveLines";
            this.tsmiRemoveLines.Size = new System.Drawing.Size(155, 22);
            this.tsmiRemoveLines.Text = "Remove Line(s)";
            this.tsmiRemoveLines.Click += new System.EventHandler(this.tsmiRemoveLines_Click);
            // 
            // NarrationLineEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 261);
            this.Controls.Add(this.dgNarrationLines);
            this.Controls.Add(this.msLineEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msLineEditor;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 300);
            this.Name = "NarrationLineEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Narration Line Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgNarrationLines)).EndInit();
            this.msLineEditor.ResumeLayout(false);
            this.msLineEditor.PerformLayout();
            this.cmsNarrationLines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNarrationLines;
        private System.Windows.Forms.MenuStrip msLineEditor;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLines;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiscardLines;
        private System.Windows.Forms.ContextMenuStrip cmsNarrationLines;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddLine;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextLine;
    }
}