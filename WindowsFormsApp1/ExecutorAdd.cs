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
    public partial class ExecutorAdd : Form
    {
        public ExecutorAdd()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var executor = new Resource(DataStorage.Executors.Count + 1, textBoxName.Text);
                DataStorage.Executors.Add(executor.Id, executor);
                this.Close();
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
                MessageBox.Show("Введите ФИО исполнителя!", "Ошибка добавления исполнителя", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                return true;
            return false;
        }
    }
}
