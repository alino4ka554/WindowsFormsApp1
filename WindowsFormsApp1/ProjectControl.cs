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
            LoadOperations();
            labelHeader.Text = DataStorage.Projects[ProjectId].Name;
        }

        public void LoadOperations()
        {
            if (DataStorage.Projects[ProjectId].Operations.Count > 0)
            {
                buttonDeleteProject.Visible = true;
                tableLayoutPanel1.Visible = false;
                dataGridView1.Rows.Clear();
                var ops = DataStorage.Projects[ProjectId].Operations;
                foreach (var op in ops)
                {
                    var executorName = DataStorage.Executors[op.Resource].Name;
                    dataGridView1.Rows.Add(op.Id, $"{op.Name}", $"{executorName}", $"{op.CrashTime} - {op.NormalTime}", $"{op.NormalCost} - {op.CrashCost}");
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                buttonDeleteProject.Visible = false;
                tableLayoutPanel1.Visible = true;
            }
        }
        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            OperationAdd operationAdd = new OperationAdd(ProjectId);
            operationAdd.ShowDialog();
            LoadOperations();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ProjectsControl projectsControl = new ProjectsControl();
            MainForm form = Application.OpenForms["Form1"] as MainForm;
            form?.ShowSideMenu();
            form.OpenPage(projectsControl);
        }

        private void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранные задачи?", "Подтверждение",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int operationId = (int)row.Cells[0].Value;
                        var operation = DataStorage.Operations[operationId];
                        DataManager.Instance.DeleteOperation(operation);
                        LoadOperations();
                    }
                }
            }
        }
    }
}
