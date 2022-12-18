namespace ToDo.Service.Requests.Models;

/// <summary>
/// Task Model.
/// </summary>
public class TaskModel
{
    /// <summary>
    /// Gets or sets Task Id.
    /// </summary>
    public int Id { get; set; }

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