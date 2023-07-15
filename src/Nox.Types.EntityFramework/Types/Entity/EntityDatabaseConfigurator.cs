using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Exceptions;

namespace Nox.Types.EntityFramework.Types;

public class EntityDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Entity;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        // TODO: Default values from static property in the Nox.Type
        var typeOptions = GetTypeOptions(property);

        // Setup navigation Property and Foreign Key
        builder.HasOne($"{typeOptions.Entity}")
            .WithOne()
            .If(isKey,
                b=> b.HasForeignKey($"{entity.Name}",
                new[] { codeGeneratorState.GetForeignKeyPropertyName(typeOptions.Entity) }));
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