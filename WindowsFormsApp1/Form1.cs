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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectsControl projects = new ProjectsControl();
            projects.Dock = DockStyle.Fill;
            panel2.Controls.Add(projects);
            projects.LoadProjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {// добавляем колонки (дни)
            

        }
    }
}
