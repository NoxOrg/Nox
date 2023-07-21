using System;

namespace Nox.Types;

internal record NoxTypeComponentsDiscover : INoxTypeComponentsDiscover
{
    private readonly Type _underlyingType;

    public NoxTypeComponentsDiscover(Type underlyingType)
    {
        _underlyingType = underlyingType;
    }

    public Type GeUnderlyingType(NoxSimpleTypeDefinition attribute)
    {
        return _underlyingType;
    }
}