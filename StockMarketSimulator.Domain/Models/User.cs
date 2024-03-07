namespace StockMarketSimulator.Domain.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Wallet Wallet { get; set; }
    }
}