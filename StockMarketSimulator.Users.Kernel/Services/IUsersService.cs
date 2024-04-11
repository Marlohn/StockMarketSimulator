using StockMarketSimulator.Users.Kernel.Models;

namespace StockMarketSimulator.Users.Kernel.Services
{
    public interface IUsersService
    {
        Task Create(UserDTO userDTO);
        Task<UserDTO> Get(string userName);
    }
}