namespace ToDo.Service.Entities.Exceptions;

/// <summary>
/// Base exception thrown for bad request and will be handled as 400 http error.
/// </summary>
public abstract class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class.
    /// </summary>
    protected BadRequestException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    protected BadRequestException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    protected BadRequestException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}