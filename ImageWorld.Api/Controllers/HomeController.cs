using Microsoft.AspNetCore.Mvc;

namespace ImageWorld.Api.Controllers;

[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "Hello Image World";
    }
}