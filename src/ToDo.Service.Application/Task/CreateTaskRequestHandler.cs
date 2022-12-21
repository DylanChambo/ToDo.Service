using AutoMapper;
using MediatR;

using ToDo.Service.Requests.Models;
using ToDo.Service.Requests.Task;
using ToDo.Service.Services.Contract.Task;

namespace ToDo.Service.Application.Task;

public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequest, bool>
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public CreateTaskRequestHandler(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<bool> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new Entities.Task
        {
            Info = request.Info,
            DueDate = request.DueDate,
            Status = request.Status,
            Priority = request.Priority,
        };
        return _taskService.Create(task);
    }
}
