namespace StockMarketSimulator.Wallets.Kernel.Models
{
    public class AssetDTO
    {
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public string StockType { get; set; }
        public double Balance { get; set; }
    }
}