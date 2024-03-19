using Ardalis.GuardClauses;
using StockMarketSimulator.Sinks.Kernel.Models.Interfaces;

namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class ApiNinjasResponse : IStockDataExtractor
    {
        public string Symbol { get; set; }
        public float Price { get; set; }
        public long Timestamp { get; set; }

        public float GetPrice()
        {
            Guard.Against.Null(Price, nameof(Price));

            return Price;
        }

        public string GetSymbol()
        {
            Guard.Against.Null(Symbol, nameof(Symbol));

            return Symbol.ToLower();
        }
    }
}