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
            LoadSchedule();
        }
        public void LoadSchedule()
        {
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
