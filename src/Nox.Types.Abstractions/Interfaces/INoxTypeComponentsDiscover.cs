using System;

namespace Nox.Types;

public interface INoxTypeComponentsDiscover
{
    public Type GetUnderlyingType(NoxSimpleTypeDefinition attribute);
}