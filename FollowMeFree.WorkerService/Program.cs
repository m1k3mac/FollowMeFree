using FollowMeFree.WorkerService;
using FollowMeFree.WorkerService.Data;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContext<FollowMeFreeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Logging.Services.AddSingleton<ILoggerProvider>(sp =>
    new DatabaseLoggerProvider(sp, "Service"));
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<PipeServer>();

var host = builder.Build();
host.Run();
