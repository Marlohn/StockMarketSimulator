using AzureTables.Connector.Models;

namespace StockPairs.Kernel.Models
{
    public class AzureTableStockPairModel : BaseAzureTableModel
    {
        public string Name { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public double Price { get; set; }
    }
}