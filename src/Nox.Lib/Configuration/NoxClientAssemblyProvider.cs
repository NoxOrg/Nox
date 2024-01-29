using Nox.Infrastructure;
using System.Reflection;

namespace Nox.Configuration
{
    internal class NoxClientAssemblyProvider : INoxClientAssemblyProvider
    {
        public NoxClientAssemblyProvider(Assembly clientAssembly, Assembly domainAssembly,Assembly dtoAssembly, Assembly applicationAssembly)
        {
            ArgumentNullException.ThrowIfNull(clientAssembly);
            ArgumentNullException.ThrowIfNull(domainAssembly);
            ArgumentNullException.ThrowIfNull(dtoAssembly);
            ArgumentNullException.ThrowIfNull(applicationAssembly);

            ClientAssembly = clientAssembly;
            DomainAssembly = domainAssembly;
            DtoAssembly = dtoAssembly;
            ApplicationAssembly = applicationAssembly;
        }

        public Assembly ClientAssembly { get; }
        public Assembly DomainAssembly { get; }
        public Assembly DtoAssembly { get; }
        public Assembly ApplicationAssembly { get; }
    }
}