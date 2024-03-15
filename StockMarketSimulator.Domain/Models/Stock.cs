namespace StockMarketSimulator.Domain.Models
{
    public class Stock : BaseModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public float Price { get; set; }
    }
}