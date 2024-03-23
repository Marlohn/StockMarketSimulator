using AzureTables.Connector.Models;

namespace StockMarketSimulator.Wallets.Kernel.Models
{
    public class AzureTableWalletModel : BaseAzureTableModel
    {
        public string WalletId { get; set; }
        public string StockId { get; set; }
        public float Balance { get; set; }
    }
}