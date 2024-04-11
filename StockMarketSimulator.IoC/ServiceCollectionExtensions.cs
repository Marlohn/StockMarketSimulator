//using Microsoft.Extensions.DependencyInjection;
//using StockMarketSimulator.Application.Services;
//using StockMarketSimulator.Domain.Interfaces;
//using StockMarketSimulator.Domain.Services;
//using StockMarketSimulator.Repository.Repositories;

//namespace StockMarketSimulator.IoC
//{
//    public static class ServiceCollectionExtensions
//    {
//        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
//        {
//            services.AddScoped<IStockMarketSimulatorService, StockMarketSimulatorService>();
//            services.AddScoped<IStockApplicationService, StockApplicationService>();
//            return services;
//        }

//        public static IServiceCollection AddDomainServices(this IServiceCollection services)
//        {
//            services.AddScoped<IOrderService, OrderService>();
//            services.AddScoped<IStockService, StockService>();
//            services.AddScoped<IUserService, UserService>();
//            services.AddScoped<IWalletService, WalletService>();
//            return services;
//        }

//        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
//        {
//            services.AddScoped<IUserRepository, UserRepository>();
//            services.AddScoped<IStockRepository, StockRepository>();
//            return services;
//        }
//    }
//}