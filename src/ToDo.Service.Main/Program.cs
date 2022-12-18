using System.Reflection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ToDo.Service.Api;
using ToDo.Service.Application;
using ToDo.Service.Main;
using ToDo.Service.Services;
using ToDo.Service.Services.Contract.Logging;

#pragma warning disable CA1812
const string corsPolicyName = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCorsPolicy(corsPolicyName);
builder.Services.AddApplication();
builder.Services.AddServices();
builder.Services.AddDomainServices();
builder.Services.AddApplicationLogging();
builder.Services.AddApplicationPartControllers();
builder.Services.AddWebApiWithVersioning();
builder.Services.AddSwagger();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerManager>());
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

if (bool.TryParse(app.Configuration["EnableSwagger"], out var shouldUseSwagger) && shouldUseSwagger)
{
    app.UseSwaggerWithVersioning(provider);
}

app.UseCors(corsPolicyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
#pragma warning restore CA1812