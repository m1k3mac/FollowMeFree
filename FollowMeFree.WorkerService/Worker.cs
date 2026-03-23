using System.Configuration;

namespace FollowMeFree.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string JobFilePath;
        private readonly PrintJobExtractor _printJobExtractor;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            // Load the JobFilePath from the App.config of the FollowMeFree project
            var appConfigPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FollowMeFree", "App.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.GetFullPath(appConfigPath) };
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var settingsGroup = config.GetSectionGroup("applicationSettings");
            var section = settingsGroup?.Sections["FollowMeFree.Properties.Settings"] as ClientSettingsSection;
            var setting = section?.Settings.Get("JobFilePath");
            JobFilePath = setting?.Value?.ValueXml?.InnerText ?? string.Empty;

            _printJobExtractor = new PrintJobExtractor("FMF Print Queue");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                try
                {
                    var extractedJobs = await _printJobExtractor.ExtractAllJobsAsync(JobFilePath);
                    if (extractedJobs.Count > 0)
                    {
                        _logger.LogInformation("Extracted {count} print job(s)", extractedJobs.Count);
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
