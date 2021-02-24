﻿using DotNetCoreTrails.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTrails.Core
{
    //ref: https://www.tutorialsteacher.com/linq/linq-equality-operator
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

        #region ToLookup & GroupBy 

        //TODO: Use ToLookUp Insted of Group by
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
            return employeesist.GroupBy(x => x.JobDesignation).OrderBy(x => x.Key.Length).ThenBy(x => x.Key);
        }
        #endregion

        public object JoinTwoLists(IEnumerable<Employee> employeeList, IEnumerable<EmployeeMartialStatus> employeeMartialStatusList)
        {
            return employeeList.Join(employeeMartialStatusList,
                  el => el.Name,
                  eml => eml.Name,
                  (el, eml) => new { el.Name, el.Gender, el.Age, eml.MaritalStatus });
        }

        //Group join is grouping the list on key only
        public IEnumerable<object> GroupJoinTwoLists(IEnumerable<Employee> employeeList)
        {


           return Enum.GetValues(typeof(MaritialStatus)).Cast<MaritialStatus>().GroupJoin(employeeList,
                                          eml => eml,
                                          el => el.MaritalStatus,
                                          (eml, el) => new
                                          {
                                              Emplyees = el,
                                              MartialStatus = eml

                                          });
        }


        public void OfTypeLinq()
        {
            var list = new List<object> { 1, "mohan", 23.1 };
            var result = list.OfType<string>().ToList();
        }


    }
}
