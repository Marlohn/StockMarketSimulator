using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Kernel.Domain.Repository;
using Stocks.Kernel.Domain.Services;
using Stocks.Kernel.Infrastructure.Repository;

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