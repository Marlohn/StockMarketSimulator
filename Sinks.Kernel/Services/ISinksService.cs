namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public interface ISinksService
    {
        Task UpdateBtc();
        Task UpdateUsd();
    }
}