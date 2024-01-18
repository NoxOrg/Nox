using Nox.Infrastructure;
using System.Reflection;

namespace Nox.Configuration
{
    internal class NoxClientAssemblyProvider : INoxClientAssemblyProvider
    {
        public NoxClientAssemblyProvider(Assembly clientAssembly, Assembly domainAssemby)
        {
            ClientAssembly = clientAssembly;
            DomainAssembly = domainAssemby;
        }

        public Assembly ClientAssembly { get; }

        public Assembly DomainAssembly { get; }
    }
}