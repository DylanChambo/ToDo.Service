using ToDo.Service.DataModel;
using ToDo.Service.Entities.Exceptions;

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

        /// <inheritdoc/>
        public async Task<bool> UpdateTask(Entities.Task updateTask)
        {
            var task = _dbContext.Task.FirstOrDefault(t => t.TaskId == updateTask.TaskId);

            if (task is null)
            {
                throw new AccountNotFoundException();
            }
            else if (updateTask is null)
            {
                throw new ArgumentNullException(nameof(updateTask));
            }

            task.Info = updateTask.Info;
            task.DueDate = updateTask.DueDate;
            task.Status = updateTask.Status;
            task.Priority = updateTask.Priority;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTask(int Id)
        {
            var task = _dbContext.Task.FirstOrDefault(t => t.TaskId == Id);

            if (task is null)
            {
                throw new AccountNotFoundException();
            }

            _dbContext.Task.Remove(task);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
