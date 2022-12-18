using Microsoft.AspNetCore.Mvc;

namespace ToDo.Service.Api.Controllers;

/// <summary>
/// Ping controller.
/// </summary>
[Route("api/ping")]
public class PingController : ApiV1ControllerBase
{
    /// <summary>
    /// Gets ping.
    /// </summary>
    /// <returns>Utc time now.</returns>
    [HttpGet]
    public ActionResult Get()
    {
        return Ok($"Pong from the new web api. Timestamp in UTC {DateTime.UtcNow}");
    }
}