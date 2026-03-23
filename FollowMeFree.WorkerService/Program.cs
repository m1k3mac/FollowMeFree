using FollowMeFree.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<PipeServer>();

var host = builder.Build();
host.Run();
