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
        RangeTrackBar sliderTime = new RangeTrackBar();
        RangeTrackBar sliderCost = new RangeTrackBar();
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
            InitializeRangeTrackBar(sliderTime, label1, label2, panel5);
            InitializeRangeTrackBar(sliderCost, label3, label4, panel6);
            sliderTime.ValuesChanged += RangeTrackBar1_ValuesChanged;
            sliderCost.ValuesChanged += RangeTrackBar2_ValuesChanged;
            GetExecutors();
            GetPredecessors();
        }
        public void InitializeRangeTrackBar(RangeTrackBar slider, Label labelFrom, Label labelTo, Panel panel)
        {
            labelFrom.Text = slider.LowerValue.ToString();
            labelTo.Text = slider.UpperValue.ToString();
            slider.Dock = DockStyle.Fill;
            panel.Controls.Add(slider);
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
        private void RangeTrackBar1_ValuesChanged(object sender, EventArgs e)
        {
            label1.Text = sliderTime.LowerValue.ToString();
            label2.Text = sliderTime.UpperValue.ToString();
        }
        private void RangeTrackBar2_ValuesChanged(object sender, EventArgs e)
        {
            label3.Text = sliderCost.LowerValue.ToString();
            label4.Text = sliderCost.UpperValue.ToString();
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
        public int Minimum = 0;
        public int Maximum = 100;

        public int LowerValue = 20;
        public int UpperValue = 80;
        int padding = 10;
        int thumbSize = 16;
        int radius => thumbSize / 2;
        public event EventHandler ValuesChanged;
        public RangeTrackBar()
        {
            this.Height = 32;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
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
