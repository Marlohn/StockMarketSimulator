using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Users.Kernel.Infratructure.Repository;
using StockMarketSimulator.Users.Kernel.Services;

namespace StockMarketSimulator.Users.Kernel.Infratructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUsersService(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddAzureTables();

            return services;
        }
    }
}