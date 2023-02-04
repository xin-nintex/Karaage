using Karaage.Youtube.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Karaage Youtube Service";
    })
    .ConfigureServices(services => { services.AddHostedService<Worker>(); })
    .Build();

host.Run();