namespace StockMarketSimulator.Sinks.Kernel.Models.Interfaces
{
    public interface IStockDataExtractor
    {
        string GetSymbol();
        float GetPrice();
    }
}