using Nox.Application.Jobs;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration;

[NoxJob("IntegrationJob", "*/1 *  * * *")]
public class IntegrationJob: JobBase
{
    private readonly INoxIntegrationContext _context;
    
    public IntegrationJob(
        ILogger<IJob> logger,
        INoxIntegrationContext context) : base(logger)
    {
        _context = context;
    }

    public override async Task Run()
    {
        await _context.ExecuteIntegrationAsync("JsonToTable");
        Console.WriteLine("The job did run!");
    }
}