using Users.Kernel.Models;

namespace Users.Kernel.Services
{
    public interface IUsersService
    {
        Task Create(UserDTO userDTO);
        Task<UserDTO> Get(string userName);
    }
}