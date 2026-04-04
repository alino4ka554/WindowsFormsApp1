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

            dataGridView1.Columns.Add(btnColumn);

            // заполняем строки
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add($"Проект {i + 1}", 10);
            }
        }
        
    }
}
