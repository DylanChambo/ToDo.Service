namespace ToDo.Service.Entities;

/// <summary>
/// Error details.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Gets or sets the status code for the error.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string Message { get; set; }
}