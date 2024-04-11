using Ardalis.GuardClauses;
using Sinks.Kernel.Models.Interfaces;

namespace Sinks.Kernel.Models
{
    public class ApiNinjasResponse : IStockDataExtractor
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public long Timestamp { get; set; }

        public double GetPrice()
        {
            Guard.Against.Null(Price, nameof(Price));
            return Price;
        }

        public string GetBaseSymbol()
        {
            ValidateSymbol();
            return Symbol.Substring(0, 3);
        }

        public string GetQuoteSymbol()
        {
            ValidateSymbol();
            return Symbol.Substring(3, 3);
        }

        private void ValidateSymbol()
        {
            Guard.Against.Null(Symbol, nameof(Symbol));
            //Guard.Against.OutOfRange(Symbol.Length, nameof(Symbol), 6, 6);
        }
    }
}