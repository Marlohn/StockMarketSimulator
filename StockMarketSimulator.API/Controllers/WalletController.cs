using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Wallets.Kernel.Services;

namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletsService _walletsService;

        public WalletController(IWalletsService walletsService)
        {
            _walletsService = walletsService;
        }

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