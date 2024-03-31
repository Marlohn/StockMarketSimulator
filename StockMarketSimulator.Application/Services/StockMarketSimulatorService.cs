using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Domain.Models;
using StockMarketSimulator.Domain.Services;

namespace StockMarketSimulator.Application.Services
{
    public class StockMarketSimulatorService : IStockMarketSimulatorService
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;

        public StockMarketSimulatorService(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        //TODO: RESPONSE OBJ
        public async Task CreateUser(UserDto userDto)
        {
            //TODO: Map & validate
            var user = new User() { Name = userDto.Name, Password = userDto.Password };

            await _userService.Create(user);
        }

        public async Task AddMoney(Guid walletId, float amount)
        {

        }

        public async Task GetWallet(Guid walletId)
        {

        }

        public async Task AddOrder(Guid walletId)
        {

        }
    }
}