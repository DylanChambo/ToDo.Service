namespace ToDo.Service.Services.Contract.Logging;

/// <summary>
/// Logger manager for handling logging.
/// </summary>
public interface ILoggerManager
{
    /// <summary>
    /// Logs exception.
    /// </summary>
    /// <param name="exception">Exception to log.</param>
    void LogException(Exception exception);
}