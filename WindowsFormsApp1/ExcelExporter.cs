using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public static class ExcelExporter
    {
        public static void ExportToExcel(ScheduleSolution solution, string path)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Alina");

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Расписание");

                // =========================
                // 🔹 ЗАГОЛОВКИ
                // =========================
                string[] headers = {
                    "Задача", "Проект", "Исполнитель",
                    "Дата начала", "Длительность",
                    "Дата окончания", "Смещение (дни)"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    sheet.Cells[1, i + 1].Value = headers[i];
                }

                var operations = solution.Operations.Values
                    .OrderBy(o => o.Resource)
                    .ThenBy(o => o.StartTime)
                    .ToList();

                DateTime baseDate = DataStorage.dateTime;

                // =========================
                // 🔹 ДАННЫЕ
                // =========================
                for (int i = 0; i < operations.Count; i++)
                {
                    var op = operations[i];

                    DateTime startDate = baseDate.AddDays(op.StartTime);
                    DateTime endDate = startDate.AddDays(op.ActualTime);

                    int row = i + 2;

                    sheet.Cells[row, 1].Value = op.Name;
                    sheet.Cells[row, 2].Value = DataStorage.Projects[op.Project].Name;
                    sheet.Cells[row, 3].Value = DataStorage.Executors[op.Resource].Name;
                    sheet.Cells[row, 4].Value = startDate;
                    sheet.Cells[row, 5].Value = op.ActualTime;
                    sheet.Cells[row, 6].Value = endDate;
                    sheet.Cells[row, 7].Value = op.StartTime;

                    sheet.Cells[row, 4].Style.Numberformat.Format = "dd.MM.yyyy";
                    sheet.Cells[row, 6].Style.Numberformat.Format = "dd.MM.yyyy";

                    // 🔹 чередование строк
                    if (i % 2 == 0)
                    {
                        sheet.Cells[row, 1, row, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        sheet.Cells[row, 1, row, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(240, 240, 240));
                    }
                }

                int rowCount = operations.Count;

                // =========================
                // 🔥 СТИЛЬ ЗАГОЛОВКА
                // =========================
                using (var range = sheet.Cells[1, 1, 1, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // =========================
                // 🔹 ГРАНИЦЫ
                // =========================
                using (var range = sheet.Cells[1, 1, rowCount + 1, 7])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // =========================
                // 🔹 ФИЛЬТР + ЗАМОРОЗКА
                // =========================
                sheet.Cells[1, 1, rowCount + 1, 7].AutoFilter = true;
                sheet.View.FreezePanes(2, 1);

                // =========================
                // 🔥 GANTT
                // =========================
                var chart = sheet.Drawings.AddChart("Гантт", eChartType.BarStacked) as ExcelBarChart;

                chart.Title.Text = "Диаграмма Гантта";

                chart.SetPosition(6, 0, 8, 0);
                chart.SetSize(900, Math.Max(250, rowCount * 25));

                var startSeries = chart.Series.Add(
                    sheet.Cells[2, 7, rowCount + 1, 7],
                    sheet.Cells[2, 1, rowCount + 1, 1]
                );
                startSeries.Fill.Style = eFillStyle.NoFill;

                var durationSeries = chart.Series.Add(
                    sheet.Cells[2, 5, rowCount + 1, 5],
                    sheet.Cells[2, 1, rowCount + 1, 1]
                );

                durationSeries.Header = "Длительность";

                // =========================
                // 🔹 ОТЧЕТ
                // =========================
                var report = new Report(solution);

                sheet.Cells[1, 9].Value = "ОТЧЕТ";

                using (var range = sheet.Cells[1, 9, 1, 10])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 14;
                }

                sheet.Cells[3, 9].Value = "Общее время:";
                sheet.Cells[3, 10].Value = report.TotalTime;

                sheet.Cells[4, 9].Value = "Стоимость:";
                sheet.Cells[4, 10].Value = report.TotalCost;

                sheet.Cells[5, 9].Value = "Загрузка:";
                sheet.Cells[5, 10].Value = report.GetExecutorLoad();

                sheet.Cells[6, 9].Value = "Непрерывность:";
                sheet.Cells[6, 10].Value = report.GetProjectContinuity();

                sheet.Cells[5, 10].Style.Numberformat.Format = "0.00%";
                sheet.Cells[6, 10].Style.Numberformat.Format = "0.00%";

                // рамка отчета
                using (var range = sheet.Cells[3, 9, 6, 10])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }

                // =========================
                // 🔹 ШИРИНА КОЛОНОК
                // =========================
                sheet.Cells.AutoFitColumns();
                sheet.Column(1).Width = 25;
                sheet.Column(2).Width = 20;
                sheet.Column(3).Width = 20;

                // =========================
                // 🔹 СОХРАНЕНИЕ
                // =========================
                File.WriteAllBytes(path, package.GetAsByteArray());
            }
        }
    }
}