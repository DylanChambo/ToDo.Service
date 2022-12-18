using Microsoft.Extensions.DependencyInjection;
using ToDo.Service.DataModel;
using ToDo.Service.DataModel.Repositories.Task;

namespace ToDo.Service.Services
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> required for the Services project.
    /// </summary>
    public static class RegisterDomainServices
    {
        /// <summary>
        /// Adds Domain Services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Service collection with Domain services registered.</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ToDoDbContext>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
