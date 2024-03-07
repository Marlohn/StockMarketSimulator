using StockMarketSimulator.Domain.Interfaces;
using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(User user)
        {
            await _userRepository.CreateUser(user);
        }
    }
}