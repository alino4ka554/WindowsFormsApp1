using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ScheduleService
    {
        private readonly ScheduleBuilder _builder = new ScheduleBuilder();
        private readonly ScheduleOptimizer _optimizer = new ScheduleOptimizer();
        public ScheduleSolution BuildSchedule(ScheduleBuildParams param, IProgress<int> progress)
        {
            var solution = _builder.Build(param, progress);
            DataStorage.Solution = solution;
            return solution;
        }
        public void OptimizeSchedule(double e)
        {
            if (DataStorage.Solution == null) return;
            _optimizer.Optimize(DataStorage.Solution, e);
        }
        public ScheduleSolution GetSolution()
        {
            return DataStorage.Solution;
        }
    }
}
