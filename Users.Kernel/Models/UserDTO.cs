namespace StockMarketSimulator.Users.Kernel.Models
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid WalletId { get; set; }
    }
}