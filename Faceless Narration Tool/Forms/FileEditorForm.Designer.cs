namespace FacelessNarrationTool.Forms
{
    partial class FileEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileEditorForm));
            this.dgNarrationFiles = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFMODPath = new System.Windows.Forms.TextBox();
            this.lblFMODPath = new System.Windows.Forms.Label();
            this.msEditor = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPreviewCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNarrationFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditLines = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgNarrationFiles)).BeginInit();
            this.msEditor.SuspendLayout();
            this.cmsNarrationFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgNarrationFiles
            // 
            this.dgNarrationFiles.AllowUserToAddRows = false;
            this.dgNarrationFiles.AllowUserToDeleteRows = false;
            this.dgNarrationFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNarrationFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNarrationFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Lines});
            this.dgNarrationFiles.Location = new System.Drawing.Point(12, 53);
            this.dgNarrationFiles.Name = "dgNarrationFiles";
            this.dgNarrationFiles.Size = new System.Drawing.Size(260, 234);
            this.dgNarrationFiles.TabIndex = 0;
            this.dgNarrationFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNarrationFiles_CellValueChanged);
            this.dgNarrationFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgNarrationFiles_MouseClick);
            // 
            // FileName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FileName.DefaultCellStyle = dataGridViewCellStyle1;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FileName.Width = 150;
            // 
            // Lines
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lines.DefaultCellStyle = dataGridViewCellStyle2;
            this.Lines.HeaderText = "Lines";
            this.Lines.Name = "Lines";
            this.Lines.ReadOnly = true;
            this.Lines.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Lines.Width = 50;
            // 
            // tbFMODPath
            // 
            this.tbFMODPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFMODPath.Location = new System.Drawing.Point(114, 27);
            this.tbFMODPath.Name = "tbFMODPath";
            this.tbFMODPath.Size = new System.Drawing.Size(158, 20);
            this.tbFMODPath.TabIndex = 1;
            this.tbFMODPath.TextChanged += new System.EventHandler(this.tbFMODPath_TextChanged);
            // 
            // lblFMODPath
            // 
            this.lblFMODPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFMODPath.AutoSize = true;
            this.lblFMODPath.Location = new System.Drawing.Point(12, 30);
            this.lblFMODPath.Name = "lblFMODPath";
            this.lblFMODPath.Size = new System.Drawing.Size(98, 13);
            this.lblFMODPath.TabIndex = 2;
            this.lblFMODPath.Text = "FMOD Folder Path:";
            this.lblFMODPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // msEditor
            // 
            this.msEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msEditor.Location = new System.Drawing.Point(0, 0);
            this.msEditor.Name = "msEditor";
            this.msEditor.Size = new System.Drawing.Size(284, 24);
            this.msEditor.TabIndex = 3;
            this.msEditor.Text = "msEditor";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiSaveAs,
            this.tsmiPreviewCSV,
            this.tsmiExportCSV});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(139, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(139, 22);
            this.tsmiSaveAs.Text = "Save As";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // tsmiPreviewCSV
            // 
            this.tsmiPreviewCSV.Name = "tsmiPreviewCSV";
            this.tsmiPreviewCSV.Size = new System.Drawing.Size(139, 22);
            this.tsmiPreviewCSV.Text = "Preview CSV";
            this.tsmiPreviewCSV.Click += new System.EventHandler(this.tsmiPreviewCSV_Click);
            // 
            // tsmiExportCSV
            // 
            this.tsmiExportCSV.Name = "tsmiExportCSV";
            this.tsmiExportCSV.Size = new System.Drawing.Size(139, 22);
            this.tsmiExportCSV.Text = "Export CSV";
            this.tsmiExportCSV.Click += new System.EventHandler(this.tsmiExportCSV_Click);
            // 
            // cmsNarrationFiles
            // 
            this.cmsNarrationFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditLines,
            this.tsmiAddFile,
            this.tsmiRemoveFile});
            this.cmsNarrationFiles.Name = "cmsNarrationFiles";
            this.cmsNarrationFiles.Size = new System.Drawing.Size(139, 70);
            // 
            // tsmiEditLines
            // 
            this.tsmiEditLines.Name = "tsmiEditLines";
            this.tsmiEditLines.Size = new System.Drawing.Size(138, 22);
            this.tsmiEditLines.Text = "Edit Lines";
            this.tsmiEditLines.Click += new System.EventHandler(this.tsmiEditLines_Click);
            // 
            // tsmiAddFile
            // 
            this.tsmiAddFile.Name = "tsmiAddFile";
            this.tsmiAddFile.Size = new System.Drawing.Size(138, 22);
            this.tsmiAddFile.Text = "Add File";
            this.tsmiAddFile.Click += new System.EventHandler(this.tsmiAddFile_Click);
            // 
            // tsmiRemoveFile
            // 
            this.tsmiRemoveFile.Name = "tsmiRemoveFile";
            this.tsmiRemoveFile.Size = new System.Drawing.Size(138, 22);
            this.tsmiRemoveFile.Text = "Remove File";
            this.tsmiRemoveFile.Click += new System.EventHandler(this.tsmiRemoveFile_Click);
            // 
            // FileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this.lblFMODPath);
            this.Controls.Add(this.tbFMODPath);
            this.Controls.Add(this.dgNarrationFiles);
            this.Controls.Add(this.msEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msEditor;
            this.MaximumSize = new System.Drawing.Size(300, 900);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FileEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faceless Narration Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditorForm_FormClosed);
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNarrationFiles)).EndInit();
            this.msEditor.ResumeLayout(false);
            this.msEditor.PerformLayout();
            this.cmsNarrationFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNarrationFiles;
        private System.Windows.Forms.TextBox tbFMODPath;
        private System.Windows.Forms.Label lblFMODPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.MenuStrip msEditor;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportCSV;
        private System.Windows.Forms.ContextMenuStrip cmsNarrationFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditLines;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreviewCSV;
    }
}