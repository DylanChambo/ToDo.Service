using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Service.Requests.Account;

namespace ToDo.Service.Api.Controllers;

/// <summary>
/// Example controller.
/// </summary>
[Route("api/accounts")]
public class AccountsController : ApiV1ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountsController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public AccountsController(IMediator mediator)
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
        var accounts = await _mediator.Send(new GetAllAccountsRequest(), cancellationToken).ConfigureAwait(false);
        return Ok(accounts);
    }

    /// <summary>
    /// Gets an account with the provided id.
    /// </summary>
    /// <param name="id">Id of the account to fetch.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var account = await _mediator.Send(new GetAccountRequest(id), cancellationToken).ConfigureAwait(false);
        return Ok(account);
    }

    /// <summary>
    /// Creates an account based on the provided request.
    /// </summary>
    /// <param name="request">Create account request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAccount(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
        return Ok();
    }
}