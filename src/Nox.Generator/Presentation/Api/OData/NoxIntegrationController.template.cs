// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Nox.Integration.Abstractions;

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
    [HttpPost("[action]")]
    public ActionResult Execute{{ integration.Name }}()
    {
        _integrationContext.ExecuteIntegrationAsync("{{ integration.Name }}");
        return Ok();
    }
    {{- end }}
    
}