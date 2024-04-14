using AzureTables.Connector.Models;

namespace Stocks.Kernel.Application.Models
{
    public class AzureTableStockModel : BaseAzureTableModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}