using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class BuildScheduleForm : Form
    {
        private readonly ScheduleService _service;
        public BuildScheduleForm(ScheduleService service)
        {
            InitializeComponent();
            _service = service;
            this.numericUpDownAnts.Value = DataStorage.Operations.Count();
            this.dateTimePicker1.MinDate = DateTime.Now;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var parameters = new ScheduleBuildParams
                {
                    Iterations = (int)numericUpDownIterations.Value,
                    Ants = (int)numericUpDownAnts.Value,
                    Beta = (double)numericUpDownBeta.Value,
                    Alpha = (double)numericUpDownAlpha.Value,
                    Rho = (double)numericUpDownRho.Value,
                    TauMin = (double)numericUpDownMin.Value,
                    TauMax = (double)numericUpDownMax.Value
                };
                DataStorage.dateTime = dateTimePicker1.Value;
                ProccessScheduleForm proccessScheduleForm = new ProccessScheduleForm(_service, parameters);
                
                proccessScheduleForm.ShowDialog();
                this.Close();
            }
        }
        public bool Validation()
        {
            if (numericUpDownMax.Value > numericUpDownMin.Value)
                return true;
            else
                MessageBox.Show("Максимальный уровень феромона должен быть больше минимального");
            return false;

        }
    }
}
