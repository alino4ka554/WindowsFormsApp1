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
            if (DataStorage.Solution != null)
                LoadSchedule();
            else
            {
                dataGridView1.Visible = false;
                Label label = new Label();
                label.Text = "Нет актуального расписания";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
                panel4.Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
        }
        public void LoadSchedule()
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            foreach (var ops in DataStorage.Solution.Operations)
            {
                var op = ops.Value;
                var projectName = DataStorage.Projects[op.Project].Name;
                var executorName = DataStorage.Executors[op.Resource].Name;
                dataGridView1.Rows.Add(op.Id, $"{op.Name}", $"{op.StartTime}", $"{op.EndTime}", $"{projectName}", $"{executorName}");
            }
            
        }
    }
}
