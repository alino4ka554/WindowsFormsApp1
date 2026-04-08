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
            LoadGanttChart();
        }
        public void LoadGanttChart()
        {
            dataGridView1.Columns.Add("Name", "");
            dataGridView1.Columns[0].Width = 150;
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
                dataGridView1.Rows.Add("Project " + project.Key);
                foreach (var op in project.Value.Operations)
                {
                    var opId = op.Id;
                    var operation = DataStorage.Solution.Operations[opId];
                    dataGridView1.Rows.Add(DataStorage.Solution.Operations[opId].Name);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)operation.StartTime + 1].Style.BackColor = Color.Red;
                    for (int i = (int)operation.StartTime + 1; i <= (int)operation.EndTime; i++)
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
