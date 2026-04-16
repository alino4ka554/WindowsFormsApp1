namespace WindowsFormsApp1
{
    partial class BuildScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelAnts = new System.Windows.Forms.Label();
            this.labelIterations = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.numericUpDownIterations = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAnts = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.labelBeta = new System.Windows.Forms.Label();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.labelRho = new System.Windows.Forms.Label();
            this.numericUpDownRho = new System.Windows.Forms.NumericUpDown();
            this.labelPheromone = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRho)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(46, 390);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(605, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(46, 390);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(46, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(559, 44);
            this.panel4.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(46, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 44);
            this.panel1.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(46, 303);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(559, 43);
            this.panel5.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonSave, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(559, 43);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.BackColor = System.Drawing.Color.Black;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(214, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(131, 34);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Построить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAlpha, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelAnts, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelIterations, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownIterations, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAnts, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAlpha, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelBeta, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownBeta, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelRho, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownRho, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelPheromone, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 259);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Location = new System.Drawing.Point(282, 3);
            this.dateTimePicker1.MinDate = new System.DateTime(2026, 4, 13, 20, 13, 10, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(274, 22);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Value = new System.DateTime(2026, 4, 13, 20, 13, 10, 0);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlpha.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAlpha.Location = new System.Drawing.Point(3, 104);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(273, 38);
            this.labelAlpha.TabIndex = 9;
            this.labelAlpha.Text = "Параметр Альфа";
            // 
            // labelAnts
            // 
            this.labelAnts.AutoSize = true;
            this.labelAnts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAnts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAnts.Location = new System.Drawing.Point(3, 66);
            this.labelAnts.Name = "labelAnts";
            this.labelAnts.Size = new System.Drawing.Size(273, 38);
            this.labelAnts.TabIndex = 4;
            this.labelAnts.Text = "Количество муравьев";
            // 
            // labelIterations
            // 
            this.labelIterations.AutoSize = true;
            this.labelIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterations.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIterations.Location = new System.Drawing.Point(3, 28);
            this.labelIterations.Name = "labelIterations";
            this.labelIterations.Size = new System.Drawing.Size(273, 38);
            this.labelIterations.TabIndex = 2;
            this.labelIterations.Text = "Количество итераций";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.Location = new System.Drawing.Point(3, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(116, 24);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Дата начала";
            // 
            // numericUpDownIterations
            // 
            this.numericUpDownIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownIterations.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownIterations.Location = new System.Drawing.Point(282, 31);
            this.numericUpDownIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIterations.Name = "numericUpDownIterations";
            this.numericUpDownIterations.Size = new System.Drawing.Size(274, 32);
            this.numericUpDownIterations.TabIndex = 7;
            this.numericUpDownIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownAnts
            // 
            this.numericUpDownAnts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownAnts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownAnts.Location = new System.Drawing.Point(282, 69);
            this.numericUpDownAnts.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAnts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAnts.Name = "numericUpDownAnts";
            this.numericUpDownAnts.Size = new System.Drawing.Size(274, 32);
            this.numericUpDownAnts.TabIndex = 8;
            this.numericUpDownAnts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.DecimalPlaces = 2;
            this.numericUpDownAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownAlpha.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownAlpha.Location = new System.Drawing.Point(282, 107);
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(274, 32);
            this.numericUpDownAlpha.TabIndex = 12;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBeta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBeta.Location = new System.Drawing.Point(3, 142);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(273, 38);
            this.labelBeta.TabIndex = 13;
            this.labelBeta.Text = "Параметр Бета";
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.DecimalPlaces = 2;
            this.numericUpDownBeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownBeta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownBeta.Location = new System.Drawing.Point(282, 145);
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(274, 32);
            this.numericUpDownBeta.TabIndex = 14;
            this.numericUpDownBeta.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelRho
            // 
            this.labelRho.AutoSize = true;
            this.labelRho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRho.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRho.Location = new System.Drawing.Point(3, 180);
            this.labelRho.Name = "labelRho";
            this.labelRho.Size = new System.Drawing.Size(273, 38);
            this.labelRho.TabIndex = 15;
            this.labelRho.Text = "Коэффициент испарения";
            // 
            // numericUpDownRho
            // 
            this.numericUpDownRho.DecimalPlaces = 2;
            this.numericUpDownRho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownRho.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRho.Location = new System.Drawing.Point(282, 183);
            this.numericUpDownRho.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownRho.Name = "numericUpDownRho";
            this.numericUpDownRho.Size = new System.Drawing.Size(274, 32);
            this.numericUpDownRho.TabIndex = 16;
            this.numericUpDownRho.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // labelPheromone
            // 
            this.labelPheromone.AutoSize = true;
            this.labelPheromone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPheromone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPheromone.Location = new System.Drawing.Point(3, 218);
            this.labelPheromone.Name = "labelPheromone";
            this.labelPheromone.Size = new System.Drawing.Size(273, 44);
            this.labelPheromone.TabIndex = 17;
            this.labelPheromone.Text = "Уровень феромона";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownMax, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownMin, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(282, 221);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 38);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.DecimalPlaces = 2;
            this.numericUpDownMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMax.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownMax.Location = new System.Drawing.Point(185, 3);
            this.numericUpDownMax.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownMax.Name = "numericUpDownMax";
            this.numericUpDownMax.Size = new System.Drawing.Size(88, 32);
            this.numericUpDownMax.TabIndex = 18;
            this.numericUpDownMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.DecimalPlaces = 2;
            this.numericUpDownMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownMin.Location = new System.Drawing.Point(47, 3);
            this.numericUpDownMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(88, 32);
            this.numericUpDownMin.TabIndex = 17;
            this.numericUpDownMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "от";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(141, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "до";
            // 
            // BuildScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(651, 390);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "BuildScheduleForm";
            this.Text = "BuildScheduleForm";
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRho)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelAnts;
        private System.Windows.Forms.Label labelIterations;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.NumericUpDown numericUpDownIterations;
        private System.Windows.Forms.NumericUpDown numericUpDownAnts;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.Label labelRho;
        private System.Windows.Forms.NumericUpDown numericUpDownRho;
        private System.Windows.Forms.Label labelPheromone;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownMax;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonSave;
    }
}