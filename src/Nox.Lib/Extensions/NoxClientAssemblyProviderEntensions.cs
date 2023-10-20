
using Nox.Infrastructure;

namespace Nox.Extensions;

public static class NoxClientAssemblyProviderExtensions
{
    /// <summary>
    /// Get a type from the entry/client Assembly
    /// </summary>    
    public static Type? GetType(this INoxClientAssemblyProvider clientAssemblyProvider, string typeFullName) => clientAssemblyProvider.ClientAssembly.GetType(typeFullName);
}
