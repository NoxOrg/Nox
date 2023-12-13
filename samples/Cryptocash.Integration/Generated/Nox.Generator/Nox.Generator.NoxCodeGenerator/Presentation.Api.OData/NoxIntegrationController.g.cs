// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(
        Description = "Execute integration QueryToTable",
        OperationId = "ExecuteQueryToTable"
    )]
    [HttpPost("[action]")]
    public ActionResult ExecuteQueryToTable()
    {
        _integrationContext.ExecuteIntegrationAsync("QueryToTable");
        return Ok();
    }
    [SwaggerOperation(
        Description = "Execute integration QueryToCustomTable",
        OperationId = "ExecuteQueryToCustomTable"
    )]
    [HttpPost("[action]")]
    public ActionResult ExecuteQueryToCustomTable()
    {
        _integrationContext.ExecuteIntegrationAsync("QueryToCustomTable");
        return Ok();
    }
    [SwaggerOperation(
        Description = "Execute integration JsonToTable",
        OperationId = "ExecuteJsonToTable"
    )]
    [HttpPost("[action]")]
    public ActionResult ExecuteJsonToTable()
    {
        _integrationContext.ExecuteIntegrationAsync("JsonToTable");
        return Ok();
    }
    
}