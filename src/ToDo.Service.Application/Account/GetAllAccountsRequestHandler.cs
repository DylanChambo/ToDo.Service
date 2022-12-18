using AutoMapper;
using MediatR;
using ToDo.Service.Requests.Account;
using ToDo.Service.Requests.Models;
using ToDo.Service.Services.Contract.Account;

namespace ToDo.Service.Application.Account;

public class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, IEnumerable<AccountModel>>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public GetAllAccountsRequestHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<IEnumerable<AccountModel>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
    {
        var accounts = _accountService.GetAll();
        var accountModels = _mapper.Map<IEnumerable<AccountModel>>(accounts);
        return Task.FromResult(accountModels);
    }
}