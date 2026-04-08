using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class DataStorage
    {
        public static Dictionary<int, Project> Projects = new Dictionary<int, Project>();
        public static Dictionary<int, Resource> Executors = new Dictionary<int, Resource>();
        public static Dictionary<int, Operation> Operations = new Dictionary<int, Operation>();
        public static ScheduleSolution Solution;
    }
}
