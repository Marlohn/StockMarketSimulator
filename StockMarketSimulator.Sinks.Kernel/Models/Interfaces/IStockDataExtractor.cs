namespace StockMarketSimulator.Sinks.Kernel.Models.Interfaces
{
    public interface IStockDataExtractor
    {
        string GetName();
        string GetStockType();
        string GetSymbol();
        float GetPrice();
    }
}