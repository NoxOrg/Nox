
using Nox.Infrastructure;

namespace Nox.Extensions;

public static class NoxClientAssemblyProviderExtensions
{
    /// <summary>
    /// Get a type from the entry/client Assembly
    /// </summary>    
    public static Type? GetType(this INoxClientAssemblyProvider clientAssemblyProvider, string typeFullName) => clientAssemblyProvider.ClientAssembly.GetType(typeFullName);
    public static Type? GetEntityType(this INoxClientAssemblyProvider clientAssemblyProvider, string typeFullName) => clientAssemblyProvider.DomainAssembly.GetType(typeFullName);
    public static Type? GetEntityDtoType(this INoxClientAssemblyProvider clientAssemblyProvider, string typeFullName) => clientAssemblyProvider.DtoAssembly.GetType(typeFullName);
}
