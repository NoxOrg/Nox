using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Types;
using System.Diagnostics;

namespace Nox.Types.EntityFramework.Abstractions;

// TODO: remove
#pragma warning disable S4136 // Method overloads should be grouped together

public abstract class NoxDatabaseConfigurator : INoxDatabaseConfigurator
{
    //We could use the container to manage this
    protected readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesDatabaseConfigurations = new();

    /// <summary>
    ///
    /// </summary>
    /// <param name="configurators">List of all loaded <see cref="INoxTypeDatabaseConfigurator"/></param>
    /// <param name="databaseProviderSpecificOverrides">Configurator type specific to database provider</param>
    protected NoxDatabaseConfigurator(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        Type databaseProviderSpecificOverrides)
    {
        var noxTypeDatabaseConfigurators =
            configurators as INoxTypeDatabaseConfigurator[] ?? configurators.ToArray();

        foreach (var configurator in noxTypeDatabaseConfigurators)
        {
            if (configurator.IsDefault)
            {
                TypesDatabaseConfigurations.Add(configurator.ForNoxType, configurator);
            }
        }

        // Override specific database provider configurators
        foreach (var configurator in noxTypeDatabaseConfigurators.Where(databaseProviderSpecificOverrides.IsInstanceOfType))
        {
            TypesDatabaseConfigurations[configurator.ForNoxType] = configurator;
        }
    }

    #region EntityTypeBuilder

    public virtual void ConfigureEntity(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity,
        NoxSolution noxSolution,
        Func<string, Type?> getTypeByNameFunc)
    {
        var relationshipsToCreate = noxSolution.GetRelationshipsToCreate(getTypeByNameFunc, entity);
        var ownedRelationshipsToCreate = noxSolution.GetOwnedRelationshipsToCreate(getTypeByNameFunc, entity);

        ConfigureKeys(codeGeneratorState, builder, entity);

        ConfigureAttributes(codeGeneratorState, builder, entity);

        ConfigureRelationships(codeGeneratorState, builder, entity, relationshipsToCreate);

        ConfigureOwnedRelationships(codeGeneratorState, builder, entity, ownedRelationshipsToCreate, noxSolution, getTypeByNameFunc);
    }

