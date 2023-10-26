using Nox.Integration.Abstractions;
using Nox.Types;

namespace Nox.Integration;

public class NoxIntegration: INoxIntegration
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public INoxReceiveAdapter ReceiveAdapter { get; set; }
    public INoxSendAdapter SendAdapter { get; set; }
    internal async Task<bool> ExecuteAsync()
    {
        
        throw new NotImplementedException();
    }
}