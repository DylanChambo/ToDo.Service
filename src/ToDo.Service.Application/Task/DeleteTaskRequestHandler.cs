using AutoMapper;
using MediatR;

using ToDo.Service.Requests.Models;
using ToDo.Service.Requests.Task;
using ToDo.Service.Services.Contract.Task;

namespace ToDo.Service.Application.Task;

public class DeleteTaskRequestHandler : IRequestHandler<DeleteTaskRequest, bool>
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public DeleteTaskRequestHandler(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task<bool> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
    {
        return _taskService.Delete(request.Id);
    }
}
