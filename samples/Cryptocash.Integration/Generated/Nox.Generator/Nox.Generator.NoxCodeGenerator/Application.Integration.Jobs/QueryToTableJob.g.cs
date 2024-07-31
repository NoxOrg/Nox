// Generated

#nullable enable

using Nox.Application.Jobs;
using Nox.Integration.Abstractions.Interfaces;

namespace CryptocashIntegration.Application.Integration.Jobs;

[NoxJob("QueryToTableJob", "0 3 * * 0")]
public class QueryToTableJob: JobBase
{
    private readonly INoxIntegrationContext _context;
    
    public QueryToTableJob(
        ILogger<QueryToTableJob> logger,
        INoxIntegrationContext context) : base(logger)
    {
        _context = context;
    }

    public override async Task Run()
    {
        await _context.ExecuteIntegrationAsync("QueryToTable");
    }
}