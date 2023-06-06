using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Service.Entities;

/// <summary>
/// Task Entity.
/// </summary>
public class Task
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