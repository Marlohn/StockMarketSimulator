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


        [HttpPost("deposit/{walletId}/{stockSymbol}/{quantity}")]
        public async Task<IActionResult> Deposit(Guid walletId, string stockSymbol, float quantity)
        {
            await _walletsService.Deposit(walletId, stockSymbol, quantity);
            return Ok();
        }

        [HttpPost("withdraw/{walletId}/{stockSymbol}/{quantity}")]
        public async Task<IActionResult> Withdraw(Guid walletId, string stockSymbol, float quantity)
        {
            await _walletsService.Withdraw(walletId, stockSymbol, quantity);
            return Ok();
        }


        [HttpPost("exchange/{walletId}/{baseSymbol}/{quoteSymbol}/{quantity}")]
        public async Task<IActionResult> Exchange(Guid walletId, string baseSymbol, string quoteSymbol, float quantity)
        {
            await _walletsService.Exchange(walletId, baseSymbol, quoteSymbol, quantity);
            return Ok();
        }
    }
}