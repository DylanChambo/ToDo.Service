using ToDo.Service.Services.Contract.Logging;

namespace ToDo.Service.Services.Logging;

/// <summary>
/// Raygun logging.
/// </summary>
public class ConsoleLogger : ILoggerManager
{
    /// <inheritdoc />
    public void LogException(Exception exception)
    {
        Console.WriteLine(exception.ToString());
    }
}