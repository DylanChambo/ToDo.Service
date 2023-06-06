using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Service.Requests.Task;

public class UpdateTaskRequest : IRequest<bool>
{
    /// <summary>
    /// Gets or sets Task Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets Task Info.
    /// </summary>
    public string Info { get; set; }

    /// <summary>
    /// Gets or sets Task DueDate.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Gets or sets Task Status.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets Task Priority.
    /// </summary>
    public string Priority { get; set; }
}
