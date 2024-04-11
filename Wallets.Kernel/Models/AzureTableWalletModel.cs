using AzureTables.Connector.Models;

namespace Wallets.Kernel.Models
{
    public class AzureTableWalletModel : BaseAzureTableModel
    {
        public string WalletId { get; set; }
        public string StockSymbol { get; set; }
        public double Balance { get; set; }
    }
}