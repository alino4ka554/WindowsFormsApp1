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
        public Panel MainPanel => panel2;
        public Label Header => labelHeader;
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
        public void HideSideMenu()
        {
            panel1.Visible = false;
        }

        public void HideButtonBack()
        {
            buttonBack.Visible = false;
        }
        public void ShowButtonBack()
        {
            buttonBack.Visible = true;
        }
        public void ShowSideMenu()
        {
            panel1.Visible = true;
        }
        public void ClearMainPanel()
        {
            MainPanel.Controls.Clear();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClearMainPanel();
            ShowSideMenu();
            ProjectsControl projects = new ProjectsControl();
            projects.Dock = DockStyle.Fill;
            panel2.Controls.Add(projects);
            projects.LoadProjects();
            HideButtonBack();
        }
    }
}
