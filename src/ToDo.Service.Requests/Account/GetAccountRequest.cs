using MediatR;
using ToDo.Service.Requests.Models;

namespace ToDo.Service.Requests.Account;

public class GetAccountRequest : IRequest<AccountModel>
{
    public GetAccountRequest(int id)
    {
        Id = id;
    }

    public int Id { get; }
}