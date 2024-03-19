using Ardalis.GuardClauses;
using StockMarketSimulator.Sinks.Kernel.Constants;
using StockMarketSimulator.Sinks.Kernel.Models.Interfaces;

namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class ApiNinjasResponse : IStockDataExtractor
    {
        public string Symbol { get; set; }
        public float Price { get; set; }
        public long Timestamp { get; set; }

        public string GetName()
        {
            return StockNames.Bitcoin;
        }

        public float GetPrice()
        {
            Guard.Against.Null(Price, nameof(Price));
            return Price;
        }

        public string GetSymbol()
        {
            return StockSymbols.BtcUsd;
        }

        public string GetStockType()
        {
            return StockTypes.Crypto;
        }
    }
}