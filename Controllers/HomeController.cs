using Microsoft.AspNetCore.Mvc;

namespace NebulaCloud.Controllers;

[ApiController]
[Route("/v1/health")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}