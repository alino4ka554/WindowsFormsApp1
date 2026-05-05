using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CPM
    {
        public ScheduleSolution Solution;
        public double Td;
        public double E;
        private HashSet<int> _blockedOperations = new HashSet<int>();

        public CPM(ScheduleSolution solution, double e)
        {
            Solution = solution;
            E = e;
            Td = Solution.TotalTime - E;
        }
        private void Initialize()
        {
            Solution.InitializeDependsForResource();
            Solution.FindCriticalWay();
        }
        private bool HasCriticalPath()
        {
            return Solution.CriticalWays.Count != 0;
        }
        private int SelectOperationForAcceleration()
        {
            double min = double.MaxValue;
            int minOpId = -1;

            foreach (var op in Solution.Operations.Values)
            {
                if (!_blockedOperations.Contains(op.Id))
                {
                    int k = Solution.CriticalWays.Sum(cw => cw.Count(id => id == op.Id));
                    if (k == 0) continue;
                    double value = op.Delta / k;
                    if (value < min)
                    {
                        min = value;
                        minOpId = op.Id;
                    }
                }
            }

            return minOpId;
        }
        private bool TryAccelerate(int opId)
        {
            var op = Solution.Operations[opId];
            double deltaT = Solution.TotalTime - Td;

            if (op.Acceleration + deltaT <= op.NormalTime - op.CrashTime)
            {
                op.Acceleration += deltaT;
                Solution.RecalculateFrom(opId);
                return true;
            }
            return false;
        }
        private void Recalculate()
        {
            Solution.CriticalWays.Clear();
            Solution.FindCriticalWay();
        }
        private void UpdateDeadline()
        {
            if (Solution.TotalTime <= Td)
                Td = Solution.TotalTime - E;
        }
        public void Run()
        {
            Initialize();
            List<int> opsCannotBeAcceleratated = new List<int>();
            while (HasCriticalPath())
            {
                UpdateDeadline();
                int opId = SelectOperationForAcceleration();
                if (opId == -1)
                    break;
                if (!TryAccelerate(opId))
                    _blockedOperations.Add(opId);
                Recalculate();
            }
        }
    }
}
