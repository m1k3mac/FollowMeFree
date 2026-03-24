using FollowMeFree.WorkerService.Data;
using Microsoft.Extensions.Logging;

namespace FollowMeFree.WorkerService
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _source;

        public DatabaseLoggerProvider(IServiceProvider serviceProvider, string source)
        {
            _serviceProvider = serviceProvider;
            _source = source;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(categoryName, _serviceProvider, _source);
        }

        public void Dispose()
        {
        }
    }

    public class DatabaseLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _source;

        public DatabaseLogger(string categoryName, IServiceProvider serviceProvider, string source)
        {
            _categoryName = categoryName;
            _serviceProvider = serviceProvider;
            _source = source;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) =>
            logLevel != LogLevel.None
            && !_categoryName.StartsWith("Microsoft.EntityFrameworkCore"); // Exclude EF Core logs to prevent recursion

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                LogLevel = logLevel.ToString(),
                Source = _source,
                Category = _categoryName,
                Message = formatter(state, exception),
                Exception = exception?.ToString()
            };

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<FollowMeFreeDbContext>();
                db.Logs.Add(logEntry);
                db.SaveChanges();
            }
            catch
            {
                // Swallow exceptions to prevent logging failures from crashing the application
            }
        }
    }
}
