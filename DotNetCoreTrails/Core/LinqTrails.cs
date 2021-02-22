using DotNetCoreTrails.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTrails.Core
{
    public class LinqTrails
    {
        public IEnumerable<Employee> DistinctResult(IEnumerable<Employee> employeesist) {
            return employeesist.Distinct(new Employeecomparer());
        }


        public class Employeecomparer : IEqualityComparer<Employee>
        {
            public bool Equals([AllowNull] Employee x, [AllowNull] Employee y)
            {
                return (x.Name == y.Name) ;
            }

            //:TODO
            public int GetHashCode([DisallowNull] Employee obj)
            {
                return 1;
            }
        }

    }
}
