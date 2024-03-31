using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockMarketSimulator.Sinks.Kernel.Infrastructure.IoC;
using StockMarketSimulator.StockPairs.Kernel.Infrastructure.IoC;
using StockMarketSimulator.Stocks.Kernel.Infrastructure.IoC;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSinkService();
        services.AddStockPairsService();
        services.AddStocksService();
    })
    .Build();

host.Run();