using System;

namespace Nox.Types;

internal class NumberTypeComponentsDiscover : INoxTypeComponentsDiscover
{
    public Type GetUnderlyingType(NoxSimpleTypeDefinition attribute)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = attribute.NumberTypeOptions ?? new NumberTypeOptions();

        return typeOptions.GetUnderlyingType();
    }
}