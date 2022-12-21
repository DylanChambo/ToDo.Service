using AutoMapper;
using MediatR;

using ToDo.Service.Requests.Models;
using ToDo.Service.Requests.Task;
using ToDo.Service.Services.Contract.Task;

namespace ToDo.Service.Application.Task;

public class UpdateTaskRequestHandler : IRequestHandler<UpdateTaskRequest, bool>
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public UpdateTaskRequestHandler(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<bool> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new Entities.Task
        {
            TaskId= request.TaskId,
            Info = request.Info,
            DueDate = request.DueDate,
            Status = request.Status,
            Priority = request.Priority,
        };
        return _taskService.Update(task);
    }
}
