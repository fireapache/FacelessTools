namespace FacelessTools.Narration.Forms
{
    partial class NarrationCSVPreviewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarrationCSVPreviewerForm));
            this.dgCSVViewer = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FMODEventPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCSVViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCSVViewer
            // 
            this.dgCSVViewer.AllowUserToAddRows = false;
            this.dgCSVViewer.AllowUserToDeleteRows = false;
            this.dgCSVViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCSVViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCSVViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.FMODEventPath,
            this.Linex});
            this.dgCSVViewer.Location = new System.Drawing.Point(12, 12);
            this.dgCSVViewer.Name = "dgCSVViewer";
            this.dgCSVViewer.ReadOnly = true;
            this.dgCSVViewer.Size = new System.Drawing.Size(1010, 187);
            this.dgCSVViewer.TabIndex = 0;
            // 
            // Index
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Index.DefaultCellStyle = dataGridViewCellStyle1;
            this.Index.HeaderText = "";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Index.Width = 50;
            // 
            // FMODEventPath
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.FMODEventPath.DefaultCellStyle = dataGridViewCellStyle2;
            this.FMODEventPath.HeaderText = "FMODEventPath";
            this.FMODEventPath.Name = "FMODEventPath";
            this.FMODEventPath.ReadOnly = true;
            this.FMODEventPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FMODEventPath.Width = 300;
            // 
            // Linex
            // 
            this.Linex.HeaderText = "Lines";
            this.Linex.Name = "Linex";
            this.Linex.ReadOnly = true;
            this.Linex.Width = 600;
            // 
            // NarrationCSVPreviewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 211);
            this.Controls.Add(this.dgCSVViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 250);
            this.Name = "NarrationCSVPreviewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Narration CSV Previewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgCSVViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCSVViewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn FMODEventPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linex;
    }
}