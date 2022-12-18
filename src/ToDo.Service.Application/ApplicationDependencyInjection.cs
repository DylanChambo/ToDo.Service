using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Service.Application.Behaviours;

namespace ToDo.Service.Application;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> required for the Application project.
/// </summary>
public static class ApplicationDependencyInjection
{
    /// <summary>
    /// Add the application code.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection with application services registered.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehaviour<,>));
        return services;
    }
}