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
            this.Resize += panelMain_Resize;
        }
        private void LoadProjects()
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                var item = new ProjectItemControl("Проект A", 10);
                flowLayoutPanel1.Controls.Add(item);
            }
        }
        private void panelMain_Resize(object sender, EventArgs e)
        {
            int width = this.Width;

            if (width < 800)
                panel1.Width = width - 40;
            else if (width < 1200)
                panel1.Width = 700;
            else
                panel1.Width = 900;


            this.panel1.Left = (this.Width - this.panel1.Width) / 2;
            this.panel1.Top = 80;
        }
    }
}
