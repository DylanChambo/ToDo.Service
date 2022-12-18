using ToDo.Service.DataModel.Repositories.Task;
using ToDo.Service.Services.Contract.Task;

namespace ToDo.Service.Services.Task;

public class TaskService : ITaskService
{
    private ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<Entities.Task> GetAll()
    {
        return _taskRepository.GetAllTasks();
    }
}