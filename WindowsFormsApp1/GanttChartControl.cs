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
            if (DataStorage.Solution != null)
            {
                dataGridView1.Visible = true;
                flowLayoutPanel1.Visible = true;
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
                for (DateTime date = startTime; date <= endTime; date = date.AddDays(1))
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
                    //dataGridView1.Rows[rowIndex].Height = 5;
                    dataGridView1.Rows[rowIndex].Cells[0].Style.Font =
                        new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    foreach (var op in project.Value.Operations)
                    {
                        var opId = op.Id;
                        var operation = DataStorage.Solution.Operations[opId];
                        dataGridView1.Rows.Add(DataStorage.Solution.Operations[opId].Name, opId);
                        //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)operation.StartTime + 1].Style.BackColor = Color.Red;
                        for (int i = (int)operation.StartTime + 2; i <= (int)operation.EndTime + 1; i++)
                        {
                            var color = GetColorByExecutor(op.Resource);
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = color;
                        }
                    }
                }
                GetLegacy();
            }
            else
            {
                dataGridView1.Visible = false;
                flowLayoutPanel1.Visible = false;
            }
        }
        
        private void GetLegacy()
        {
            foreach (var exec in DataStorage.Executors)
            {
                Label lbl = new Label();
                lbl.Text = exec.Value.Name;
                lbl.BackColor = GetColorByExecutor(exec.Key);
                lbl.Font = new Font("Calibri", 12);
                lbl.ForeColor = Color.Black;
                lbl.AutoSize = false;
                lbl.Size = new Size(120, 25);
                lbl.Margin = new Padding(5);
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
