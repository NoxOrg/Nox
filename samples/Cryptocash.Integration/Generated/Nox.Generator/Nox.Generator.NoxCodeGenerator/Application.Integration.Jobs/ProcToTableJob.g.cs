// Generated

#nullable enable

using Nox.Application.Jobs;
using Nox.Integration.Abstractions.Interfaces;

namespace CryptocashIntegration.Application.Integration.Jobs;

[NoxJob("ProcToTableJob", "0 3 * * 0")]
public class ProcToTableJob: JobBase
{
    private readonly INoxIntegrationContext _context;
    
    public ProcToTableJob(
        ILogger<ProcToTableJob> logger,
        INoxIntegrationContext context) : base(logger)
    {
        _context = context;
    }

    public override async Task Run()
    {
        await _context.ExecuteIntegrationAsync("ProcToTable");
    }
}