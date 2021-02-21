using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTrails.Models
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }
        public Employee()
        {

        }
        public int Age { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public string JobDesignation { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }

        private string GetDebuggerDisplay() => $"{Name} - {Age} - {Gender}";
    }
}
