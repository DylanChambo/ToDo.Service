using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Service.Services.Account;
using ToDo.Service.Services.Contract.Account;
using ToDo.Service.Services.Contract.Logging;
using ToDo.Service.Services.Logging;

namespace ToDo.Service.Services;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> required for the Services project.
/// </summary>
public static class ServicesDependencyInjection
{
    /// <summary>
    /// Add the service code.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection with application services registered.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddSingleton<IAccountService, AccountService>();

        return services;
    }

    /// <summary>
    /// Adds logging.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection with application services registered.</returns>
    public static IServiceCollection AddApplicationLogging(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, ConsoleLogger>();
        return services;
    }

    private static void RegisterAllTypes<T>(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var typesFromAssemblies = assembly.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T)) && !x.IsAbstract);
        foreach (var type in typesFromAssemblies)
        {
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }
}