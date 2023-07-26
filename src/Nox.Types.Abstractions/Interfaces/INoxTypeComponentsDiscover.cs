using System;

namespace Nox.Types;

public interface INoxTypeComponentsDiscover
{
    public Type GeUnderlyingType(NoxSimpleTypeDefinition attribute);
}