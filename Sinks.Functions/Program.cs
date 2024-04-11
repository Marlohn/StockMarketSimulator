using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sinks.Kernel.Infrastructure.IoC;
using StockPairs.Kernel.Infrastructure.IoC;
using Stocks.Kernel.Infrastructure.IoC;

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