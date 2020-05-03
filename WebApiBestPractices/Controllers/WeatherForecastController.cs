using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Controllers
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
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly AppDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepositoryWrapper repositoryWrapper, AppDbContext dbContext)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            //throw new ArgumentNullException(); // Handle global exception
            _logger.LogInformation("Getting something");
            var accounts = _repositoryWrapper.Account.FindAll();

            if (accounts == null || !accounts.Any()) Summaries[1] = "Nullfddfsdf";
            var rng = new Random();
            return Ok(Enumerable.Range(1, 20).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [HttpPost]
        public IActionResult UpdateAccount([FromBody] Account account)
        {



            return Ok(account);
        }
    }
}
