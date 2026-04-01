namespace WindowsFormsApp1
{
    partial class ProjectItemControl
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelOperations = new System.Windows.Forms.Label();
            this.buttonEditProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(64, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(61, 24);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "label1";
            // 
            // labelOperations
            // 
            this.labelOperations.AutoSize = true;
            this.labelOperations.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOperations.Location = new System.Drawing.Point(386, 22);
            this.labelOperations.Name = "labelOperations";
            this.labelOperations.Size = new System.Drawing.Size(61, 24);
            this.labelOperations.TabIndex = 1;
            this.labelOperations.Text = "label1";
            // 
            // buttonEditProject
            // 
            this.buttonEditProject.BackColor = System.Drawing.Color.DimGray;
            this.buttonEditProject.FlatAppearance.BorderSize = 0;
            this.buttonEditProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProject.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditProject.ForeColor = System.Drawing.Color.White;
            this.buttonEditProject.Location = new System.Drawing.Point(666, 16);
            this.buttonEditProject.Name = "buttonEditProject";
            this.buttonEditProject.Size = new System.Drawing.Size(99, 36);
            this.buttonEditProject.TabIndex = 2;
            this.buttonEditProject.Text = "button1";
            this.buttonEditProject.UseVisualStyleBackColor = false;
            // 
            // ProjectItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.buttonEditProject);
            this.Controls.Add(this.labelOperations);
            this.Controls.Add(this.labelName);
            this.Name = "ProjectItemControl";
            this.Size = new System.Drawing.Size(828, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelOperations;
        private System.Windows.Forms.Button buttonEditProject;
    }
}
