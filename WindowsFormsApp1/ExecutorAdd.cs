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
            DataStorage.Executors.Add(new Resource(DataStorage.Executors.Count + 1, textBoxName.Text));
        }
    }
}
