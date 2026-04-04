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
        public ProjectControl()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add($"Проект {i + 1}", 10);
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            OperationAdd operationAdd = new OperationAdd();
            operationAdd.ShowDialog();
        }
    }
}
