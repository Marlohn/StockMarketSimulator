using StockMarketSimulator.IoC;
using StockMarketSimulator.Users.Kernel.Infratructure.IoC;
using StockMarketSimulator.Wallets.Kernel.Infrastructure.IoC;

namespace StockMarketSimulator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ////ToDo: Create a extension here
            ////builder.Services.AddScoped<IStockService, StockService>();
            //DependencyInjector.RegisterDomain(builder.Services);
            //DependencyInjector.RegisterApplication(builder.Services);
            //DependencyInjector.RegisterRepository(builder.Services);

            builder.Services.AddUsersService();
            builder.Services.AddWalletsService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
