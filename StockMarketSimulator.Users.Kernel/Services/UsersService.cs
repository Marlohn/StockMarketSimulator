using StockMarketSimulator.Common.Extensions;
using StockMarketSimulator.Users.Kernel.Infratructure.Repository;
using StockMarketSimulator.Users.Kernel.Models;

namespace StockMarketSimulator.Users.Kernel.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task Create(UserDTO userDTO)
        {
            // ToDo: Create Mapper

            var azureTableUserModel = new AzureTableUserModel()
            {
                PartitionKey = "user",
                RowKey = userDTO.UserName,
                UserName = userDTO.UserName,
                Password = userDTO.Password.Encrypt(),
                WalletId = Guid.NewGuid()
            };

            // Todo: Create Validator

            await _usersRepository.Create(azureTableUserModel);
        }

        public async Task<UserDTO> Get(string userName)
        {
            AzureTableUserModel? azureTableUserModel = await _usersRepository.Get(userName);

            return new UserDTO()
            {
                UserName = azureTableUserModel.UserName,
                WalletId = azureTableUserModel.WalletId
            };
        }
    }
}