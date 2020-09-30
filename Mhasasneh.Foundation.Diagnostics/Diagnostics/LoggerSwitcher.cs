using Sitecore.Common;

namespace Mhasasneh.Foundation.Core.Diagnostics
{
    /// <summary>
    /// Switches the log4net logger into a custom one using the logger name
    /// </summary>
    public class LoggerSwitcher : Switcher<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerSwitcher"/> class.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        public LoggerSwitcher(string loggerName)
        : base(loggerName)
        {
        }
    }
}
