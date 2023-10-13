using System.Reflection;

namespace Nox.Configuration
{
    public interface INoxClientAssemblyProvider
    {
        Assembly ClientAssembly { get; }
    }    
}