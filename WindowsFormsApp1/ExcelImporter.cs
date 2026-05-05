using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class ExcelImporter
    {
        public static void LoadOperationsFromExcel(string path)
        {
            Workbook wb = new Workbook(path);
            WorksheetCollection collection = wb.Worksheets;
            for (int worksheetIndex = 7; worksheetIndex < 8; worksheetIndex++)
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
                            .Split(',')                        
                            .Select(x => x.Trim())             
                            .Where(x => int.TryParse(x, out _))
                            .Select(int.Parse)                 
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
                        int idRes = DataManager.Instance.GetNextExecutorId();
                        var newRes = new Resource(idRes, resName);
                        DataManager.Instance.AddExecutor(newRes);
                        ExecutorsByName.Add(resName, newRes);
                    }
                    if (!ProjectsByName.ContainsKey(projName))
                    {
                        int idProj = DataManager.Instance.GetNextProjectId();
                        var newProj = new Project(idProj, new List<Operation>(), projName);
                        DataManager.Instance.AddProject(newProj);
                        ProjectsByName.Add(projName, newProj);
                    }
                    cellValue = worksheet.Cells[i, 0].Value?.ToString();
                    var op = new Operation
                    {
                        Id = DataManager.Instance.GetNextOperationId(),
                        Name = int.TryParse(cellValue, out var opVal) ? $"Задача {opVal}" : cellValue,
                        DependsOn = preds,
                        Resource = ExecutorsByName[resName].Id,
                        Project = ProjectsByName[projName].Id,
                        NormalTime = double.TryParse(worksheet.Cells[i, 4].Value?.ToString(), out var ntVal) ? ntVal : 0,
                        CrashTime = double.TryParse(worksheet.Cells[i, 5].Value?.ToString(), out var ctVal) ? ctVal : 0,
                        NormalCost = double.TryParse(worksheet.Cells[i, 6].Value?.ToString(), out var ncVal) ? ncVal : 0,
                        CrashCost = double.TryParse(worksheet.Cells[i, 7].Value?.ToString(), out var ccVal) ? ccVal : 0,

                    };
                    DataManager.Instance.AddOperation(op);
                }
            }
        }

    }
}
