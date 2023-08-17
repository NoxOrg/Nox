using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Diagnostics;

namespace Nox.Types.EntityFramework.Abstractions
{
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

        public virtual void ConfigureEntity(
            NoxSolutionCodeGeneratorState codeGeneratorState,
            EntityTypeBuilder builder,
            Entity entity,
            IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate)
        {
            ConfigureKeys(codeGeneratorState, builder, entity);

            ConfigureAttributes(codeGeneratorState, builder, entity);

            ConfigureRelationships(codeGeneratorState, builder, entity, relationshipsToCreate);
        }

        public virtual void ConfigureRelationships(
            NoxSolutionCodeGeneratorState codeGeneratorState,
            EntityTypeBuilder builder,
            Entity entity,
            IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate)
        {

            foreach (var relationshipToCreate in relationshipsToCreate)
            {
                // One to ?? (// Many to Many are setup by EF)
                if (relationshipToCreate.Relationship.ShouldGenerateForeignOnThisSide() && relationshipToCreate.Relationship.WithSingleEntity())
                {
                    //One to Many
                    if (relationshipToCreate.Relationship.IsManyRelationshipOnOtherSide())
                    {
                        //#if DEBUG
                        Console.WriteLine($"***Relationship oneToMany {entity.Name}," +
                           $"Name {relationshipToCreate.Relationship.Name} " +
                           $"HasOne {$"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}"} , {relationshipToCreate.Relationship.Entity} " +
                           $"WithMany {entity.PluralName} " +
                           $"ForeignKey {relationshipToCreate.Relationship.Entity}Id " +
                           $"");
                        //#endif

                        builder
                            .HasOne($"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}", relationshipToCreate.Relationship.Entity)
                            .WithMany(entity.PluralName)
                            .HasForeignKey($"{relationshipToCreate.Relationship.Entity}Id");
                    }
                    else //One to One
                    {
                        //#if DEBUG2
                        Console.WriteLine($"***Relationship oneToOne {entity.Name} ," +
                            $"Name {relationshipToCreate.Relationship.Name} " +
                            $"HasOne {relationshipToCreate.Relationship.Entity} " +
                            $"WithOne {entity.Name}" +
                            $"ForeignKey {relationshipToCreate.Relationship.Entity}Id " +
                            $"");
                        //#endif
                        builder
                            .HasOne(relationshipToCreate.Relationship.Entity)
                            .WithOne(entity.Name)
                            .HasForeignKey(entity.Name, $"{relationshipToCreate.Relationship.Entity}Id");
                    }

                    // Setup foreign key property
                    ConfigureRelationForeignKeyProperty(codeGeneratorState, builder, entity, relationshipToCreate);
                }

                if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation())
                {
                    Console.WriteLine($"***Ignoring Navigation {relationshipToCreate.Relationship.Name}");
                    builder.Ignore(relationshipToCreate.Relationship.Name);
                }
            }
        }

        private void ConfigureRelationForeignKeyProperty(NoxSolutionCodeGeneratorState codeGeneratorState,
            EntityTypeBuilder builder,
            Entity entity,
            EntityRelationshipWithType relationshipToCreate)
        {
            // Right now assuming that there is always one key present
            var key = relationshipToCreate.Relationship.Related.Entity.Keys![0];
            if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                out var databaseConfiguration))
            {
                Console.WriteLine($"++++ConfigureRelationForeignKeyProperty {entity.Name}, " +
                    $"rel {relationshipToCreate.Relationship.Name} " +
                    $"Property {relationshipToCreate.Relationship.Related.Entity.Name}Id, " +
                    $"Keytype {key.Type}");

                var keyToBeConfigured = key.ShallowCopy();
                keyToBeConfigured.Name = $"{relationshipToCreate.Relationship.Related.Entity.Name}Id";
                keyToBeConfigured.Description = $"Foreign key for entity {relationshipToCreate.Relationship.Related.Entity.Name}";
                keyToBeConfigured.IsRequired = false;
                keyToBeConfigured.IsReadonly = false;
                databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, keyToBeConfigured, entity, false);
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
                        throw new Exception($"Could not find DatabaseConfigurator for type {key.Type} entity {entity.Name}");
                    }
                }

                builder.HasKey(keysPropertyNames.ToArray());
            }
        }

        private void ConfigureEntityKeyForEntityForeignKey(NoxSolutionCodeGeneratorState codeGeneratorState, EntityTypeBuilder builder, Entity entity, NoxSimpleTypeDefinition key)
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
    }
}