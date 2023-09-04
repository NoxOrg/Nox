using System;

namespace Nox.Types;

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