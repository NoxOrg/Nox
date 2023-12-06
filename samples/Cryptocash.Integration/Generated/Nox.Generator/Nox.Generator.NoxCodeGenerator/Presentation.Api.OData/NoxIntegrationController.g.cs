// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions;

namespace CryptocashIntegration.Presentation.Api.OData;

[ApiController]
[Route("[Controller]")]
public class NoxIntegrationController : Controller
{
    private readonly INoxIntegrationContext _integrationContext;

    public NoxIntegrationController(
        INoxIntegrationContext integrationContext)
    {
        _integrationContext = integrationContext;
    }
    [HttpPost("[action]")]
    public ActionResult ExecuteQueryToTable()
    {
        _integrationContext.ExecuteIntegrationAsync("QueryToTable");
        return Ok();
    }
    [HttpPost("[action]")]
    public ActionResult ExecuteQueryToCustomTable()
    {
        _integrationContext.ExecuteIntegrationAsync("QueryToCustomTable");
        return Ok();
    }
    
}