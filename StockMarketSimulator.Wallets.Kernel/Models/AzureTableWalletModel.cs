using AzureTables.Connector.Models;

namespace StockMarketSimulator.Wallets.Kernel.Models
{
    public class AzureTableWalletModel : BaseAzureTableModel
    {
        //public string WalletId { get; set; }
        //public string StockName { get; set; }
        public double Balance { get; set; }
    }
}