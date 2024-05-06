// Generated

#nullable enable

using Nox.Application.Jobs;
using Nox.Integration.Abstractions.Interfaces;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.Jobs;

[NoxJob("{{className}}", "{{cronExpression}}")]
public class {{className}}: JobBase
{
    private readonly INoxIntegrationContext _context;
    
    public {{className}}(
        ILogger<IJob> logger,
        INoxIntegrationContext context) : base(logger)
    {
        _context = context;
    }

    public override async Task Run()
    {
        await _context.ExecuteIntegrationAsync("{{integrationName}}");
    }
}