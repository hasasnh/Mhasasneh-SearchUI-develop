using log4net;
using Mhasasneh.Foundation.Core.Diagnostics.interfaces;

namespace Mhasasneh.Foundation.Core.Diagnostics
{
    /// <inheritdoc />
    public class LogEntry : ILogger
    {
        private ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public void GetCustomLogger()
        {
            var loggerName = LoggerSwitcher.CurrentValue;

            if (string.IsNullOrWhiteSpace(loggerName) == false)
                _logger = LogManager.GetLogger(loggerName);
        }

        /// <inheritdoc />
        public void LogDebug(string message)
        {
            GetCustomLogger();

            if (_logger != null)
                _logger.Debug(message);
            else
                Sitecore.Diagnostics.Log.Debug(message, this);
        }

        /// <inheritdoc />
        public void LogInfo(string message)
        {
            GetCustomLogger();

            if (_logger != null)
                _logger.Info(message);
            else
                Sitecore.Diagnostics.Log.Info(message, this);
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            GetCustomLogger();

            if (_logger != null)
                _logger.Error(message);
            else
                Sitecore.Diagnostics.Log.Error(message, this);
        }
    }
}
