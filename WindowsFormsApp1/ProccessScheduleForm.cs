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
    public partial class ProccessScheduleForm : Form
    {
        ACO antColony;
        public ProccessScheduleForm(ACO colony)
        {
            InitializeComponent();
            antColony = colony;
        }
        private async void ProccessScheduleForm_Load(object sender, EventArgs e)
        {
            await BuildSchedule();
            this.Close();
        }
        public async Task BuildSchedule()
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = antColony._iterations;
            progressBar1.Visible = true;

            var progress = new Progress<int>(value =>
            {
                progressBar1.Value = value;
            });

            await Task.Run(() =>
            {
                antColony.Run(progress);
            });

            progressBar1.Visible = false;
        }
    }
}
