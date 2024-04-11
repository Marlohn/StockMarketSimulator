using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.StockPairs.Kernel.Infrastructure.Repository;
using StockMarketSimulator.StockPairs.Kernel.Services;

namespace StockMarketSimulator.StockPairs.Kernel.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStockPairsService(this IServiceCollection services)
        {
            services.AddScoped<IStockPairsService, StockPairsService>();
            services.AddScoped<IStockPairsRepository, StockPairsRepository>();
            services.AddAzureTables();

            return services;
        }
    }
}