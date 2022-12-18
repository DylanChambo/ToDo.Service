using MediatR;

namespace ToDo.Service.Requests.Account;

public class CreateAccountCommand : IRequest<int>
{
    public string Name { get; set; }

    public int Status { get; set; }

    public int Type { get; set; }
}