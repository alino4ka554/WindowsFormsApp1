using Aspose.Cells;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public Panel MainPanel => panel2;
        private UserControl CurrentControl;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(button1);
            ProjectsControl projects = new ProjectsControl();
            OpenPage(projects);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveButton(button4);
            GanttChartControl ganttChart = new GanttChartControl();
            OpenPage(ganttChart);
        }
        public void OpenPage(UserControl userControl)
        {
            ClearMainPanel();
            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(userControl);
            CurrentControl = userControl;
        }
        public void HideSideMenu()
        {
            panel1.Visible = false;
        }
        public void ShowSideMenu()
        {
            panel1.Visible = true;
        }
        public void ClearMainPanel()
        {
            MainPanel.Controls.Clear();
        }
        private void ResetMenuButtons()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.LightGray;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.MouseOverBackColor = Color.Silver;
                }
            }
        }
        private void SetActiveButton(Button btn)
        {
            ResetMenuButtons();
            btn.BackColor = Color.Silver;
            btn.Cursor = Cursors.Default;
            btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ShowSideMenu();
            ProjectsControl projects = new ProjectsControl();
            OpenPage(projects);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            ExecutorsControl executors = new ExecutorsControl();
            OpenPage(executors);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton(button3);
            ScheduleControl schedules = new ScheduleControl();
            OpenPage(schedules);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(DataStorage.Solution, "schedule.xlsx");
        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            ProjectAdd projectAdd = new ProjectAdd();
            projectAdd.ShowDialog();
            if (DataStorage.Projects.Count > 0)
            {
                OpenPage(new ProjectsControl()); 
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ExecutorAdd executorAdd = new ExecutorAdd();
            executorAdd.ShowDialog();
            if (DataStorage.Executors.Count > 0)
            {
                OpenPage(new ExecutorsControl());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Выберите файл Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        ExcelImporter.LoadOperationsFromExcel(filePath);
                        MessageBox.Show(
                            "Файл успешно импортирован!",
                            "Готово",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        OpenPage(new ProjectsControl());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Ошибка при импорте:\n" + ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
    public static class ImageHelper
    {
        public static Image MakeGrayscale(Image original)
        {
            if (original == null) return null;

            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                new float[] {0,     0,     0,     1, 0},
                new float[] {0,     0,     0,     0, 1}
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return newBitmap;
        }
    }
}
