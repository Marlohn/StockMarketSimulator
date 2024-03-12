using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStockMarketSimulatorService, StockMarketSimulatorService>();
            services.AddScoped<IStockApplicationService, StockApplicationService>();
            return services;
        }
    }
}