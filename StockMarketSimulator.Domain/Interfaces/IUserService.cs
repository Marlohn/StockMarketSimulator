using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Services
{
    public interface IUserService
    {
        Task Create(User user);
    }
}