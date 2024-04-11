namespace Sinks.Kernel.Services
{
    public interface ISinksService
    {
        Task UpdateBtc();
        Task UpdateUsd();
    }
}