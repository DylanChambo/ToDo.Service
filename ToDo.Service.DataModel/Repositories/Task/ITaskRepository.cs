namespace ToDo.Service.DataModel.Repositories.Task
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Gets all accounts from account table
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entities.Task> GetAllTasks();

        Task<bool> CreateTask(Entities.Task task);

        Task<bool> UpdateTask(Entities.Task updateTask);

        Task<bool> DeleteTask(int Id);
    }
}
