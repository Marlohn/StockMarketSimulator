using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Sinks.Kernel.Services;

namespace StockMarketSimulator.Sinks.Kernel.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSinkService(this IServiceCollection services)
        {
            services.AddScoped<ISinksServices, SinksService>();
            services.AddScoped<IGenericHttpClient, GenericHttpClient>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddAzureTables();
            return services;
        }
    }
}