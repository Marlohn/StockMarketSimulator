using Users.Kernel.Application.Dtos;

namespace Users.Kernel.Domain.Services
{
    public interface IUsersService
    {
        Task Create(UserDTO userDTO);
        Task<UserDTO> Get(string userName);
    }
}