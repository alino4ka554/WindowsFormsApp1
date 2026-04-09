using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Operation 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> DependsOn { get; set; } = new List<int>();
        public int Project { get; set; }
        public int Resource { get; set; }
        public double NormalTime { get; set; }
        public double CrashTime { get; set; }
        public double NormalCost { get; set; }
        public double CrashCost { get; set; }
        public double StartTime { get; set; }
        public double Acceleration { get; set; }
        public double ActualTime => Math.Max(NormalTime - Acceleration, CrashTime);
        public double ActualCost => NormalCost + Delta * Acceleration;
        public double Delta => (CrashCost - NormalCost) / (NormalTime - CrashTime);

        public double EndTime => StartTime + ActualTime;
        public Operation CloneOriginal()
        {
            return new Operation
            {
                Id = this.Id,
                Name = this.Name,
                Project = this.Project,
                Resource = this.Resource,
                NormalTime = this.NormalTime,
                CrashTime = this.CrashTime,
                NormalCost = this.NormalCost,
                CrashCost = this.CrashCost,
                Acceleration = this.Acceleration,
                StartTime = this.StartTime,
                DependsOn = new List<int>(this.DependsOn),
            };
        }
    }
}