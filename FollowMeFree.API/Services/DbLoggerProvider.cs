using FollowMeFree.API.Data;

namespace FollowMeFree.API.Services
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public DbLoggerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, _serviceProvider);
        }

        public void Dispose()
        {
        }
    }

    public class DbLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly IServiceProvider _serviceProvider;

        public DbLogger(string categoryName, IServiceProvider serviceProvider)
        {
            _categoryName = categoryName;
            _serviceProvider = serviceProvider;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;        

        public bool IsEnabled(LogLevel logLevel) =>
            logLevel != LogLevel.None
            && !_categoryName.StartsWith("Microsoft.EntityFrameworkCore"); // Exclude EF Core logs to prevent recursion

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var logEntry = new Data.Log
            {
                Timestamp = DateTime.Now,
                LogLevel = logLevel.ToString(),
                Source = "API",
                Category = _categoryName,
                Message = formatter(state, exception),
                Exception = exception?.ToString()
            };

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<FmfDataContext>();
                db.Logs.Add(logEntry);
                db.SaveChanges();
            }
            catch
            {
                // Prevent logging failures from crashing the application.
            }
        }
    }
}
