using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.ComponentsDiscover;

internal class NumberTypeComponentsDiscover : INoxTypeComponentsDiscover
{
    public Type GetUnderlyingType(NoxSimpleTypeDefinition attribute)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = attribute.NumberTypeOptions ?? new NumberTypeOptions();

        return typeOptions.GetUnderlyingType();
    }
}