using MediatR;
using ToDo.Service.Entities;
using ToDo.Service.Requests.Account;
using ToDo.Service.Services.Contract.Account;

namespace ToDo.Service.Application.Account;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
{
    private readonly IAccountService _accountService;

    public CreateAccountCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var maxId = _accountService.GetAll().Select(a => a.Id).Max();
        var newAccount = new Entities.Account
        {
            Id = maxId + 1,
            Name = request.Name,
            Status = (AccountStatus)request.Status,
            Type = (AccountType)request.Type,
            CreatedDate = DateTime.Now
        };
        _accountService.Create(newAccount);

        return Task.FromResult(newAccount.Id);
    }
}