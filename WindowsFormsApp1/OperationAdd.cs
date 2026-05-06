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
    public partial class OperationAdd : Form
    {
        public int ProjectId;
        RangeTrackBar sliderTime = new RangeTrackBar(1, 100);
        RangeTrackBar sliderCost = new RangeTrackBar(0, 100000);
        NumericUpDown numericUpDownFromTime = new NumericUpDown {Width = 50 };
        NumericUpDown numericUpDownToTime = new NumericUpDown { Width = 50 };
        NumericUpDown numericUpDownFromCost = new NumericUpDown { Width = 50 };
        NumericUpDown numericUpDownToCost = new NumericUpDown{ Width = 50 };
        public OperationAdd(int _projectId)
        {
            InitializeComponent();
            /*label1.Text = sliderTime.LowerValue.ToString();
            label2.Text = sliderTime.UpperValue.ToString();
            label3.Text = sliderCost.LowerValue.ToString();
            label4.Text = sliderCost.UpperValue.ToString();
            sliderTime.Dock = DockStyle.Fill;
            sliderCost.Dock = DockStyle.Fill;
            panel5.Controls.Add(sliderTime);
            panel6.Controls.Add(sliderCost);*/
            ProjectId = _projectId;
           
            InitializeRangeTrackBar(sliderTime, numericUpDownFromTime, numericUpDownToTime, panel5);
            InitializeRangeTrackBar(sliderCost, numericUpDownFromCost, numericUpDownToCost, panel6);
            GetExecutors();
            GetPredecessors();
        }
        public void InitializeRangeTrackBar(RangeTrackBar slider, NumericUpDown numFrom, NumericUpDown numTo, Panel panel)
        {
            numFrom.Minimum = slider.Minimum;
            numFrom.Maximum = slider.Maximum;

            numTo.Minimum = slider.Minimum;
            numTo.Maximum = slider.Maximum;

            numFrom.Value = slider.LowerValue;
            numTo.Value = slider.UpperValue;

            slider.Dock = DockStyle.Fill;
            numFrom.Dock = DockStyle.Left;
            numTo.Dock = DockStyle.Right;
            panel.Controls.Add(slider);
            panel.Controls.Add(numFrom);
            panel.Controls.Add(numTo);
            numFrom.ValueChanged += (s, e) =>
            {
                if (numFrom.Value > numTo.Value)
                    numTo.Value = numFrom.Value;

                slider.LowerValue = (int)numFrom.Value;
                slider.UpperValue = (int)numTo.Value;

                slider.Invalidate();
            };

            numTo.ValueChanged += (s, e) =>
            {
                if (numTo.Value < numFrom.Value)
                    numFrom.Value = numTo.Value;

                slider.LowerValue = (int)numFrom.Value;
                slider.UpperValue = (int)numTo.Value;

                slider.Invalidate();
            };
            slider.ValuesChanged += (s, e) =>
            {
                numFrom.Value = slider.LowerValue;
                numTo.Value = slider.UpperValue;
            };
        }
        public void GetExecutors()
        {
            comboBoxExecutors.DataSource = DataStorage.Executors.Values.ToList();
            comboBoxExecutors.DisplayMember = "Name";
            comboBoxExecutors.ValueMember = "Id";
        }
        public void GetPredecessors()
        {
            //var listOps = DataStorage.Projects[ProjectId].Operations;
            //listOps.Add(new Operation { Id = 0, Name = "- нет предшественника -" });
            checkedListBoxPrecessors.DataSource = DataStorage.Projects[ProjectId].Operations; ;
            checkedListBoxPrecessors.DisplayMember = "Name";
            checkedListBoxPrecessors.ValueMember = "Id"; 
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var preds = checkedListBoxPrecessors.CheckedItems
                    .Cast<Operation>()
                    .Select(op => op.Id)
                    .ToList();
                Operation operation = new Operation
                {
                    Id = DataManager.Instance.GetNextOperationId(),
                    Name = textBoxName.Text,
                    NormalTime = sliderTime.UpperValue,
                    CrashTime = sliderTime.LowerValue,
                    NormalCost = sliderCost.LowerValue,
                    CrashCost = sliderCost.UpperValue,
                    Project = ProjectId,
                    Resource = (int)comboBoxExecutors.SelectedValue,
                    DependsOn = preds
                };
                DataManager.Instance.AddOperation(operation);
                this.Close();
            }
        }
        private bool Validation()
        {
            var listOfErrors = new List<string>();
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
                listOfErrors.Add("Введите название задачи!");
            if (comboBoxExecutors.SelectedValue == null)
                listOfErrors.Add("Выберите исполнителя!");
            if (listOfErrors.Count > 0)
                MessageBox.Show(string.Join("\n", listOfErrors), "Ошибка добавления задачи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                return true;
            return false;

        }

    }
    public class RangeTrackBar : Control
    {
        public int Minimum;
        public int Maximum;

        public int LowerValue;
        public int UpperValue;
        int padding = 10;
        int thumbSize = 16;
        int radius => thumbSize / 2;
        public event EventHandler ValuesChanged;
        public RangeTrackBar(int min, int max)
        {
            this.Height = 32;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            Minimum = min;
            Maximum = max;
            LowerValue = Minimum;
            UpperValue = Maximum;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (draggingMin)
            {
                LowerValue = XToValue(e.X);
                if (LowerValue > UpperValue)
                    LowerValue = UpperValue;

                Invalidate();
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }

            if (draggingMax)
            {
                UpperValue = XToValue(e.X);
                if (UpperValue < LowerValue)
                    UpperValue = LowerValue;

                Invalidate();
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            int x1 = ValueToX(LowerValue);
            int x2 = ValueToX(UpperValue);
            int y = Height / 2;

            g.DrawLine(Pens.Gray,
                padding + radius,
                y,
                Width - padding - radius,
                y);
            g.FillRectangle(Brushes.LightBlue,
                x1,
                y - 2,
                x2 - x1,
                4);

            g.FillEllipse(Brushes.Blue,
                x1 - radius,
                y - radius,
                thumbSize,
                thumbSize);

            g.FillEllipse(Brushes.Blue,
                x2 - radius,
                y - radius,
                thumbSize,
                thumbSize);
        }
        private int ValueToX(int value)
        {
            int trackWidth = Width - 2 * (padding + radius);
            return padding + radius + (value - Minimum) * trackWidth / (Maximum - Minimum);
        }
        private bool draggingMin = false;
        private bool draggingMax = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x1 = ValueToX(LowerValue);
            int x2 = ValueToX(UpperValue);

            if (Math.Abs(e.X - x1) < 10)
                draggingMin = true;
            else if (Math.Abs(e.X - x2) < 10)
                draggingMax = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            draggingMin = false;
            draggingMax = false;
        }

        private int XToValue(int x)
        {
            int trackWidth = Width - 2 * (padding + radius);

            int value = Minimum + (x - (padding + radius)) * (Maximum - Minimum) / trackWidth;

            if (value < Minimum) value = Minimum;
            if (value > Maximum) value = Maximum;

            return value;
        }
    }
}
