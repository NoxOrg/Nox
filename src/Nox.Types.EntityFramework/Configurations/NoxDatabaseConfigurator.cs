using Nox.Solution;
using Nox.Infrastructure;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types.EntityFramework.Exceptions;


namespace Nox.Types.EntityFramework.Configurations
{
    public abstract class NoxDatabaseConfigurator : INoxDatabaseConfigurator
    {
        //We could use the container to manage this
        protected readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesDatabaseConfigurations = new();

        protected NoxCodeGenConventions CodeGenConventions { get; }
        protected INoxClientAssemblyProvider ClientAssemblyProvider { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="NoxDatabaseConfigurator"/> class.
        /// </summary>
        /// <param name="configurators">An enumerable collection of INoxTypeDatabaseConfigurator instances to configure the database mappings.</param>
        /// <param name="codeGenConventions">The code generation conventions to be used.</param>
        /// <param name="clientAssemblyProvider">The provider for client assemblies.</param>
        /// <param name="databaseProviderSpecificOverrides">The type used to identify and override specific database provider configurators.</param>
        /// <remarks>
        /// This constructor initializes the database configurator with a collection of type-specific configurators.
        /// It sets up default configurations and applies provider-specific overrides where necessary.
        /// </remarks>
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
        /// <param name="modelBuilder">Model builder type of <see cref="ModelBuilder"/>.</param>
        /// <param name="builder">Entity builder type of <see cref="IEntityBuilder"/>.</param>
        /// <param name="entity">Entity param type of <see cref="Entity"/>.</param>
        public virtual void ConfigureEntity(
            ModelBuilder modelBuilder,
            IEntityBuilder builder,
            Entity entity)
        {
            var relationshipsToCreate = GetRelationshipsToCreate(entity);
            var ownedRelationshipsToCreate = GetOwnedRelationshipsToCreate(entity);

            ConfigureKeys(CodeGenConventions, builder, entity, entity.Keys);

            ConfigureAttributes(CodeGenConventions, builder, entity);

            ConfigureSystemFields(builder, entity);

            ConfigureRelationships(CodeGenConventions, builder, entity, relationshipsToCreate);

            ConfigureOwnedRelationships(CodeGenConventions, modelBuilder, builder, entity, ownedRelationshipsToCreate);

            ConfigureUniqueAttributeConstraints(builder, entity);
            
            ConfigureAutoNumberAttributeSequences(modelBuilder, entity);
        }

        public virtual void ConfigureLocalizedEntity(
            IEntityBuilder builder,
            Entity entity)
        {
            var localizedEntity = entity.ShallowCopy(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name));

            var keys = new List<NoxSimpleTypeDefinition>()
            {
                // Configure same keys as Entity
                new NoxSimpleTypeDefinition()
                {
                    // We only support entities with single key
                    Name = entity.Keys.Single().Name,
                    Type = NoxType.EntityId, // Create Foreign key to Main Entity
                    EntityIdTypeOptions = new EntityIdTypeOptions()
                    {
                        Entity = entity.Name
                    }
                },
                // And add Culture Code has Key
                new NoxSimpleTypeDefinition()
                {
                    Name = CodeGenConventions.LocalizationCultureField,
                    Type = NoxType.CultureCode,
                    IsRequired = true,
                }
            };

            //Configure keys without navigation properties
            ConfigureKeys(CodeGenConventions, builder, localizedEntity, keys, configureNavigationProperty: true, deleteBehavior: DeleteBehavior.Cascade);

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
                if (!relationshipToCreate.Relationship.ConfigureThisSide())
                    continue;

                var navigationPropertyName = entity.GetNavigationPropertyName(relationshipToCreate.Relationship);
                var reversedNavigationPropertyName = relationshipToCreate.Relationship.Related.Entity.GetNavigationPropertyName(
                    relationshipToCreate.Relationship.Related.EntityRelationship);
                // Many to Many
                // Currently, configured bi-directionally, shouldn't cause any issues.
                if (relationshipToCreate.Relationship.WithMultiEntity && relationshipToCreate.Relationship.Related.EntityRelationship.WithMultiEntity)
                {
                        builder
                        .HasMany(navigationPropertyName)
                        .WithMany(reversedNavigationPropertyName)
                        .UsingEntity(x => x.ToTable(relationshipToCreate.Relationship.Name));
                }
                // OneToOne and OneToMany, setup should be done only on foreign key side
                else if (relationshipToCreate.Relationship.WithSingleEntity())
                {
                    //One to Many
                    if (relationshipToCreate.Relationship.Related.EntityRelationship.WithMultiEntity)
                    {
                        //#if DEBUG
                        Console.WriteLine($"***Relationship oneToMany {entity.Name}," +
                           $"Name {relationshipToCreate.Relationship.Name} " +
                           $"HasOne {$"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}"}, {navigationPropertyName} " +
                           $"WithMany {reversedNavigationPropertyName} " +
                           $"ForeignKey {navigationPropertyName}Id " +
                           $"");
                        //#endif

                        builder
                            .HasOne($"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}", navigationPropertyName)
                            .WithMany(reversedNavigationPropertyName)
                            .HasForeignKey($"{navigationPropertyName}Id")
                            .OnDelete(DeleteBehavior.ClientSetNull);
                    }
                    else //One to One
                    {
                        //#if DEBUG2
                        Console.WriteLine($"***Relationship oneToOne {entity.Name} ," +
                            $"Name {relationshipToCreate.Relationship.Name} " +
                            $"HasOne {codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}, {navigationPropertyName} " +
                            $"WithOne {reversedNavigationPropertyName}" +
                            $"ForeignKey {navigationPropertyName}Id " +
                            $"");
                        //#endif
                        builder
                            .HasOne($"{codeGeneratorState.DomainNameSpace}.{relationshipToCreate.Relationship.Entity}", navigationPropertyName)
                            .WithOne(reversedNavigationPropertyName)
                            .HasForeignKey(entity.Name, $"{navigationPropertyName}Id")
                            .OnDelete(DeleteBehavior.ClientSetNull);
                    }

                    // Setup foreign key property
                    ConfigureRelationForeignKeyProperty(codeGeneratorState, builder, entity, relationshipToCreate);
                }
            }
        }

        protected virtual void ConfigureOwnedRelationships(
            NoxCodeGenConventions codeGeneratorState,
            ModelBuilder modelBuilder,
            IEntityBuilder builder,
            Entity entity,
            IReadOnlyList<EntityRelationshipWithType> ownedRelationshipsToCreate)
        {
            foreach (var relationshipToCreate in ownedRelationshipsToCreate)
            {
                var navigationPropertyName = entity.GetNavigationPropertyName(relationshipToCreate.Relationship);
                if (relationshipToCreate.Relationship.WithSingleEntity())
                {
                    builder
                        .OwnsOne(relationshipToCreate.RelationshipEntityType, navigationPropertyName, x =>
                        {
                            ConfigureEntity(modelBuilder,new OwnedNavigationBuilderAdapter(x), relationshipToCreate.Relationship.Related.Entity);
                        });
                }
                else
                {
                    builder
                        .OwnsMany(relationshipToCreate.RelationshipEntityType, navigationPropertyName, x =>
                        {
                            ConfigureEntity(modelBuilder,new OwnedNavigationBuilderAdapter(x), relationshipToCreate.Relationship.Related.Entity);
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
            var relationshipName = entity.GetNavigationPropertyName(relationshipToCreate.Relationship);
            if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                out var databaseConfiguration))
            {
                Console.WriteLine($"++++ConfigureRelationForeignKeyProperty {entity.Name}, " +
                    $"rel {relationshipToCreate.Relationship.Name} " +
                    $"Property {relationshipName}Id, " +
                    $"Keytype {key.Type}");

                var keyToBeConfigured = key.ShallowCopy();
                keyToBeConfigured.Name = $"{relationshipName}Id";
                keyToBeConfigured.Description = $"Foreign key for entity {relationshipToCreate.Relationship.Name}";
                keyToBeConfigured.IsRequired = relationshipToCreate.Relationship.IsRequired();
                keyToBeConfigured.IsReadonly = false;
                databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, keyToBeConfigured, entity, isKey: false);
            }
        }

        protected virtual void ConfigureKeys(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity,
            IReadOnlyList<NoxSimpleTypeDefinition> keys,
            bool configureNavigationProperty = true,
            DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
        {
            if (keys is { Count: > 0 })
            {
                var keysPropertyNames = new List<string>(keys.Count);
                foreach (var key in keys)
                {
                    if (key.Type == NoxType.EntityId) //its key and foreign key
                    {
                        Console.WriteLine($"    Setup Key {key.Name} as Foreign Key for Entity {entity.Name}");

                        ConfigureEntityKeyForEntityForeignKey(codeGeneratorState, builder, entity, key, configureNavigationProperty, configureToManyRelationship: keys.Count > 1, deleteBehavior);
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
                        throw new DatabaseConfigurationException(key.Type,  entity.Name);
                    }
                }

                builder.HasKey(keysPropertyNames.ToArray());
            }
        }

        protected virtual void ConfigureEntityKeyForEntityForeignKey(
            NoxCodeGenConventions codeGeneratorState,
            IEntityBuilder builder,
            Entity entity,
            NoxSimpleTypeDefinition key,
            bool configureNavigationProperty = true,
            bool configureToManyRelationship = false,
            DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
        {
            // Key type of the Foreign Entity Key
            var foreignEntityKeyType = codeGeneratorState.Solution.GetSingleKeyTypeForEntity(key.EntityIdTypeOptions!.Entity);

            var relatedTypeName = CodeGenConventions.GetEntityTypeFullName(key.EntityIdTypeOptions.Entity);
            var navigationName = key.EntityIdTypeOptions!.Entity;

            if (configureToManyRelationship)
            {
                builder
                    .HasOne(relatedTypeName, navigationName)
                    .WithMany()
                    .HasForeignKey(key.Name)
                    .OnDelete(deleteBehavior);
            }
            else
            {
                builder
                    .HasOne(relatedTypeName, navigationName)
                    .WithOne()
                    .HasForeignKey(entity.Name, key.Name)
                    .OnDelete(deleteBehavior);
            }

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
#pragma warning disable CS0618 // Type or member is obsolete
            var attributes = entity.GetAttributesToLocalizeAsNotRequired().ToList();
#pragma warning restore CS0618 // Type or member is obsolete

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
        
        protected virtual void ConfigureAutoNumberAttributeSequences(ModelBuilder modelBuilder, Entity entity) {}
        
    }

}