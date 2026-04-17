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
    public partial class Form1 : Form
    {
        public Panel MainPanel => panel2;
        private UserControl CurrentControl;
        public Form1()
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
            if (DataStorage.Operations.Count == 0)
                HideBuildSolution();
            else 
                ShowBuildSolution();
        }
        public void HideSideMenu()
        {
            panel1.Visible = false;
        }
        public void HideBuildSolution()
        {
            buttonBuildSolution.Visible = false;
        }
        public void ShowBuildSolution()
        {
            buttonBuildSolution.Visible = true;
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
        public static List<Operation> LoadOperationsFromExcel(string path)
        {
            var operations = new List<Operation>();
            Workbook wb = new Workbook(path);
            WorksheetCollection collection = wb.Worksheets;
            for (int worksheetIndex = 0; worksheetIndex < 1; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                Dictionary<string, Resource> ExecutorsByName = new Dictionary<string, Resource>();
                Dictionary<string, Project> ProjectsByName = new Dictionary<string, Project>();
                for (int i = 1; i <= rows; i++)
                {
                    var preds = new List<int>();
                    var cellValue = worksheet.Cells[i, 1].Value?.ToString().Trim();
                    if (!string.IsNullOrEmpty(cellValue) && cellValue != "-")
                    {
                        preds = cellValue
                            .Split(',')                        // разделяем по запятой
                            .Select(x => x.Trim())             // убираем пробелы
                            .Where(x => int.TryParse(x, out _))// оставляем только корректные числа
                            .Select(int.Parse)                 // переводим в int
                            .ToList();
                    }
                    cellValue = worksheet.Cells[i, 3].Value?.ToString();
                    var resName = int.TryParse(cellValue, out var rsVal)
                        ? $"Исполнитель {rsVal}"
                        : cellValue;
                    cellValue = worksheet.Cells[i, 2].Value?.ToString();
                    var projName = int.TryParse(cellValue, out var prVal)
                        ? $"Проект {prVal}"
                        : cellValue;
                    if (!ExecutorsByName.ContainsKey(resName))
                    {
                        int idRes = DataStorage.Executors.Count() + 1; 
                        var newRes = new Resource(idRes, resName);
                        DataStorage.Executors[idRes] = newRes;
                        ExecutorsByName.Add(resName, newRes);
                    }
                    if (!ProjectsByName.ContainsKey(projName))
                    {
                        int idProj = DataStorage.Projects.Count() + 1;
                        var newProj = new Project(idProj, new List<Operation>(), projName);
                        DataStorage.Projects[idProj] = newProj;
                        ProjectsByName.Add(projName, newProj);
                    }
                    var op = new Operation
                    {
                        Id = DataStorage.Operations.Count() + 1,
                        Name = worksheet.Cells[i, 0].Value?.ToString(),
                        DependsOn = preds,
                        Resource = ExecutorsByName[resName].Id,
                        Project = ProjectsByName[projName].Id,
                        NormalTime = double.TryParse(worksheet.Cells[i, 4].Value?.ToString(), out var ntVal) ? ntVal : 0,
                        CrashTime = double.TryParse(worksheet.Cells[i, 5].Value?.ToString(), out var ctVal) ? ctVal : 0,
                        NormalCost = double.TryParse(worksheet.Cells[i, 6].Value?.ToString(), out var ncVal) ? ncVal : 0,
                        CrashCost = double.TryParse(worksheet.Cells[i, 7].Value?.ToString(), out var ccVal) ? ccVal : 0,

                    };
                    
                    operations.Add(op);
                    DataStorage.Operations[op.Id] = op;
                    DataStorage.Projects[op.Project].Operations.Add(op);
                }
            }
            return operations;
        }

        private async void buttonBuildSolution_Click(object sender, EventArgs e)
        {
            BuildScheduleForm form = new BuildScheduleForm();
            form.ShowDialog();
            if(CurrentControl is ScheduleControl sch)
            {
                OpenPage(new ScheduleControl());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Выберите файл Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadOperationsFromExcel(filePath);
                    MessageBox.Show($"Выбран файл: {filePath}");
                    switch(CurrentControl)
                    {
                        case ProjectsControl _:
                            OpenPage(new ProjectsControl());
                            break;
                        case ExecutorsControl _:
                            OpenPage(new ExecutorsControl());
                            break;
                        case ScheduleControl _:
                            OpenPage(new ScheduleControl());
                            break;
                        default:
                            break;
                    }
                }
            }
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
