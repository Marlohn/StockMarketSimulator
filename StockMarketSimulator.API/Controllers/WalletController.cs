using Microsoft.AspNetCore.Mvc;

namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid walletId)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SendOrder(Guid walletId)
        {
            return Ok();
        }
    }
}