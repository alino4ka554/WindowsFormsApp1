using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GanttChartControl : UserControl
    {
        public GanttChartControl()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += (s, e) =>
            {
                dataGridView1.ClearSelection();
            };
            //dataGridView1.CellPainting += dataGridView1_CellPainting;
            LoadGanttChart();
        }
        public void LoadGanttChart()
        {
            dataGridView1.Columns.Add("Name", "");
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Frozen = true;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "Id";
            idColumn.Visible = false; // скрываем весь столбец
            dataGridView1.Columns.Add(idColumn);
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(DataStorage.Solution.TotalTime);
            for(DateTime date = startTime; date <= endTime; date = date.AddDays(1))
            {
                string day = date.Day < 10 ? $"0{date.Day}" : $"{date.Day}";
                string month = date.Month < 10 ? $"0{date.Month}" : $"{date.Month}";
                dataGridView1.Columns.Add($"{day}.{month}.{date.Year}", $"{day}.{month}");
                dataGridView1.Columns[$"{day}.{month}.{date.Year}"].Width = 37;
                dataGridView1.Columns[$"{day}.{month}.{date.Year}"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (var project in DataStorage.Projects)
            {
                int rowIndex = dataGridView1.Rows.Add(project.Value.Name);
                dataGridView1.Rows[rowIndex].Cells[0].Style.Font =
                    new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                foreach (var op in project.Value.Operations)
                {
                    var opId = op.Id;
                    var operation = DataStorage.Solution.Operations[opId];
                    dataGridView1.Rows.Add(DataStorage.Solution.Operations[opId].Name, opId);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)operation.StartTime + 1].Style.BackColor = Color.Red;
                    for (int i = (int)operation.StartTime + 1; i <= (int)operation.EndTime; i++)
                    {
                        var color = GetColorByExecutor(op.Resource);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = color;
                    }
                }
            }
            GetLegacy();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idColumnIndex = dataGridView1.Columns["Id"].Index;

            if (e.ColumnIndex == 0) return;

            var idValue = dataGridView1.Rows[e.RowIndex].Cells[idColumnIndex].Value;

            if (idValue == null)
                return;

            int opId = (int)idValue;

            var op = DataStorage.Solution.Operations[opId];

            using (var brush = new SolidBrush(GetColorByExecutor(op.Resource)))
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }

            TextRenderer.DrawText(e.Graphics,
                DataStorage.Executors[op.Resource].Name,
                e.CellStyle.Font,
                e.CellBounds,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }
        private void GetLegacy()
        {
            foreach (var exec in DataStorage.Executors)
            {
                Label lbl = new Label();
                lbl.Text = exec.Value.Name;
                lbl.BackColor = GetColorByExecutor(exec.Key);
                lbl.ForeColor = Color.White;
                lbl.AutoSize = false;
                lbl.Size = new Size(120, 25);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
        Color GetColorByExecutor(int id)
        {
            Random rnd = new Random(id); // фиксированный цвет для id
            return Color.FromArgb(rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
        }
    }
}
