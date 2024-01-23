using System.Reflection;

namespace Nox.Infrastructure
{
    /// <summary>
    /// Holds the Client Assembly using Nox Solution where the generated code is being executed
    /// </summary>
    public interface INoxClientAssemblyProvider
    {
        Assembly ClientAssembly { get; }
        Assembly DomainAssembly { get; }
    }    
}