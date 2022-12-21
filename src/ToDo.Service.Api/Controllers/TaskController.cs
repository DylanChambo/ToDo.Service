﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Service.Requests.Task;

namespace ToDo.Service.Api.Controllers;

/// <summary>
/// Example controller.
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
    /// Gets all accounts.
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
    /// Creates an account based on the provided request.
    /// </summary>
    /// <param name="request">Create account request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
        return Ok();
    }
}