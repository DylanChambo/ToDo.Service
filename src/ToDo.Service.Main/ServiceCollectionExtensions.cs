using ToDo.Service.Api;

namespace ToDo.Service.Main;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds default cors policy.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <param name="corsPolicyName">Cors policy name.</param>
    /// <returns>Service containing Cors policy.</returns>
    public static IServiceCollection AddDefaultCorsPolicy(this IServiceCollection services, string corsPolicyName) => services.AddCors(options =>
    {
        options.AddPolicy(corsPolicyName, builder =>
            builder.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
    });

    /// <summary>
    /// Adds api controllers.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service containing api controllers.</returns>
    public static IMvcBuilder AddApplicationPartControllers(this IServiceCollection services) => services
        .AddControllers(opt =>
        {
            opt.RespectBrowserAcceptHeader = true;
            opt.ReturnHttpNotAcceptable = true;
        })
        .AddApplicationPart(typeof(AssemblyMarker).Assembly);
}