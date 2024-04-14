namespace Sinks.Kernel.Domain.Services
{
    public interface ISinksService
    {
        Task UpdateBtc();
        Task UpdateUsd();
    }
}