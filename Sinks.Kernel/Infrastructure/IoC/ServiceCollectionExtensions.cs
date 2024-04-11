using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using Sinks.Kernel.Infrastructure.Repository;
using Sinks.Kernel.Services;
using StockPairs.Kernel.Services;

namespace Sinks.Kernel.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSinkService(this IServiceCollection services)
        {
            services.AddScoped<ISinksService, SinksService>();
            services.AddScoped<ICryptoRepository, CryptoRepository>();
            services.AddScoped<IFiatRepository, FiatRepository>();
            services.AddScoped<IStockPairsService, StockPairsService>();
            services.AddScoped<IQueueProcessStockPairsService, QueueProcessStockPairsService>();
            services.AddAzureTables();
            return services;
        }
    }
}