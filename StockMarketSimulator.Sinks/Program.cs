using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockMarketSimulator.Application.Extensions;
using StockMarketSimulator.Sinks.Kernel.IoC;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddApplicationServices();
        services.AddSinkService();
    })
    .Build();

host.Run();