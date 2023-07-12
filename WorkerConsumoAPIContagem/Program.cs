using WorkerConsumoAPIContagem;
using WorkerConsumoAPIContagem.Resilience;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(RateLimitContagem.CreateRateLimitPolicy());
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();