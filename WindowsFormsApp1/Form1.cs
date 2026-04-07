using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Panel MainPanel => panel2;
        public Label Header => labelHeader;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearMainPanel();
            SetActiveButton(button1);
            ProjectsControl projects = new ProjectsControl();
            projects.Dock = DockStyle.Fill;
            panel2.Controls.Add(projects);
            projects.LoadProjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {// добавляем колонки (дни)
            string filePath = "operations.xlsx";
            var ops = LoadOperationsFromExcel(filePath);
            var operations = ops.ToDictionary(op => op.Id);
            var colony = new ACO(ops, iterations: 1000, ants: 100,
                                       beta: 2, alpha: 10, rho: 0.5,
                                       tauMin: 0.01, tauMax: 1.0);
            colony.Run();
            ClearMainPanel();
            SetActiveButton(button4);
            GanttChartControl ganttChart = new GanttChartControl();
            ganttChart.Dock = DockStyle.Fill;
            panel2.Controls.Add(ganttChart);
            ganttChart.LoadGanttChart(colony.BestSolution, colony._projectsOperations);
           
        }
        public void HideSideMenu()
        {
            panel1.Visible = false;
        }

        public void HideButtonBack()
        {
            buttonBack.Visible = false;
        }
        public void ShowButtonBack()
        {
            buttonBack.Visible = true;
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
            ClearMainPanel();
            ShowSideMenu();
            Header.Text = "Проекты";
            ProjectsControl projects = new ProjectsControl();
            projects.Dock = DockStyle.Fill;
            panel2.Controls.Add(projects);
            projects.LoadProjects();
            HideButtonBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            ClearMainPanel();
            ExecutorsControl executors = new ExecutorsControl();
            executors.Dock = DockStyle.Fill;
            panel2.Controls.Add(executors);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton(button3);
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

                    var op = new Operation
                    {
                        Id = int.TryParse(worksheet.Cells[i, 0].Value?.ToString(), out var idVal) ? idVal : 0,
                        DependsOn = preds,
                        Resource = int.TryParse(worksheet.Cells[i, 3].Value?.ToString(), out var resVal) ? resVal : 0,
                        Project = int.TryParse(worksheet.Cells[i, 2].Value?.ToString(), out var prVal) ? prVal : 0,
                        NormalTime = double.TryParse(worksheet.Cells[i, 4].Value?.ToString(), out var ntVal) ? ntVal : 0,
                        CrashTime = double.TryParse(worksheet.Cells[i, 5].Value?.ToString(), out var ctVal) ? ctVal : 0,
                        NormalCost = double.TryParse(worksheet.Cells[i, 6].Value?.ToString(), out var ncVal) ? ncVal : 0,
                        CrashCost = double.TryParse(worksheet.Cells[i, 7].Value?.ToString(), out var ccVal) ? ccVal : 0,

                    };
                    operations.Add(op);
                }
            }
            return operations;
        }
    }
}
