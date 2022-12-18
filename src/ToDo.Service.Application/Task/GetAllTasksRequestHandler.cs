using AutoMapper;
using MediatR;
using ToDo.Service.Requests.Account;
using ToDo.Service.Requests.Models;
using ToDo.Service.Services.Contract.Task;

namespace ToDo.Service.Application.Account;

public class GetAllTasksRequestHandler : IRequestHandler<GetAllTasksRequest, IEnumerable<TaskModel>>
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public GetAllTasksRequestHandler(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<IEnumerable<TaskModel>> Handle(GetAllTasksRequest request, CancellationToken cancellationToken)
    {
        var tasks = _taskService.GetAll();
        var taskModels = _mapper.Map<IEnumerable<TaskModel>>(tasks);
        return Task.FromResult(taskModels);
    }
}