using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockPairs.Kernel.Domain.Repository;
using StockPairs.Kernel.Domain.Services;
using StockPairs.Kernel.Infrastructure.Repository;

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