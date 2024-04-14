using StockPairs.Kernel.Application.Dtos;

namespace StockPairs.Kernel.Domain.Services
{
    public interface IStockPairsService
    {
        Task<StockPairDTO> Get(string baseSymbol, string quoteSymbol);
        Task Upsert(StockPairDTO stockPairDTO);
    }
}