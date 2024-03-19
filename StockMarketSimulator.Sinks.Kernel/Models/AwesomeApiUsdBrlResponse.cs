using Ardalis.GuardClauses;
using StockMarketSimulator.Common.Extensions;
using StockMarketSimulator.Sinks.Kernel.Models.Interfaces;
using System.Text.Json.Serialization;

namespace StockMarketSimulator.Sinks.Kernel.Models
{
    public class AwesomeApiUsdBrlResponse : IStockDataExtractor
    {
        [JsonPropertyName("USDBRL")]
        public AwesomeApiCurrencyPairDetail UsdBrl { get; set; }

        public float GetPrice()
        {
            Guard.Against.Null(UsdBrl, nameof(UsdBrl));
            Guard.Against.NullOrEmpty(UsdBrl.Ask, nameof(UsdBrl.Ask));

            return UsdBrl.Ask.ToFloat();
        }

        public string GetSymbol()
        {
            Guard.Against.Null(UsdBrl, nameof(UsdBrl));
            Guard.Against.NullOrEmpty(UsdBrl.Code, nameof(UsdBrl.Code));
            Guard.Against.NullOrEmpty(UsdBrl.Codein, nameof(UsdBrl.Codein));

            return $"{UsdBrl.Code}{UsdBrl.Codein}".ToLower();
        }
    }
}
