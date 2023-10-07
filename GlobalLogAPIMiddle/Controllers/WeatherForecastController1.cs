using Microsoft.AspNetCore.Mvc;

namespace GlobalLogAPIMiddle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController1 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController1> _logger;

        public WeatherForecastController1(ILogger<WeatherForecastController1> logger)
        {
            _logger = logger;
            _logger.LogInformation("WeatherForecast controller called 2nd API ");
        }

        [HttpGet(Name = "GetWeatherForecast1")]
        public IEnumerable<WeatherForecast1> Get()
        {
            _logger.LogInformation("WeatherForecast get method Starting 2nd API");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast1
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}