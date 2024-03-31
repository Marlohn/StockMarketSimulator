using StockMarketSimulator.StockPairs.Kernel.Infrastructure.IoC;
using StockMarketSimulator.Stocks.Kernel.Infrastructure.IoC;
using StockMarketSimulator.Users.Kernel.Infratructure.IoC;
using StockMarketSimulator.Wallets.Kernel.Infrastructure.IoC;

namespace StockMarketSimulator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddUsersService();
            builder.Services.AddWalletsService();
            builder.Services.AddStockPairsService();
            builder.Services.AddStocksService();

            var app = builder.Build();

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