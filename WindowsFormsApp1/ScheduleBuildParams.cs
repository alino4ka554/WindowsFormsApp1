using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ScheduleBuildParams
    {
        public int Iterations { get; set; }
        public int Ants { get; set; }
        public double Beta { get; set; }
        public double Alpha { get; set; }
        public double Rho { get; set; }
        public double TauMin { get; set; }
        public double TauMax { get; set; }
    }
}
