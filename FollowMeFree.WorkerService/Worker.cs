using FollowMeFree.WorkerService.Data;
using Microsoft.EntityFrameworkCore;

// This class defines a background worker service that periodically extracts print jobs using the PrintJobExtractor class. It retrieves configuration settings from the database and logs the extracted print jobs.
// The service runs continuously until it is stopped, with a delay between each extraction cycle.

namespace FollowMeFree.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<FollowMeFreeDbContext>();
                    var config = await db.Configs.OrderBy(c => c.Id).FirstOrDefaultAsync(stoppingToken);

                    if (config == null)
                    {
                        _logger.LogWarning("No configuration found in Config table");
                        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                        continue;
                    }

                    var printJobExtractor = new PrintJobExtractor(config.FmfprinterName);
                    var extractedJobs = await printJobExtractor.ExtractAllJobsAsync(config.JobFilePath);
                    if (extractedJobs.Count > 0)
                    {
                        foreach (var job in extractedJobs)
                        {
                            _logger.LogInformation("Extracted print job: {@job}", job);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error extracting print jobs");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
