using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ScheduleBuilder
    {
        public ScheduleSolution Build(ScheduleBuildParams param, IProgress<int> progress)
        {
            var colony = new ACO(
                DataStorage.Operations,
                param.Iterations,
                param.Ants,
                param.Beta,
                param.Alpha,
                param.Rho,
                param.TauMin,
                param.TauMax);

            colony.Run(progress);

            return colony.BestSolution;
        }
    }
}
