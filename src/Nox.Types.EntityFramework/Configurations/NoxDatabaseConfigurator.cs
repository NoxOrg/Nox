using Nox.Solution;
using Nox.Infrastructure;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Nox.Types.EntityFramework.Configurations
{
    public abstract class NoxDatabaseConfigurator : INoxDatabaseConfigurator
    {
        //We could use the container to manage this
        protected readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesDatabaseConfigurations = new();

        protected NoxCodeGenConventions CodeGenConventions { get; }
        protected INoxClientAssemblyProvider ClientAssemblyProvider { get; }


        /// <summary>
        ///
        /// </summary>
        /// <param name="configurators">List of all loaded <see cref="INoxTypeDatabaseConfigurator"/></param>
        /// <param name="databaseProviderSpecificOverrides">Configurator type specific to database provider</param>
        protected NoxDatabaseConfigurator(
            IEnumerable<INoxTypeDatabaseConfigurator> configurators,
            NoxCodeGenConventions codeGenConventions,
            INoxClientAssemblyProvider clientAssemblyProvider,
            Type databaseProviderSpecificOverrides)
        {
            CodeGenConventions = codeGenConventions;
            ClientAssemblyProvider = clientAssemblyProvider;

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
        /// <summary>
        /// Configure the data base model for an Entity
        /// </summary>
        /// <param name="entityResolverByName">Function to resolve an Entity name to a Type</param>
        public virtual void ConfigureEntity(
            IEntityBuilder builder,
            Entity entity)
        {
            var relationshipsToCreate = GetRelationshipsToCreate(entity);
            var ownedRelationshipsToCreate = GetOwnedRelationshipsToCreate(entity);

            ConfigureKeys(CodeGenConventions, builder, entity);

            ConfigureAttributes(CodeGenConventions, builder, entity);

            ConfigureSystemFields(builder, entity);

            ConfigureRelationships(CodeGenConventions, builder, entity, relationshipsToCreate);

            ConfigureOwnedRelationships(CodeGenConventions, builder, entity, ownedRelationshipsToCreate);

            ConfigureUniqueAttributeConstraints(builder, entity);
        }

        public virtual void ConfigureLocalizedEntity(
            IEntityBuilder builder,
            Entity entity)
        {
            var localizedEntity = entity.ShallowCopy(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name));

            ConfigureKeys(CodeGenConventions, builder, localizedEntity);

            ConfigureLocalizedAttributes(CodeGenConventions, builder, localizedEntity);
        }

        private static void ConfigureSystemFields(IEntityBuilder builder, Entity entity)
        {
            // TODO clarify Auditable for owned entities
            if (entity.Persistence?.IsAudited == true && !entity.IsOwnedEntity)
            {
                builder.Property("CreatedAtUtc");
                builder.Property("CreatedBy").HasMaxLength(255);
                builder.Property("CreatedVia").HasMaxLength(255).IsUnicode(false);

                builder.Property("LastUpdatedAtUtc").IsRequired(false);
                builder.Property("LastUpdatedBy").IsRequired(false).HasMaxLength(255);
                builder.Property("LastUpdatedVia").IsRequired(false).HasMaxLength(255).IsUnicode(false);

                builder.Property("DeletedAtUtc").IsRequired(false);
                builder.Property("DeletedBy").IsRequired(false).HasMaxLength(255);
                builder.Property("DeletedVia").IsRequired(false).HasMaxLength(255).IsUnicode(false);
            }
        }

        protected virtual void ConfigureRelationships(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity,
            IReadOnlyList<EntityRelationshipWithType> relationshipsToCreate)
        {
            foreach (var relationshipToCreate in relationshipsToCreate)
            {
                // Many to Many
                // Currently, configured bi-directionally, shouldn't cause any issues.
                if (relationshipToCreate.Relationship.WithMultiEntity &&
                    relationshipToCreate.Relationship.Related.EntityRelationship.WithMultiEntity)
                {
                    builder
                        .HasMany(relationshipToCreate.Relationship.Name)
                        .WithMany(relationshipToCreate.Relationship.Related.EntityRelationship.Name)
                        .UsingEntity(x => x.ToTable(relationshipToCreate.Relationship.Name));
                }
                // OneToOne and OneToMany, setup should be done only on foreign key side
                else if (relationshipToCreate.Relationship.ShouldGenerateForeignKeyOnThisSide() &&
                    relationshipToCreate.Relationship.WithSingleEntity())
                {
                    //One to Many
                    if (relationshipToCreate.Relationship.Related.EntityRelationship.WithMultiEntity)
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
                            .HasOne($"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}", relationshipToCreate.Relationship.Name)
                            .WithMany(relationshipToCreate.Relationship.Related.EntityRelationship.Name)
                            .HasForeignKey($"{relationshipToCreate.Relationship.Name}Id")
                            .OnDelete(DeleteBehavior.ClientSetNull);
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
                            .HasOne($"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}", relationshipToCreate.Relationship.Name)
                            .WithOne(relationshipToCreate.Relationship.Related.EntityRelationship.Name)
                            .HasForeignKey(entity.Name, $"{relationshipToCreate.Relationship.Name}Id")
                            .OnDelete(DeleteBehavior.ClientSetNull); 
                    }

                    // Setup foreign key property
                    ConfigureRelationForeignKeyProperty(codeGeneratorState, builder, entity, relationshipToCreate);
                }
            }
        }

        protected virtual void ConfigureOwnedRelationships(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity,
            IReadOnlyList<EntityRelationshipWithType> ownedRelationshipsToCreate)
        {
            foreach (var relationshipToCreate in ownedRelationshipsToCreate)
            {
                if (relationshipToCreate.Relationship.WithSingleEntity())
                {
                    builder
                        .OwnsOne(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.Name, x =>
                        {
                            ConfigureEntity(new OwnedNavigationBuilderAdapter(x), relationshipToCreate.Relationship.Related.Entity);
                        });
                }
                else
                {
                    builder
                        .OwnsMany(relationshipToCreate.RelationshipEntityType, relationshipToCreate.Relationship.Name, x =>
                        {
                            ConfigureEntity(new OwnedNavigationBuilderAdapter(x), relationshipToCreate.Relationship.Related.Entity);
                        });
                }
            }
        }

        private void ConfigureRelationForeignKeyProperty(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
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
                keyToBeConfigured.Name = $"{relationshipToCreate.Relationship.Name}Id";
                keyToBeConfigured.Description = $"Foreign key for entity {relationshipToCreate.Relationship.Name}";
                keyToBeConfigured.IsRequired = relationshipToCreate.Relationship.IsRequired();                
                keyToBeConfigured.IsReadonly = false;
                databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, keyToBeConfigured, entity, false);
            }
        }

        protected virtual void ConfigureKeys(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity)
        {
            if (entity.Keys is { Count: > 0 })
            {
                var keysPropertyNames = new List<string>(entity.Keys.Count);
                foreach (var key in entity.Keys)
                {
                    if (key.Type == NoxType.EntityId) //its key and foreign key
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

        protected virtual void ConfigureEntityKeyForEntityForeignKey(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity,
            NoxSimpleTypeDefinition key)
        {
            // Key type of the Foreign Entity Key
            var foreignEntityKeyType = codeGeneratorState.Solution.GetSingleKeyTypeForEntity(key.EntityIdTypeOptions!.Entity);

            builder
            .HasOne(key.EntityIdTypeOptions!.Entity)
            .WithOne()
            .HasForeignKey(entity.Name, key.Name);

            //Configure foreign key property
            if (TypesDatabaseConfigurations.TryGetValue(foreignEntityKeyType,
                out var databaseConfigurationForForeignKey))
            {
                var foreignEntityKeyDefinition = codeGeneratorState.Solution.Domain!.GetEntityByName(key.EntityIdTypeOptions!.Entity).Keys![0].ShallowCopy();
                foreignEntityKeyDefinition.Name = key.Name;
                foreignEntityKeyDefinition.Description = "-";
                foreignEntityKeyDefinition.IsRequired = false;
                foreignEntityKeyDefinition.IsReadonly = false;

                databaseConfigurationForForeignKey.ConfigureEntityProperty(codeGeneratorState, builder, foreignEntityKeyDefinition, entity, false);
            }
        }

        protected virtual IList<IndexBuilder> ConfigureUniqueAttributeConstraints(IEntityBuilder builder, Entity entity)
        {
            var result = new List<IndexBuilder>();

            if (entity.Persistence!.IsAudited)
            {
                ConfigureConstraintsWithAuditProperties(builder, entity, result);
            }
            else
            {
                ConfigureConstraints(builder, entity, result);
            }

            return result;
        }

        private static void ConfigureConstraints(IEntityBuilder builder, Entity entity, List<IndexBuilder> result)
        {
            foreach (var uniqueConstraint in entity.UniqueAttributeConstraints!)
            {
                result.Add(builder.HasUniqueAttributeConstraint(uniqueConstraint.AttributeNames.ToArray(),
                    uniqueConstraint.Name));
            }
        }

        private static void ConfigureConstraintsWithAuditProperties(IEntityBuilder builder, Entity entity, List<IndexBuilder> result)
        {
            foreach (var uniqueConstraint in entity.UniqueAttributeConstraints!)
            {
                var auditProperties = new List<string>(uniqueConstraint.AttributeNames.Count + 1);
                auditProperties.AddRange(uniqueConstraint.AttributeNames);
                auditProperties.Add("DeletedAtUtc");
                result.Add(builder.HasUniqueAttributeConstraint(auditProperties.ToArray(), uniqueConstraint.Name));
            }
        }

        protected virtual void ConfigureAttributes(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity)
        {
            if (entity.Attributes is { Count: > 0 })
            {
                foreach (var property in entity.Attributes)
                {
                    if (TypesDatabaseConfigurations.TryGetValue(property.Type, out var databaseConfiguration))
                    {
                        databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, property, entity, false);
                    }
                    else
                    {
                        Debug.WriteLine($"Type {property.Type} not found");
                    }
                }
            }
        }

        protected virtual void ConfigureLocalizedAttributes(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity)
        {
            var attributes = entity.GetAttributesToLocalize().ToList();
            attributes.Add(new NoxSimpleTypeDefinition
            {
                Name = codeGeneratorState.LocalizationCultureField,
                Type = NoxType.CultureCode,
                IsRequired = true,
                IsReadonly = true
            });

            foreach (var property in attributes)
            {
                if (TypesDatabaseConfigurations.TryGetValue(property.Type, out var databaseConfiguration))
                {
                    databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, property, entity, false);
                }
                else
                {
                    Debug.WriteLine($"Type {property.Type} not found");
                }
            }
        }

        private List<EntityRelationshipWithType> GetRelationshipsToCreate(Entity entity)
        {
            var fullRelationshipModels = new List<EntityRelationshipWithType>();


            foreach (var relationship in entity.Relationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = ClientAssemblyProvider.ClientAssembly.GetType(CodeGenConventions.GetEntityTypeFullName(relationship.Entity))!
                });
            }

            return fullRelationshipModels;
        }

        private List<EntityRelationshipWithType> GetOwnedRelationshipsToCreate(Entity entity)
        {
            var fullRelationshipModels = new List<EntityRelationshipWithType>();

            foreach (var relationship in entity.OwnedRelationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = ClientAssemblyProvider.ClientAssembly.GetType(CodeGenConventions.GetEntityTypeFullName(relationship.Entity))!
                });
            }
            return fullRelationshipModels;
        }
    }
  
}