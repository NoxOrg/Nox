using Nox.Types;

namespace Nox.Solution.Extensions;

public static class NoxSimpleTypeDefinitionExtensions
{
    public static AttributeConfiguration ToAttributeConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new( property );
    }
    public static AttributeConfiguration ToLocalizedAttributeConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new( property, false);
    }
    
    public static AttributeConfiguration ToRelationKeyConfiguration(this NoxSimpleTypeDefinition property,  string name, string description, bool isReadonly, bool isRequired)
    {
        return new( property, name, description, isReadonly, isRequired);
    }
   
}