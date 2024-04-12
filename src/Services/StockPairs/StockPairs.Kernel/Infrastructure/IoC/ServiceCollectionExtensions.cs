using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockPairs.Kernel.Infrastructure.Repository;
using StockPairs.Kernel.Services;

namespace StockPairs.Kernel.Infrastructure.IoC
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