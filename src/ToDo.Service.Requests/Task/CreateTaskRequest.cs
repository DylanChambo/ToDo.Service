using MediatR;

namespace ToDo.Service.Requests.Task;

/// <inheritdoc/>
public class CreateTaskRequest : IRequest<bool>
{
    /// <summary>
    /// Gets or sets Task Info.
    /// </summary>
    public string Info { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Task DueDate.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Gets or sets Task Status.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Task Priority.
    /// </summary>
    public string Priority { get; set; } = string.Empty;
}