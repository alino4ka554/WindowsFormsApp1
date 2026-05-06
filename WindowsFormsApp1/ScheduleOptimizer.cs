using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ScheduleOptimizer
    {
        public void Optimize(ScheduleSolution solution, double e)
        {
            var cpm = new CPM(solution, e);
            cpm.Run();
        }
    }
}
