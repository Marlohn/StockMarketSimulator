namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class ApiNinjasResponseModel
    {
        public string Symbol { get; set; }
        public string Price { get; set; }
        public long Timestamp { get; set; }
    }
}