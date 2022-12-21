using ToDo.Service.DataModel;

namespace ToDo.Service.DataModel.Repositories.Task
{
    /// <summary>
    /// An implementation of <see cref="ITaskRepository" /> for Veezi user repositories backed by a Microsoft SQL Server database.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoDbContext _dbContext;

        /// <inheritdoc/>
        public TaskRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public IEnumerable<Entities.Task> GetAllTasks()
        {
            var tasks = _dbContext.Task.ToList();

            return tasks;
        }

        public async Task<bool> CreateTask(Entities.Task task)
        {
            _dbContext.Task.Add(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
