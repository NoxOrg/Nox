using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Services;

public class NoxIntegration: INoxIntegration
{
    public string Name { get; }
    public string? Description { get; }
    public INoxReceiveAdapter? ReceiveAdapter { get; set; }
    public INoxSendAdapter? SendAdapter { get; set; }

    public NoxIntegration(string name, string? description)
    {
        Name = name;
        Description = description;
    }
    
    public Task<bool> ExecuteAsync()
    {
        
    }
}