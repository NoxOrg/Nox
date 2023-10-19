
using Nox.Configuration;

namespace Nox.Extensions;

public static class NoxClientAssemblyProviderExtensions
{
    public static Type? GetType(this INoxClientAssemblyProvider clientAssemblyProvider, string typeFullName) => clientAssemblyProvider.ClientAssembly.GetType(typeFullName);
}
