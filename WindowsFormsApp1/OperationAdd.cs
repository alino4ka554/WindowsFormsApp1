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
        RangeTrackBar sliderTime = new RangeTrackBar();
        RangeTrackBar sliderCost = new RangeTrackBar();
        public OperationAdd()
        {
            InitializeComponent();
            label1.Text = sliderTime.LowerValue.ToString();
            label2.Text = sliderTime.UpperValue.ToString();
            label3.Text = sliderCost.LowerValue.ToString();
            label4.Text = sliderCost.UpperValue.ToString();
            sliderTime.Dock = DockStyle.Fill;
            sliderCost.Dock = DockStyle.Fill;
            panel5.Controls.Add(sliderTime);
            panel6.Controls.Add(sliderCost);
            sliderTime.ValuesChanged += RangeTrackBar1_ValuesChanged;
            sliderCost.ValuesChanged += RangeTrackBar2_ValuesChanged;
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
            Operation operation = new Operation
            {
                Name = textBoxName.Text,
                NormalTime = sliderTime.LowerValue,
                CrashTime = sliderTime.UpperValue,
                NormalCost = sliderCost.LowerValue,
                CrashCost = sliderCost.UpperValue
            };
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

            // линия
            g.DrawLine(Pens.Gray,
                padding + radius,
                y,
                Width - padding - radius,
                y);

            // диапазон
            g.FillRectangle(Brushes.LightBlue,
                x1,
                y - 2,
                x2 - x1,
                4);

            // кружки
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

            // ограничение
            if (value < Minimum) value = Minimum;
            if (value > Maximum) value = Maximum;

            return value;
        }
    }
}
