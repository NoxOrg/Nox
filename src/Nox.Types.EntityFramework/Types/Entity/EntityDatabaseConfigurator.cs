using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Exceptions;

namespace Nox.Types.EntityFramework.Types;

public class EntityDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.EntityId;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        // Nothing to do, all done by EF Automatically
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key)
    {
        var typeOptions = GetTypeOptions(key);

        return $"{typeOptions.Entity}Id";
    }

    private static EntityIdTypeOptions GetTypeOptions(NoxSimpleTypeDefinition property)
    {
        var typeOptions = property.EntityIdTypeOptions;

        if (typeOptions == null)
        {
            throw new NoxDatabaseProviderException("Entity Nox.Type must have a EntityTypeOptions properly defined.");
        }

        return typeOptions;
    }
}