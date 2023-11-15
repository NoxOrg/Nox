using System;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

public interface INoxTypeComponentsDiscover
{
    public Type GetUnderlyingType(NoxSimpleTypeDefinition attribute);
}