using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Abstractions
{
    public interface INoxClientAssemblyProvider
    {
        Assembly ClientAssembly { get; }
    }
}