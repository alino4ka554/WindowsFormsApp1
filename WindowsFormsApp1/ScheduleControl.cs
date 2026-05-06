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
        private readonly ScheduleService _service = new ScheduleService();
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
            var solution = _service.GetSolution();
            if (DataStorage.Projects.Count > 0)
                ShowBuildSolution();
            else
                HideBuildSolution();
            if (DataStorage.Solution != null)
            {
                tableLayoutPanel1.Visible = false;
                buttonSpeedUp.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Rows.Clear();
                foreach (var ops in DataStorage.Solution.Operations)
                {
                    var op = ops.Value;
                    var projectName = DataStorage.Projects[op.Project].Name;
                    var executorName = DataStorage.Executors[op.Resource].Name;
                    DateTime startTime = DataStorage.dateTime.AddDays(op.StartTime);
                    DateTime endTime = DataStorage.dateTime.AddDays(op.EndTime);
                    dataGridView1.Rows.Add(op.Id, $"{op.Name}", $"{startTime.ToString("dd.MM.yyyy")}", $"{endTime.ToString("dd.MM.yyyy")}", $"{projectName}", $"{executorName}");
                }
                buttonSpeedUp.Visible = true;
            }
            else
            {
                dataGridView1.Visible = false;
                tableLayoutPanel1.Visible = true;
                buttonSpeedUp.Visible = false;
            }
        }

        private void buttonSpeedUp_Click(object sender, EventArgs e)
        {
            _service.OptimizeSchedule(0.01);
            LoadSchedule();
        }

        private async void buttonBuildSolution_Click(object sender, EventArgs e)
        {
            BuildScheduleForm form = new BuildScheduleForm(_service);
            form.ShowDialog();
            LoadSchedule();
        }
    }
}
