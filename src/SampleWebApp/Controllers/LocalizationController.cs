using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace SampleWebApp.Presentation.Api.OData;

[ApiController]
[Route("[controller]")]
public class LocalizationController : ControllerBase
{
    [HttpGet(Name = "GetEnglish")]
    public ActionResult Get()
    {
        return Ok();
    }
}