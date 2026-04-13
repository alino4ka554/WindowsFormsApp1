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
    public partial class ProjectControl : UserControl
    {
        int ProjectId;
        public ProjectControl(int projectId)
        {
            InitializeComponent();
            ProjectId = projectId;
            if (DataStorage.Projects[ProjectId].Operations.Count > 0)
                LoadOperations();
            
            else
            {
                dataGridView1.Visible = false;
                Label label = new Label();
                label.Text = "Пока нет задач";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
                panel4.Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
            
        }
        public void LoadOperations()
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            var ops = DataStorage.Projects[ProjectId].Operations;
            foreach (var op in ops)
            {
                var executorName = DataStorage.Executors[op.Resource].Name;
                dataGridView1.Rows.Add(op.Id, $"{op.Name}", $"{executorName}", $"{op.NormalTime} - {op.CrashTime}", $"{op.NormalCost} - {op.CrashCost}");
            }
            dataGridView1.ClearSelection();
        }
        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            OperationAdd operationAdd = new OperationAdd(ProjectId);
            operationAdd.ShowDialog();
            LoadOperations();
        }
    }
}
