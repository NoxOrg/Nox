using Nox.Infrastructure;
using System.Reflection;

namespace Nox.Configuration
{
    internal class NoxClientAssemblyProvider : INoxClientAssemblyProvider
    {
        public NoxClientAssemblyProvider(Assembly clientAssembly)
        {
            ClientAssembly = clientAssembly;
        }

        public Assembly ClientAssembly { get; }
    }
}
