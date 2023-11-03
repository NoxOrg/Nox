using Nox.Integration.Abstractions;

namespace Nox.Integration;

public class Sample
{
    private readonly INoxIntegrationContext _context;
    
    public Sample(INoxIntegrationContext context)
    {
        _context = context;
    }

    private async Task DoSomething()
    {
        var success = await _context.ExecuteIntegrationAsync("MyIntegration");
    }
}