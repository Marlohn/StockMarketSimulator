﻿using AzureTables.Connector.IoC;
using Microsoft.Extensions.DependencyInjection;
using Users.Kernel.Infrastructure.Repository;
using Users.Kernel.Services;

namespace Users.Kernel.Infrastructure.IoC
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