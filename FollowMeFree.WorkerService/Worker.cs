namespace FollowMeFree.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppSettingsProvider _appSettings;
        private readonly PrintJobExtractor _printJobExtractor;

        public Worker(ILogger<Worker> logger, AppSettingsProvider appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;

            _printJobExtractor = new PrintJobExtractor(_appSettings.FMFPrinterName);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}

                try
                {
                    var extractedJobs = await _printJobExtractor.ExtractAllJobsAsync(_appSettings.JobFilePath);
                    if (extractedJobs.Count > 0)
                    {
                        //_logger.LogInformation("Extracted {count} print job(s)", extractedJobs.Count);
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
