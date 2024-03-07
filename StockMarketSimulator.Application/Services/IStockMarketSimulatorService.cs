using StockMarketSimulator.Application.Dtos;

namespace StockMarketSimulator.Application.Services
{
    public interface IStockMarketSimulatorService
    {
        Task CreateUser(UserDto userDto);
    }
}