using AutoMapper;
using MediatR;
using ToDo.Service.Requests.Account;
using ToDo.Service.Requests.Models;
using ToDo.Service.Services.Contract.Account;

namespace ToDo.Service.Application.Account;

public class GetAccountRequestHandler : IRequestHandler<GetAccountRequest, AccountModel>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public GetAccountRequestHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public Task<AccountModel> Handle(GetAccountRequest request, CancellationToken cancellationToken)
    {
        var account = _accountService.GetById(request.Id);
        var accountModel = _mapper.Map<AccountModel>(account);
        return Task.FromResult<AccountModel>(accountModel);
    }
}