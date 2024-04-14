using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using Sinks.Kernel.Domain.Repository;
using Sinks.Kernel.Domain.Services;
using Sinks.Kernel.Infrastructure.Repository;
using StockPairs.Kernel.Domain.Services;

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