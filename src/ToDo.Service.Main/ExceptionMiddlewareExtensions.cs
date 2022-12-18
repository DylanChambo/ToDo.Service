using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using ToDo.Service.Entities;
using ToDo.Service.Entities.Exceptions;
using ToDo.Service.Services.Contract.Logging;

namespace ToDo.Service.Main;

/// <summary>
/// Exception middleware extension.
/// </summary>
public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// Configure global exception handler.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <param name="logger">An instance of <see cref="ILoggerManager"/>.</param>
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LogException(contextFeature.Error);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    })).ConfigureAwait(false);
                }
            });
        });
    }
}