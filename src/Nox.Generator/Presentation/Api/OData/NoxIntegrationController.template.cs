// Generated

#nullable enable

using System;
using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace {{ codeGenConventions.ODataNameSpace }};

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
    
    {{- for integration in integrations }}
    [SwaggerOperation(
        Description = "Execute integration {{ integration.Name }}",
        OperationId = "Execute{{ integration.Name }}"
    )]
    [HttpPost("[action]")]
    public async Task<ActionResult> Execute{{ integration.Name }}()
    {
        try
        {
            await _integrationContext.ExecuteIntegrationAsync("{{ integration.Name }}");
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    {{- end }}
    
}