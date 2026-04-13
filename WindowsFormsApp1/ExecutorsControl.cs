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
    public partial class ExecutorsControl : UserControl
    {
        public ExecutorsControl()
        {
            InitializeComponent();
            if(DataStorage.Executors.Count > 0)
                LoadExecutors();
            else
            {
                dataGridView1.Visible = false;
                Label label = new Label();
                label.Text = "Пока нет исполнителей";
                label.Font = new Font("Calibri", 14, FontStyle.Bold);
                panel4.Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
        }
        public void LoadExecutors()
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            foreach (var executor in DataStorage.Executors)
            {
                dataGridView1.Rows.Add(executor.Key, $"{executor.Value.Name}");
            }
            dataGridView1.ClearSelection();
        }
        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            ExecutorAdd executorAdd = new ExecutorAdd();
            executorAdd.ShowDialog();
            LoadExecutors();
        }
    }
}
