using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreTrails.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCoreTrails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Writing to log file with INFORMATION severity level.");
        
            _logger.LogDebug("Writing to log file with DEBUG severity level."); 
        
            _logger.LogWarning("Writing to log file with WARNING severity level.");
        
            _logger.LogError("Writing to log file with ERROR severity level.");
        
            _logger.LogCritical("Writing to log file with CRITICAL severity level.");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new TestException("Test Exception.");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
