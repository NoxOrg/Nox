using System;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.ComponentsDiscover;

internal record NoxTypeComponentsDiscover : INoxTypeComponentsDiscover
{
    private readonly Type _underlyingType;

    public NoxTypeComponentsDiscover(Type underlyingType)
    {
        _underlyingType = underlyingType;
    }

    public Type GetUnderlyingType(NoxSimpleTypeDefinition attribute)
    {
        return _underlyingType;
    }
}