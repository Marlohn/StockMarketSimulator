using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IStockMarketSimulatorService _stockMarketSimulatorService;
        private readonly ILogger<WeatherForecastController> _logger;        

        public WeatherForecastController(IStockMarketSimulatorService stockMarketSimulatorService, ILogger<WeatherForecastController> logger)
        {
            _stockMarketSimulatorService = stockMarketSimulatorService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {

            await _stockMarketSimulatorService.CreateUser(new UserDto() { UserName = "Marlohn", Password = "senha" });

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
