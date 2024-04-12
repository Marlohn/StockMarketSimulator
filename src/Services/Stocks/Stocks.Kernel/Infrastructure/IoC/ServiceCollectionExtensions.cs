using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Kernel.Infrastructure.Repository;
using Stocks.Kernel.Services;

namespace Stocks.Kernel.Infrastructure.IoC
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