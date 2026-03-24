using FollowMeFree.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<AppSettingsProvider>();
builder.Logging.Services.AddSingleton<ILoggerProvider>(sp =>
    new FileLoggerProvider(sp.GetRequiredService<AppSettingsProvider>()));
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<PipeServer>();

var host = builder.Build();
host.Run();
