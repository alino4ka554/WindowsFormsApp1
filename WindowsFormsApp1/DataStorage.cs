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
        public static List<Project> Projects = new List<Project>();
        public static List<Resource> Executors = new List<Resource>();
        public static List<Operation> Operations = new List<Operation>();
    }
}
