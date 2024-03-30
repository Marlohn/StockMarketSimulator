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
            var wallet = await _walletsService.Get(walletId);
            return Ok(wallet);
        }

        [HttpPost("order/{walletId}/{stockSymbol}/{quantity}")]
        public async Task<IActionResult> Order(Guid walletId, string stockSymbol, decimal quantity)
        {
            await _walletsService.CreateOrder(walletId, stockSymbol, quantity);
            return Ok();
        }

        [HttpPost("deposit/{walletId}/{stockSymbol}/{quantity}")]
        public async Task<IActionResult> Deposit(Guid walletId, string stockSymbol, double quantity)
        {
            await _walletsService.Deposit(walletId, stockSymbol, quantity);
            return Ok();
        }
    }
}