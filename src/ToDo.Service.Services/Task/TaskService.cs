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

    public async Task<bool> Create(Entities.Task task)
    {
        return await _taskRepository.CreateTask(task);
    }

    public async Task<bool> Update(Entities.Task task)
    {
        return await _taskRepository.UpdateTask(task);
    }

    public async Task<bool> Delete(int Id)
    {
        return await _taskRepository.DeleteTask(Id);
    }
}