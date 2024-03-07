using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
    }
}