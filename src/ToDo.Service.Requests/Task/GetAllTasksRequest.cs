using MediatR;
using ToDo.Service.Requests.Models;

namespace ToDo.Service.Requests.Task;

public class GetAllTasksRequest : IRequest<IEnumerable<TaskModel>>
{
}