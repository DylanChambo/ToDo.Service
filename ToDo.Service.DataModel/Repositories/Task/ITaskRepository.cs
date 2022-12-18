namespace ToDo.Service.DataModel.Repositories.Task
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Gets all accounts from account table
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entities.Task> GetAllTasks();
    }
}
