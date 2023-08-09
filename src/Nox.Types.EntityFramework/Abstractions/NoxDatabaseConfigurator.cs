using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
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
                // ManyToMany does not need to be handled
                // Handle ZeroOrOne or ExactlyOne scenario with foreign key.
                if (relationshipToCreate.Relationship.HasRelationshipWithSingularEntity &&
                    relationshipToCreate.Relationship.ShouldGenerateForeignOnThisSide &&
                    !relationshipToCreate.Relationship.IsManyRelationshipOnOtherSide)
                {
                    builder
                        .HasOne(relationshipToCreate.Relationship.Entity)
                        .WithOne(entity.Name)
                        .HasForeignKey(entity.Name, $"{relationshipToCreate.Relationship.Entity}Id");

                    // Setup one to one foreign key
                    SetupForeignKey(codeGeneratorState, builder, entity, relationshipToCreate);
                }

                if (!relationshipToCreate.Relationship.ShouldUseRelationshipNameAsNavigation)
                {
                    builder.Ignore(relationshipToCreate.Relationship.Name);
                }
            }
        }

        private void SetupForeignKey(NoxSolutionCodeGeneratorState codeGeneratorState, EntityTypeBuilder builder, Entity entity, EntityRelationshipWithType relationshipToCreate)
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

                builder.Ignore(relationshipToCreate.Relationship.Name);
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
                    if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                            out var databaseConfiguration))
                    {
                        keysPropertyNames.Add(databaseConfiguration.GetKeyPropertyName(key));
                        databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, key, entity, true);
                    }
                    else
                    {
                        Debug.WriteLine($"Database Configurator not found for Type {key.Type}");
                        // Fallback to default
                        keysPropertyNames.Add(key.Name);
                    }
                }

                builder.HasKey(keysPropertyNames.ToArray());
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