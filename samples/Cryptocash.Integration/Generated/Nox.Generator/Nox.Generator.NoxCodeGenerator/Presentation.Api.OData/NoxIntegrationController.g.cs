// Generated

#nullable enable

using System;
using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions.Interfaces;
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
    public async Task<ActionResult> ExecuteQueryToTable()
    {
        try
        {
            await _integrationContext.ExecuteIntegrationAsync("QueryToTable");
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    [SwaggerOperation(
        Description = "Execute integration JsonToTable",
        OperationId = "ExecuteJsonToTable"
    )]
    [HttpPost("[action]")]
    public async Task<ActionResult> ExecuteJsonToTable()
    {
        try
        {
            await _integrationContext.ExecuteIntegrationAsync("JsonToTable");
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
}