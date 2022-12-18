using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ToDo.Service.Api;

/// <summary>
/// Add swagger to the application.
/// </summary>
public static class ApiApplicationBuilder
{
    /// <summary>
    /// Use swagger to the pipeline.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <param name="apiVersionDescriptionProvider">Version provider.</param>
    /// <returns>Application builder with swagger.</returns>
    public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var desc in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.ApiVersion.ToString());
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            }
        });

        return app;
    }
}