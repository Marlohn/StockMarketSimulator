namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class ApiNinjasResponseModel
    {
        public string Symbol { get; set; }
        public float Price { get; set; }
        public long Timestamp { get; set; }
    }
}