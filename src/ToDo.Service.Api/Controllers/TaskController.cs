using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Service.Requests.Task;

namespace ToDo.Service.Api.Controllers;

/// <summary>
/// Task controller.
/// </summary>
[Route("api/tasks")]
public class TaskController : ApiV1ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all tasks.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var tasks = await _mediator.Send(new GetAllTasksRequest(), cancellationToken).ConfigureAwait(false);
        return Ok(tasks);
    }

    /// <summary>
    /// Creates a task based on the provided request.
    /// </summary>
    /// <param name="request">Create task request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
        return Ok();
    }

    /// <summary>
    /// Updates a task based on the provided request.
    /// </summary>
    /// <param name="request">Update task request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
        return Ok();
    }

    /// <summary>
    /// Deletes the task from the request.
    /// </summary>
    /// <param name="id">Task id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteTaskRequest(id), cancellationToken).ConfigureAwait(false);
        return Ok();
    }
}