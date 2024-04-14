namespace Sinks.Kernel.Application.Models.Interfaces
{
    public interface IStockDataExtractor
    {
        string GetBaseSymbol();
        string GetQuoteSymbol();
        double GetPrice();
    }
}