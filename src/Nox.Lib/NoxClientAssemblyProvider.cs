using System.Reflection;
using Nox.Abstractions;

namespace Nox;

public class NoxClientAssemblyProvider : INoxClientAssemblyProvider
{
    public NoxClientAssemblyProvider(Assembly clientAssembly)
    {
        ClientAssembly = clientAssembly;
    }

    public Assembly ClientAssembly { get; }
}