    public virtual void ConfigureRelationships(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity,
        IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate)
    {
        foreach (var relationshipToCreate in relationshipsToCreate)
        {
            // ManyToMany does not need to be handled
            // Handle ZeroOrOne or ExactlyOne scenario with foreign key.
            if (relationshipToCreate.Relationship.HasRelationshipWithSingularEntity() &&
                relationshipToCreate.Relationship.ShouldGenerateForeignOnThisSide() &&
                !relationshipToCreate.Relationship.IsManyRelationshipOnOtherSide())
            {
                builder
                    .HasOne(relationshipToCreate.Relationship.Entity)
                    .WithOne(entity.Name)
                    .HasForeignKey(entity.Name, $"{relationshipToCreate.Relationship.Entity}Id");

                // Setup one to one foreign key
                ConfigureRelationForeignKeyProperty(codeGeneratorState, builder, entity, relationshipToCreate);
            }

            if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation())
            {
                builder.Ignore(relationshipToCreate.Relationship.Name);
            }
        }
    }

    private void ConfigureRelationForeignKeyProperty(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity,
        EntityRelationshipWithType relationshipToCreate)
    {
        // Right now assuming that there is always one key present
        var key = relationshipToCreate.Relationship.Related.Entity.Keys![0];
        if (TypesDatabaseConfigurations.TryGetValue(key.Type,
            out var databaseConfiguration))
        {
            var keyToBeConfigured = key.ShallowCopy();
            keyToBeConfigured.Name = $"{relationshipToCreate.Relationship.Related.Entity.Name}Id";
            keyToBeConfigured.Description = $"Foreign key for entity {relationshipToCreate.Relationship.Related.Entity.Name}";
            keyToBeConfigured.IsRequired = false;
            keyToBeConfigured.IsReadonly = false;
            databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, keyToBeConfigured, entity, false);
        }
    }

    public virtual void ConfigureOwnedRelationships(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity,
        IReadOnlyList<EntityRelationshipWithType> ownedRelationshipsToCreate,
        NoxSolution noxSolution,
        Func<string, Type?> getTypeByNameFunc)
    {
        foreach (var relationshipToCreate in ownedRelationshipsToCreate)
        {
            if (relationshipToCreate.Relationship.HasRelationshipWithSingularEntity())
            {
                builder
                    .OwnsOne(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.Entity, x =>
                    {
                        ConfigureEntity(codeGeneratorState, x, relationshipToCreate.Relationship.Related.Entity, noxSolution, getTypeByNameFunc);
                    });
            }
            else
            {
                builder
                    .OwnsMany(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.EntityPlural, x =>
                    {
                        ConfigureEntity(codeGeneratorState, x, relationshipToCreate.Relationship.Related.Entity, noxSolution, getTypeByNameFunc);
                    });
            }

            if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation())
            {
                builder.Ignore(relationshipToCreate.Relationship.Name);
            }
        }
    }

    private void ConfigureKeys(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity)
    {            
        if (entity.Keys is { Count: > 0 })
        {
            var keysPropertyNames = new List<string>(entity.Keys.Count);
            foreach (var key in entity.Keys)
            {
                if (key.Type == NoxType.Entity) //its key and foreign key
                {
                    Console.WriteLine($"    Setup Key {key.Name} as Foreign Key for Entity {entity.Name}");

                    ConfigureEntityKeyForEntityForeignKey(codeGeneratorState, builder, entity, key);
                    keysPropertyNames.Add(key.Name);
                }
                else if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                        out var databaseConfiguration))
                {
                    Console.WriteLine($"    Setup Key {key.Name} for Entity {entity.Name}");
                    keysPropertyNames.Add(databaseConfiguration.GetKeyPropertyName(key));
                    databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, key, entity, true);
                }
                else
                {
                    // TODO: change from generic
#pragma warning disable S112 // General exceptions should never be thrown
                    throw new Exception($"Could not find DatabaseConfigurator for type {key.Type} entity {entity.Name}");
#pragma warning restore S112 // General exceptions should never be thrown
                }
            }

            builder.HasKey(keysPropertyNames.ToArray());
        }
    }

    private void ConfigureEntityKeyForEntityForeignKey(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity,
        NoxSimpleTypeDefinition key)
    {
        // Key type of the Foreign Entity Key
        var foreignEntityKeyType = codeGeneratorState.Solution.GetSingleKeyTypeForEntity(key.EntityTypeOptions!.Entity);

        builder
            .HasOne(key.EntityTypeOptions!.Entity)
            .WithOne()
            .HasForeignKey(entity.Name, key.Name);

        //Configure foreign key property
        if (TypesDatabaseConfigurations.TryGetValue(foreignEntityKeyType,
            out var databaseConfigurationForForeignKey))
        {
            var foreignEntityKeyDefinition = codeGeneratorState.Solution.Domain!.GetEntityByName(key.EntityTypeOptions!.Entity).Keys![0].ShallowCopy();
            foreignEntityKeyDefinition.Name = key.Name;
            foreignEntityKeyDefinition.Description = "-";
            foreignEntityKeyDefinition.IsRequired = false;
            foreignEntityKeyDefinition.IsReadonly = false;
            databaseConfigurationForForeignKey.ConfigureEntityProperty(codeGeneratorState, builder, foreignEntityKeyDefinition, entity, false);
        }
    }

    private void ConfigureAttributes(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        EntityTypeBuilder builder,
        Entity entity)
    {
        if (entity.Attributes is { Count: > 0 })
        {
            foreach (var property in entity.Attributes)
            {
                if (TypesDatabaseConfigurations.TryGetValue(property.Type,
                    out var databaseConfiguration))
                {
                    databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, property, entity,
                        false);
                }
                else
                {
                    Debug.WriteLine($"Type {property.Type} not found");
                }
            }
        }
    }

    #endregion

    #region OwnedNavigationBuilder

    public virtual void ConfigureEntity(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity,
        NoxSolution noxSolution,
        Func<string, Type?> getTypeByNameFunc)
    {
        var relationshipsToCreate = noxSolution.GetRelationshipsToCreate(getTypeByNameFunc, entity);
        var ownedRelationshipsToCreate = noxSolution.GetOwnedRelationshipsToCreate(getTypeByNameFunc, entity);

        ConfigureKeys(codeGeneratorState, builder, entity);

        ConfigureAttributes(codeGeneratorState, builder, entity);

        ConfigureRelationships(codeGeneratorState, builder, entity, relationshipsToCreate);

        ConfigureOwnedRelationships(codeGeneratorState, builder, entity, ownedRelationshipsToCreate, noxSolution, getTypeByNameFunc);
    }

    public virtual void ConfigureRelationships(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity,
        IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate)
    {
        foreach (var relationshipToCreate in relationshipsToCreate)
        {
            // ManyToMany does not need to be handled
            // Handle ZeroOrOne or ExactlyOne scenario with foreign key.
            if (relationshipToCreate.Relationship.HasRelationshipWithSingularEntity() &&
                relationshipToCreate.Relationship.ShouldGenerateForeignOnThisSide() &&
                !relationshipToCreate.Relationship.IsManyRelationshipOnOtherSide())
            {
                builder
                    .HasOne(relationshipToCreate.Relationship.Entity)
                    .WithOne(entity.Name)
                    .HasForeignKey(entity.Name, $"{relationshipToCreate.Relationship.Entity}Id");

                // Setup one to one foreign key
                ConfigureRelationForeignKeyProperty(codeGeneratorState, builder, entity, relationshipToCreate);
            }

            if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation())
            {
                builder.Ignore(relationshipToCreate.Relationship.Name);
            }
        }
    }

    private void ConfigureRelationForeignKeyProperty(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity,
        EntityRelationshipWithType relationshipToCreate)
    {
        // Right now assuming that there is always one key present
        var key = relationshipToCreate.Relationship.Related.Entity.Keys![0];
        if (TypesDatabaseConfigurations.TryGetValue(key.Type,
            out var databaseConfiguration))
        {
            var keyToBeConfigured = key.ShallowCopy();
            keyToBeConfigured.Name = $"{relationshipToCreate.Relationship.Related.Entity.Name}Id";
            keyToBeConfigured.Description = $"Foreign key for entity {relationshipToCreate.Relationship.Related.Entity.Name}";
            keyToBeConfigured.IsRequired = false;
            keyToBeConfigured.IsReadonly = false;
            var textConfigurator = new TextDatabaseConfigurator();
            textConfigurator.ConfigureEntityProperty(codeGeneratorState, builder, keyToBeConfigured, entity, false);
        }
    }

    public virtual void ConfigureOwnedRelationships(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity,
        IReadOnlyList<EntityRelationshipWithType> ownedRelationshipsToCreate,
        NoxSolution noxSolution,
        Func<string, Type?> getTypeByNameFunc)
    {
        foreach (var relationshipToCreate in ownedRelationshipsToCreate)
        {
            if (relationshipToCreate.Relationship.HasRelationshipWithSingularEntity())
            {
                builder
                    .OwnsOne(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.Entity, x =>
                    {
                        ConfigureEntity(codeGeneratorState, x, relationshipToCreate.Relationship.Related.Entity, noxSolution, getTypeByNameFunc);
                    });
            }
            else
            {
                builder
                    .OwnsMany(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.EntityPlural, x =>
                    {
                        ConfigureEntity(codeGeneratorState, x, relationshipToCreate.Relationship.Related.Entity, noxSolution, getTypeByNameFunc);
                    });
            }

            if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation())
            {
                builder.Ignore(relationshipToCreate.Relationship.Name);
            }
        }
    }

    private void ConfigureKeys(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity)
    {
        if (entity.Keys is { Count: > 0 })
        {
            var keysPropertyNames = new List<string>(entity.Keys.Count);
            foreach (var key in entity.Keys)
            {
                if (key.Type == NoxType.Entity) //its key and foreign key
                {
                    Console.WriteLine($"    Setup Key {key.Name} as Foreign Key for Entity {entity.Name}");

                    ConfigureEntityKeyForEntityForeignKey(codeGeneratorState, builder, entity, key);
                    keysPropertyNames.Add(key.Name);
                }
                else if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                        out var databaseConfiguration))
                {
                    Console.WriteLine($"    Setup Key {key.Name} for Entity {entity.Name}");
                    keysPropertyNames.Add(databaseConfiguration.GetKeyPropertyName(key));
                    var textConfigurator = new TextDatabaseConfigurator();
                    textConfigurator.ConfigureEntityProperty(codeGeneratorState, builder, key, entity, true);
                }
                else
                {
                    // TODO: change from generic
#pragma warning disable S112 // General exceptions should never be thrown
                    throw new Exception($"Could not find DatabaseConfigurator for type {key.Type} entity {entity.Name}");
#pragma warning restore S112 // General exceptions should never be thrown
                }
            }

            builder.HasKey(keysPropertyNames.ToArray());
        }
    }

    private void ConfigureEntityKeyForEntityForeignKey(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity,
        NoxSimpleTypeDefinition key)
    {
        // Key type of the Foreign Entity Key
        var foreignEntityKeyType = codeGeneratorState.Solution.GetSingleKeyTypeForEntity(key.EntityTypeOptions!.Entity);

        builder
            .HasOne(key.EntityTypeOptions!.Entity)
            .WithOne()
            .HasForeignKey(entity.Name, key.Name);

        //Configure foreign key property
        if (TypesDatabaseConfigurations.TryGetValue(foreignEntityKeyType,
            out var databaseConfigurationForForeignKey))
        {
            var foreignEntityKeyDefinition = codeGeneratorState.Solution.Domain!.GetEntityByName(key.EntityTypeOptions!.Entity).Keys![0].ShallowCopy();
            foreignEntityKeyDefinition.Name = key.Name;
            foreignEntityKeyDefinition.Description = "-";
            foreignEntityKeyDefinition.IsRequired = false;
            foreignEntityKeyDefinition.IsReadonly = false;
            var textConfigurator = new TextDatabaseConfigurator();
            textConfigurator.ConfigureEntityProperty(codeGeneratorState, builder, foreignEntityKeyDefinition, entity, false);
        }
    }

    private void ConfigureAttributes(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        OwnedNavigationBuilder builder,
        Entity entity)
    {
        if (entity.Attributes is { Count: > 0 })
        {
            foreach (var property in entity.Attributes)
            {
                if (TypesDatabaseConfigurations.TryGetValue(property.Type,
                    out var databaseConfiguration))
                {
                    var textConfigurator = new TextDatabaseConfigurator();
                    textConfigurator.ConfigureEntityProperty(codeGeneratorState, builder, property, entity,
                        false);
                }
                else
                {
                    Debug.WriteLine($"Type {property.Type} not found");
                }
            }
        }
    }

    #endregion
}
#pragma warning restore S4136 // Method overloads should be grouped together