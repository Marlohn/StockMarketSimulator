using StockPairs.Kernel.Infrastructure.IoC;
using Stocks.Kernel.Infrastructure.IoC;
using Wallets.Kernel.Infrastructure.IoC;

namespace Wallets.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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