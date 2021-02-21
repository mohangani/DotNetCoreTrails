using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreTrails.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTrails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public Employee Get()
        {
            return new Employee("Mohan");
        }

        [HttpGet("GetIActionResult")]
        public IActionResult GetIActionResult()
        {
            return Ok(new Employee("Mohan"));
        }

        [HttpGet("GetActionResult")]
        public ActionResult GetActionResult()
        {
            return Ok(new Employee("Mohan"));
        }

        [HttpGet("getActionResult")]
        public ActionResult GetActionResult2()
        {
            return Ok(new Employee("Mohan"));
        }

        [HttpGet("GetGenericActionResult")]
        public ActionResult<Employee> GetGenericActionResult()
        {
            return new Employee("Mohan");
        }
    }
}
