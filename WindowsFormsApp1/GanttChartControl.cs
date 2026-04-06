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
        }
        public void LoadGanttChart(ScheduleSolution solution, Dictionary<int, List <int>> projectOperations)
        {
            dataGridView1.Columns.Add("name", "");
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                dataGridView1.Columns.Add($"{i + 1}day", $"{i + 1}");
            }
            foreach (var project in projectOperations)
            {
                dataGridView1.Rows.Add("Project " + project.Key);
                foreach (var opId in project.Value)
                {
                    var operation = solution.Operations[opId];
                    dataGridView1.Rows.Add(solution.Operations[opId].Name);
                    if ((int)operation.StartTime + 1 <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[(int)operation.StartTime + 1].Style.BackColor = Color.Red;
                        for (int i = (int)operation.StartTime + 1; i <= (int)operation.EndTime; i++)
                        {
                            if (i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
