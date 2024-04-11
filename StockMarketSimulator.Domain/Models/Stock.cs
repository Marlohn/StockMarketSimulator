namespace StockMarketSimulator.Domain.Models
{
    public class Stock : BaseModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
    }
}