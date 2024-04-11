using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository;
using StockMarketSimulator.Wallets.Kernel.Services;

namespace StockMarketSimulator.Wallets.Kernel.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWalletsService(this IServiceCollection services)
        {
            services.AddScoped<IWalletsService, WalletsService>();
            services.AddScoped<IWalletsRepository, WalletsRepository>();
            services.AddAzureTables();

            return services;
        }
    }
}