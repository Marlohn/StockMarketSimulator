using Ardalis.GuardClauses;
using StockMarketSimulator.Common.Extensions;
using StockMarketSimulator.Sinks.Kernel.Constants;
using StockMarketSimulator.Sinks.Kernel.Models.Interfaces;
using System.Text.Json.Serialization;

namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class AwesomeApiUsdBrlResponse : IStockDataExtractor
    {
        [JsonPropertyName("USDBRL")]
        public AwesomeApiCurrencyPairDetail UsdBrl { get; set; }

        public string GetName()
        {
            return StockNames.Dollar;
        }

        public float GetPrice()
        {
            Guard.Against.Null(UsdBrl, nameof(UsdBrl));
            Guard.Against.NullOrEmpty(UsdBrl.Ask, nameof(UsdBrl.Ask));

            return UsdBrl.Ask.ToFloat();
        }

        public string GetStockType()
        {
            return StockTypes.Fiat;
        }

        public string GetSymbol()
        {
            return StockSymbols.UsdBrl;
        }
    }
}
