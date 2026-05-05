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
            LoadExecutors();
        }
        public void LoadExecutors()
        {
            if (DataStorage.Executors.Count > 0)
            {
                buttonDeleteProject.Visible = true;
                tableLayoutPanel1.Visible = false;
                dataGridView1.Rows.Clear();
                foreach (var executor in DataStorage.Executors)
                {
                    dataGridView1.Rows.Add(executor.Key, $"{executor.Value.Name}");
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                buttonDeleteProject.Visible = false;
                tableLayoutPanel1.Visible = true;
            }
        }
        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            ExecutorAdd executorAdd = new ExecutorAdd();
            executorAdd.ShowDialog();
            LoadExecutors();
        }

        private void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранных исполнителей и все их задачи?", "Подтверждение",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int executorId = (int)row.Cells[0].Value;
                        var executor = DataStorage.Executors[executorId];
                        DataManager.Instance.DeleteExecutor(executor);
                        LoadExecutors();
                    }
                }
            }
        }
    }
}
