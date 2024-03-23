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

        [HttpGet("{walletId}")]
        public async Task<IActionResult> Get(Guid walletId)
        {
            return Ok();
        }

        [HttpPost("order/{walletId}/{stockSymbol}/{quantity}")]
        public async Task<IActionResult> Order(Guid walletId, string stockSymbol, decimal quantity)
        {
            return Ok();
        }

        [HttpPost("deposit/{walletId}/{stockName}/{quantity}")]
        public async Task<IActionResult> Deposit(Guid walletId, string stockName, decimal quantity)
        {
            return Ok();
        }
    }
}