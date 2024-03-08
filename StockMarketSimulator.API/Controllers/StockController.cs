using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : Controller
    {
        private readonly IStockApplicationService _stockApplicationService;

        public StockController(IStockApplicationService stockApplicationService)
        {
            _stockApplicationService = stockApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "GetStocks")]
        public async Task<IActionResult> GetAsync()
        {

            await _stockApplicationService.UpsertStock(new StockDto()); // FIX

            return Ok();
        }
    }
}
