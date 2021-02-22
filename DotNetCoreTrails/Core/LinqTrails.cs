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
        public class Employeecomparer : IEqualityComparer<Employee>
        {
            public bool Equals([AllowNull] Employee x, [AllowNull] Employee y) => (x.Name == y.Name);
            //:TODO
            public int GetHashCode([DisallowNull] Employee obj) => 1;
        }


        #region Distinct
        //Works Super fast than Group by
        public IEnumerable<Employee> DistinctResult(IEnumerable<Employee> employeesist)
        {
            return employeesist.Distinct(new Employeecomparer());
        }

        public IEnumerable<Employee> DistinctResultWithGroupBy(IEnumerable<Employee> employeesist)
        {
            return employeesist.GroupBy(x => x.Name).Select(x => x.First());
        }
        #endregion

        public IEnumerable<IGrouping<string, Employee>> GroupByDesignation(IEnumerable<Employee> employeesist)
        {
            return employeesist.GroupBy(x => x.JobDesignation);
        }

        public IEnumerable<IGrouping<string, Employee>> GroupByDesignationAndOrderByAsc(IEnumerable<Employee> employeesist)
        {
            return employeesist.GroupBy(x => x.JobDesignation).OrderBy(x => x.Key);
        }

        public IEnumerable<IGrouping<string, Employee>> GroupByDesignationAndOrderByLengthOrderByAsc(IEnumerable<Employee> employeesist)
        {
            return employeesist.GroupBy(x => x.JobDesignation).OrderBy(x => x.Key.Length).ThenBy(x=>x.Key);
        }

    }
}
