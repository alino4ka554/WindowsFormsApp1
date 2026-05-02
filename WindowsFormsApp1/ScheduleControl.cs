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
    public partial class ScheduleControl : UserControl
    {
        public ScheduleControl()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += (s, e) =>
            {
                dataGridView1.ClearSelection();
            };
            LoadSchedule();
        }
        public void HideBuildSolution()
        {
            buttonBuildSolution.Visible = false;
        }
        public void ShowBuildSolution()
        {
            buttonBuildSolution.Visible = true;
        }
        public void LoadSchedule()
        {
            if (DataStorage.Projects.Count > 0)
                ShowBuildSolution();
            else
                HideBuildSolution();
            if (DataStorage.Solution != null)
            {
                tableLayoutPanel1.Visible = false;
                buttonSpeedUp.Visible = true;
                dataGridView1.Rows.Clear();
                foreach (var ops in DataStorage.Solution.Operations)
                {
                    var op = ops.Value;
                    var projectName = DataStorage.Projects[op.Project].Name;
                    var executorName = DataStorage.Executors[op.Resource].Name;
                    dataGridView1.Rows.Add(op.Id, $"{op.Name}", $"{op.StartTime}", $"{op.EndTime}", $"{projectName}", $"{executorName}");
                }
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                buttonSpeedUp.Visible = false;
            }
        }

        private void buttonSpeedUp_Click(object sender, EventArgs e)
        {
            var criticalWayMethod = new CPM(DataStorage.Solution, 0.01);
            criticalWayMethod.Run();
            LoadSchedule();
        }

        private async void buttonBuildSolution_Click(object sender, EventArgs e)
        {
            BuildScheduleForm form = new BuildScheduleForm();
            form.ShowDialog();
            LoadSchedule();
        }
    }
}
