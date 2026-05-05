using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Report
    {
        private ScheduleSolution solution;

        public Report(ScheduleSolution solution)
        {
            this.solution = solution;
        }

        public double TotalTime => solution.TotalTime;

        public double TotalCost => solution.TotalCost;
        private double CalculateLoad(IEnumerable<Operation> operations)
        {
            if (!operations.Any())
                return 0;

            double busyTime = operations.Sum(o => o.ActualTime);
            double startTime = operations.Min(o => o.StartTime);
            double endTime = operations.Max(o => o.EndTime);
            double totalTime = endTime - startTime;

            return totalTime == 0 ? 0 : totalTime < busyTime ? 1 : busyTime / totalTime;
        }
        public double GetExecutorLoad()
        {
            double result = 0;

            foreach (var exec in DataStorage.Executors.Keys)
            {
                var operations = solution.Operations.Values
                    .Where(o => o.Resource == exec);
                result += CalculateLoad(operations);
            }

            return result / DataStorage.Executors.Count;
        }

        public double GetProjectContinuity()
        {
            double result = 0;

            foreach (var project in DataStorage.Projects.Keys)
            {
                var operations = solution.Operations.Values
                   .Where(o => o.Project == project);
                result += CalculateLoad(operations);
            }

            return result / DataStorage.Projects.Count;
        }
    }
}
