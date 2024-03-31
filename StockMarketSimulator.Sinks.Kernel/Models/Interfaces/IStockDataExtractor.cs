namespace StockMarketSimulator.Sinks.Kernel.Models.Interfaces
{
    public interface IStockDataExtractor
    {
        string GetBaseSymbol();
        string GetQuoteSymbol();
        double GetPrice();
    }
}