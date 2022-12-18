using Microsoft.AspNetCore.Mvc;

namespace ToDo.Service.Api.Controllers;

/// <summary>
/// Api v1 controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
public abstract class ApiV1ControllerBase : ControllerBase
{
}