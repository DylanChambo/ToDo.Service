using MediatR;
using ToDo.Service.Requests.Models;

namespace ToDo.Service.Requests.Account;

public class GetAllTasksRequest : IRequest<IEnumerable<TaskModel>>
{
}