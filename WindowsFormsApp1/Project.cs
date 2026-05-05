using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Operation> Operations { get; set; }
        //public double ReleaseTime => (from operation in Operations select operation.EndTime).Max();
        public Project(int id, List<Operation> operations, string name)
        {
            Id = id;
            Operations = operations;
            Name = name;
        }
    }
}
