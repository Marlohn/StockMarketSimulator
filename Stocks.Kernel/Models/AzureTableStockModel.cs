using AzureTables.Connector.Models;

namespace StockMarketSimulator.Stocks.Kernel.Models
{
    public class AzureTableStockModel : BaseAzureTableModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}