using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacelessUtils;

namespace FacelessNarrationTool
{
    public partial class LineEditorForm : Form
    {
        private Action<List<FNarrationLine>> _Callback;

        public LineEditorForm()
        {
            InitializeComponent();
        }

        public LineEditorForm(List<FNarrationLine> narrationLines, Action<List<FNarrationLine>> callback)
        {
            InitializeComponent();

            _Callback = callback;

            foreach (var line in narrationLines)
            {
                dgNarrationLines.Rows.Add(line.Time, line.Text);
            }

        }

        private List<FNarrationLine> BuildNarrationLines()
        {
            List<FNarrationLine> lineList = new List<FNarrationLine>();
            bool validTime, validText;
            float time;
            string text;

            if (dgNarrationLines.Rows.Count > 0)
            {
                for (int i = 0; i < dgNarrationLines.Rows.Count; i++)
                {
                    validTime = dgNarrationLines.Rows[i].Cells[0].Value != null;
                    validText = dgNarrationLines.Rows[i].Cells[1].Value != null;

                    if (validTime && validText)
                    {
                        time = float.Parse(dgNarrationLines.Rows[i].Cells[0].Value.ToString());
                        text = dgNarrationLines.Rows[i].Cells[1].Value.ToString();

                        lineList.Add(new FNarrationLine() { Time = time, Text = text });
                    }
                    
                }
            }
            
            return lineList;
        }

        private void AddNarrationLine()
        {
            DataGridViewSelectedRowCollection nextRows = null;
            DataGridViewRow currentRow = dgNarrationLines.CurrentRow;

            if (currentRow != null)
            {
                dgNarrationLines.ClearSelection();

                foreach (DataGridViewRow row in dgNarrationLines.Rows)
                {
                    if (row.Index > currentRow.Index)
                    {
                        row.Selected = true;
                    }
                }

                nextRows = dgNarrationLines.SelectedRows;

                foreach (DataGridViewRow row in nextRows)
                {
                    dgNarrationLines.Rows.Remove(row);
                }

            }

            dgNarrationLines.Rows.Add("0.0", "ADD_TEXT");

            if (nextRows != null && nextRows.Count > 0)
            {
                for (int i = nextRows.Count - 1; i >= 0; i--)
                {
                    dgNarrationLines.Rows.Add(nextRows[i]);
                }
            }
        }

        private void RemoveNarrationLines()
        {
            var selectedRows = dgNarrationLines.SelectedRows;
            var currentRow = dgNarrationLines.CurrentRow;

            if (selectedRows != null && selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    dgNarrationLines.Rows.Remove(row);
                }
            }
            else if (currentRow != null)
            {
                dgNarrationLines.Rows.Remove(currentRow);
            }

        }

        private void tsmiSaveLines_Click(object sender, EventArgs e)
        {
            _Callback?.Invoke(BuildNarrationLines());
            Close();
        }

        private void tsmiDiscardLines_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiAddLine_Click(object sender, EventArgs e)
        {
            AddNarrationLine();
        }

        private void dgNarrationLines_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsNarrationLines.Show(Cursor.Position);
            }
        }

        private void tsmiRemoveLines_Click(object sender, EventArgs e)
        {
            RemoveNarrationLines();
        }
    }
}
