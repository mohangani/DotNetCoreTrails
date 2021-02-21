using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetCoreTrails.Exceptions
{
    public class TestException: Exception
    {
        public TestException(string exception):base(exception)
        {
            ExceptionObj = new { ExceptionMessage =  exception, From  = typeof(TestException) };
        }
        public object ExceptionObj { get; }
        public override string ToString()
        {
            return ExceptionObj.ToString();
        }

    }
}
