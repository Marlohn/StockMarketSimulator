using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Application.Services;
using StockMarketSimulator.Domain.Interfaces;
using StockMarketSimulator.Domain.Services;
using StockMarketSimulator.Repository.Repositories;

namespace StockMarketSimulator.IoC
{
    public class DependencyInjector
    {
        public static void RegisterApplication(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped<IStockMarketSimulatorService, StockMarketSimulatorService>();
        }

        public static void RegisterDomain(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped<IOrderService, OrderService>();
            svcCollection.AddScoped<IStockService, StockService>();
            svcCollection.AddScoped<IUserService, UserService>();
            svcCollection.AddScoped<IWalletService, WalletService>();
        }

        public static void RegisterRepository(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}