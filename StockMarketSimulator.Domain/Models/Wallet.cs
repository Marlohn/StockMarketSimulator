namespace StockMarketSimulator.Domain.Models
{
    public class Wallet : BaseModel
    {
        List<Stock> Stocks { get; set; }
    }
}