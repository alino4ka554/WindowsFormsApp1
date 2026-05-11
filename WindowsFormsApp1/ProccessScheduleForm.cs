using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProccessScheduleForm : Form
    {
        private readonly ScheduleService _service;
        private readonly ScheduleBuildParams _params;
        public ProccessScheduleForm(ScheduleService service, ScheduleBuildParams parameters)
        {
            InitializeComponent();
            _service = service;
            _params = parameters;
        }
        private async void ProccessScheduleForm_Load(object sender, EventArgs e)
        {
            await BuildSchedule();
            this.Close();
        }
        public async Task BuildSchedule()
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = _params.Iterations;
            progressBar1.Visible = true;

            var progress = new Progress<int>(value =>
            {
                progressBar1.Value = value;
            });
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.Run(() =>
            {
                _service.BuildSchedule(_params, progress);
            });
            stopwatch.Stop();
            progressBar1.Visible = false;
            double seconds = stopwatch.Elapsed.TotalSeconds;

            MessageBox.Show(
                $"Расписание построено за {seconds:F2} сек.",
                "Время выполнения",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
