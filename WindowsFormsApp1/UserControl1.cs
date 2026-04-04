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
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            //this.Resize += panelMain_Resize;
        }
        public void LoadProjects()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // обычные колонки
            dataGridView1.Columns.Add("Name", "Проект");
            dataGridView1.Columns.Add("Tasks", "Кол-во задач");

            // колонка с кнопкой
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Edit";
            btnColumn.HeaderText = "";
            btnColumn.Text = "Редактировать";
            btnColumn.UseColumnTextForButtonValue = true;
            btnColumn.DefaultCellStyle.BackColor = Color.White;
            btnColumn.DefaultCellStyle.ForeColor = Color.White;
            btnColumn.DefaultCellStyle.SelectionBackColor = Color.Gray;
            btnColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            

            dataGridView1.Columns.Add(btnColumn);
            // заполняем строки
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add($"Проект {i + 1}", 10);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // защита от клика по заголовку
            if (e.RowIndex < 0) return;

            // проверяем, что нажали именно на колонку с кнопкой
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                // получаем данные проекта (например имя)
                string projectName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                // открываем страницу проекта
                OpenProjectPage(projectName);
            }
        }
        private void OpenProjectPage(string projectName)
        {
            var projectPage = new ProjectControl();

            Form1 form = Application.OpenForms["Form1"] as Form1;
            form?.HideSideMenu();
            form?.ClearMainPanel();
            form?.ShowButtonBack();
            form.Header.Text = projectName;
            form.MainPanel.Controls.Add(projectPage);
            projectPage.Dock = DockStyle.Fill;
        }
    }
}
