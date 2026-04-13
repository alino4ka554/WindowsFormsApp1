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
        public BuildScheduleForm()
        {
            InitializeComponent();
            this.numericUpDownAnts.Value = DataStorage.Operations.Count();
            this.dateTimePicker1.MinDate = DateTime.Now;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckPheromone())
            {
                var operations = DataStorage.Operations;
                var colony = new ACO(operations, iterations: (int)numericUpDownIterations.Value, 
                    ants: (int)numericUpDownAnts.Value,
                    beta: (double)numericUpDownBeta.Value, alpha: (int)numericUpDownAlpha.Value, 
                    rho: (double)numericUpDownRho.Value, tauMin: (double)numericUpDownMin.Value, 
                    tauMax: (double)numericUpDownMax.Value);
                colony.Run();
                DataStorage.Solution = colony.BestSolution;
                this.Close();
            }
        }
        public bool CheckPheromone()
        {
            if (numericUpDownMax.Value > numericUpDownMin.Value)
                return true;
            else
                MessageBox.Show("Максимальный уровень феромона должен быть больше минимального");
            return false;

        }
    }
}
