using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ToDo.Service.Api;

/// <summary>
/// Dependency injection for api versioning.
/// </summary>
public static class ApiDependencyInjection
{
    /// <summary>
    /// Adds api with versioning.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service containing api versioning feature.</returns>
    public static IServiceCollection AddWebApiWithVersioning(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
        });

        services.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        });

        return services;
    }

    /// <summary>
    /// Adds swagger.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service containing swagger feature.</returns>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();
        services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}