namespace ToDo.Service.Entities.Exceptions;

/// <summary>
/// Base exception thrown for data not found and will be handled as 404 http error.
/// </summary>
public abstract class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    protected NotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    protected NotFoundException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    protected NotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}