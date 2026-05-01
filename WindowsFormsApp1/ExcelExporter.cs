using Aspose.Cells.Charts;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class ExcelExporter
    {
        public static void ExportToExcel(ScheduleSolution solution, string path)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Alina");

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Schedule");

                // Заголовки
                sheet.Cells[1, 1].Value = "Operation";
                sheet.Cells[1, 2].Value = "Resource";
                sheet.Cells[1, 3].Value = "Start";
                sheet.Cells[1, 4].Value = "Duration";

                var operations = solution.Operations.Values
                    .OrderByDescending(o => o.Resource)
                    .ThenBy(o => o.StartTime)
                    .ToList();

                // Заполнение таблицы
                for (int i = 0; i < operations.Count; i++)
                {
                    var op = operations[i];

                    sheet.Cells[i + 2, 1].Value = $"Op {op.Id}";
                    sheet.Cells[i + 2, 2].Value = op.Resource;
                    sheet.Cells[i + 2, 3].Value = op.StartTime;
                    sheet.Cells[i + 2, 4].Value = op.ActualTime; // ← исправлено
                }

                int rowCount = operations.Count;

                // 📊 Диаграмма Гантта
                var chart = sheet.Drawings.AddChart("GanttChart", eChartType.BarStacked) as ExcelBarChart;

                chart.Title.Text = "Gantt Chart";
                chart.SetPosition(1, 0, 5, 0);
                chart.SetSize(800, 400);

                // Start (смещение)
                var startSeries = chart.Series.Add(
                    sheet.Cells[2, 3, rowCount + 1, 3],
                    sheet.Cells[2, 1, rowCount + 1, 1]
                );
                startSeries.Header = "Start";

                // Duration
                var durationSeries = chart.Series.Add(
                    sheet.Cells[2, 4, rowCount + 1, 4],
                    sheet.Cells[2, 1, rowCount + 1, 1]
                );
                durationSeries.Header = "Duration";

                // делаем старт невидимым
                startSeries.Fill.Style = OfficeOpenXml.Drawing.eFillStyle.NoFill;

                // переворачиваем ось (правильно для EPPlus)
                //chart.YAxis.ReverseOrder = true;

                // сохраняем
                File.WriteAllBytes(path, package.GetAsByteArray());
            }
        }
    }
}
