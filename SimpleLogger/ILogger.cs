using System.Threading.Tasks;

namespace SimpleLogger
{
    
    public interface ILogger
    {
        /// <summary>
        /// Contain the most detailed messages. These messages may contain sensitive app data. These messages are disabled by default and should not be enabled in production.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Trace(string message);
        /// <summary>
        /// For debugging and development. Use with caution in production due to the high volume.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Debug(string message);
        /// <summary>
        /// Tracks the general flow of the app. May have long-term value.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Information(string message);
        /// <summary>
        /// For abnormal or unexpected events. Typically includes errors or conditions that don't cause the app to fail.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Warning(string message);
        /// <summary>
        /// For errors and exceptions that cannot be handled. These messages indicate a failure in the current operation or request, not an app-wide failure.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Error(string message);
    }
}
