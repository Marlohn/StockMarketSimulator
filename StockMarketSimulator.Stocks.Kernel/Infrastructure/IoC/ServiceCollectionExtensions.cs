using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Stocks.Kernel.Infrastructure.Repository;
using StockMarketSimulator.Stocks.Kernel.Services;

namespace StockMarketSimulator.Stocks.Kernel.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStocksService(this IServiceCollection services)
        {
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddAzureTables();

            return services;
        }
    }
}
