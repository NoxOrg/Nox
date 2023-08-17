using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Exceptions;

namespace Nox.Types.EntityFramework.Types;

public class EntityDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Entity;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        // Nothing to do, all done by EF Automatically
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key)
    {
        var typeOptions = GetTypeOptions(key);

        return $"{typeOptions.Entity}Id";
    }

    private static EntityTypeOptions GetTypeOptions(NoxSimpleTypeDefinition property)
    {
        var typeOptions = property.EntityTypeOptions;

        if (typeOptions == null)
        {
            throw new NoxDatabaseProviderException("Entity Nox.Type must have a EntityTypeOptions properly defined.");
        }

        return typeOptions;
    }
}