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
            if (DataStorage.Projects.Count > 0)
                LoadProjects();
            else
            {
                dataGridView1.Visible = false;
                Label label = new Label();
                label.Text = "Пока нет проектов";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
                panel4.Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

        }
        public void LoadProjects()
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            foreach (var project in DataStorage.Projects)
            {
                dataGridView1.Rows.Add(project.Key, project.Value.Name, $"{project.Value.Operations.Count} операций");
            }
            dataGridView1.ClearSelection();

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
            form?.ShowButtonBack();
            form.OpenPage(projectPage);
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            ProjectAdd projectAdd = new ProjectAdd();
            projectAdd.ShowDialog();
            LoadProjects();
        }
    }
}
