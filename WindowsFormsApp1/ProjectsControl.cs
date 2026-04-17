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
    public partial class ProjectsControl : UserControl
    {
        public ProjectsControl()
        {
            InitializeComponent();
            LoadProjects();
            label1.Image = ImageHelper.MakeGrayscale(label1.Image);
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

        }
        public void LoadProjects()
        {
            if (DataStorage.Projects.Count > 0)
            {
                buttonDeleteProject.Visible = true;
                tableLayoutPanel1.Visible = false;
                dataGridView1.Rows.Clear();
                foreach (var project in DataStorage.Projects)
                {
                    dataGridView1.Rows.Add(project.Key, project.Value.Name, $"{project.Value.Operations.Count} операций");
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                buttonDeleteProject.Visible = false;
                tableLayoutPanel1.Visible = true;
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int projectId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

                OpenProjectPage(projectId);
            }
        }
        private void OpenProjectPage(int projectId)
        {
            var projectPage = new ProjectControl(projectId);
            projectPage.Tag = DataStorage.Projects[projectId].Name;
            Form1 form = Application.OpenForms["Form1"] as Form1;
            form?.HideSideMenu();
            form.OpenPage(projectPage);
        }
        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            ProjectAdd projectAdd = new ProjectAdd();
            projectAdd.ShowDialog();
            LoadProjects();
        }
        private void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранные проекты?", "Подтверждение",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int projectId = (int)row.Cells[0].Value;
                        var project = DataStorage.Projects[projectId];
                        foreach (var op in project.Operations)
                        DataStorage.Operations.Remove(op.Id);
                        DataStorage.Projects.Remove(projectId);
                        LoadProjects();
                    }
                }
            }
            
        }

    }
}
