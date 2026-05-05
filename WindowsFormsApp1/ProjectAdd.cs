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
    public partial class ProjectAdd : Form
    {
        public ProjectAdd()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var project = new Project(DataManager.Instance.GetNextProjectId(), new List<Operation>(), textBoxName.Text);
                DataManager.Instance.AddProject(project);
                this.Close();
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
                MessageBox.Show("Введите название проекта!", "Ошибка добавления проекта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else 
                return true;
            return false;
        }
    }
}
