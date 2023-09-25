using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
