namespace Users.Kernel.Application.Dtos
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid WalletId { get; set; }
    }
}