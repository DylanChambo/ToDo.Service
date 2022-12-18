namespace ToDo.Service.Entities.Exceptions;

/// <summary>
/// Bad account create data exception.
/// </summary>
public class BadAccountCreateDataException : BadRequestException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadAccountCreateDataException"/> class.
    /// </summary>
    public BadAccountCreateDataException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadAccountCreateDataException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public BadAccountCreateDataException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadAccountCreateDataException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    public BadAccountCreateDataException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadAccountCreateDataException"/> class.
    /// </summary>
    /// <param name="validationErrors">List of validation errors.</param>
    public BadAccountCreateDataException(IEnumerable<string> validationErrors)
        : base($"There are validation errors on account creation request: {string.Join(", ", validationErrors)}")
    {
    }
}