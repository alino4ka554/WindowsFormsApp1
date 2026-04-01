using System.Drawing;

namespace WindowsFormsApp1
{
    partial class ProjectsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddProject = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(89, 108);
            this.panel1.MaximumSize = new System.Drawing.Size(1500, 800);
            this.panel1.MinimumSize = new System.Drawing.Size(600, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 1;
            this.panel1.Resize += new System.EventHandler(this.panelMain_Resize);
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.BackColor = System.Drawing.Color.Black;
            this.buttonAddProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddProject.FlatAppearance.BorderSize = 0;
            this.buttonAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProject.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddProject.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAddProject.Location = new System.Drawing.Point(89, 540);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(146, 36);
            this.buttonAddProject.TabIndex = 2;
            this.buttonAddProject.Text = "Добавить";
            this.buttonAddProject.UseVisualStyleBackColor = false;
            // 
            // ProjectsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddProject);
            this.Controls.Add(this.panel1);
            this.Name = "ProjectsControl";
            this.Size = new System.Drawing.Size(828, 613);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddProject;
    }
}
