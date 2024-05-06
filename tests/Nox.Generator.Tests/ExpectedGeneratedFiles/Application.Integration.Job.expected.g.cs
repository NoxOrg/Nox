// Generated

#nullable enable

using Nox.Application.Jobs;
using Nox.Integration.Abstractions.Interfaces;

namespace TestIntegrationSolution.Application.Integration.Jobs;

[NoxJob("TestIntegrationJob", "0 2 * * *")]
public class TestIntegrationJob: JobBase
{
    private readonly INoxIntegrationContext _context;
    
    public TestIntegrationJob(
        ILogger<IJob> logger,
        INoxIntegrationContext context) : base(logger)
    {
        _context = context;
    }

    public override async Task Run()
    {
        await _context.ExecuteIntegrationAsync("TestIntegration");
    }
}