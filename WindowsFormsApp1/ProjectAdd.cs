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
            var project = new Project(DataStorage.Projects.Count + 1, new List<Operation>(), textBoxName.Text);
            DataStorage.Projects.Add(project.Id, project);
            this.Close();
        }
    }
}
