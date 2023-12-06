// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace {{ codeGeneratorState.ODataNameSpace }};

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
    public ActionResult Execute{{ integration.Name }}()
    {
        _integrationContext.ExecuteIntegrationAsync("{{ integration.Name }}");
        return Ok();
    }
    {{- end }}
    
}