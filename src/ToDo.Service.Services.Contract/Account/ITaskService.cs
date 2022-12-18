namespace ToDo.Service.Services.Contract.Task;

public interface ITaskService
{
    IEnumerable<Entities.Task> GetAll();
}