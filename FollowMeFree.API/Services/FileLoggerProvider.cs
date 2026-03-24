using System.Configuration;

namespace FollowMeFree.API.Services
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;
        private readonly object _lock = new();

        public FileLoggerProvider()
        {
            var appConfigPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FollowMeFree", "App.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.GetFullPath(appConfigPath) };
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var settingsGroup = config.GetSectionGroup("applicationSettings");
            var section = settingsGroup?.Sections["FollowMeFree.Properties.Settings"] as ClientSettingsSection;
            var setting = section?.Settings.Get("APILogFilePath");
            var directory = setting?.Value?.ValueXml?.InnerText ?? string.Empty;

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            _filePath = Path.Combine(directory, "FollowMeFreeAPI.log");
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _filePath, _lock);
        }

        public void Dispose()
        {
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;
        private readonly object _lock;

        public FileLogger(string categoryName, string filePath, object lockObj)
        {
            _categoryName = categoryName;
            _filePath = filePath;
            _lock = lockObj;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_categoryName}: {formatter(state, exception)}";
            if (exception != null)
            {
                message += Environment.NewLine + exception;
            }

            lock (_lock)
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }
    }
}
