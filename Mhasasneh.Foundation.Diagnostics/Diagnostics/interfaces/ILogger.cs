namespace Mhasasneh.Foundation.Core.Diagnostics.interfaces
{
    /// <summary>Provide an injectable interface for a logging utility.</summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs debugging level information
        /// </summary>
        /// <param name="message">The message to log</param>
        void LogDebug(string message);

        /// <summary>Log an informational message.</summary>
        /// <param name="message">The message to log.</param>
        void LogInfo(string message);

        /// <summary>Log an error message.</summary>
        /// <param name="message">The message to log.</param>
        void LogError(string message);

        ///// <summary>
        ///// Switches the logger used to a custom one with the name passed to this method
        ///// </summary>
        ///// <param name="loggerName">Name of the logger to be used instead of the default one</param>
        void GetCustomLogger();
    }
}
