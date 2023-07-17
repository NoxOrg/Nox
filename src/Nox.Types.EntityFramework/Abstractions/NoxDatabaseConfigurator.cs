using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Model;
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
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
            foreach (var configurator in noxTypeDatabaseConfigurators)
            {
                if (databaseProviderSpecificOverrides.IsInstanceOfType(configurator))
                {
                    TypesDatabaseConfigurations[configurator.ForNoxType] = configurator;
                }
            }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
        }

        public virtual void ConfigureEntity(
            NoxSolutionCodeGeneratorState codeGeneratorState,
            EntityTypeBuilder builder,
            Entity entity,
            IReadOnlyList<RelationshipFullModel> relationships)
        {
            ConfigureKeys(codeGeneratorState, builder, entity);

            ConfigureAttributes(codeGeneratorState, builder, entity);

            ConfigureRelationships(codeGeneratorState, builder, entity, relationships);
        }

        public virtual void ConfigureRelationships(
            NoxSolutionCodeGeneratorState codeGeneratorState,
            EntityTypeBuilder builder,
            Entity entity,
            IReadOnlyList<RelationshipFullModel> relationships)
        {
            var entityRelationships = relationships.Where(x => x.Entity.Name.Equals(entity.Name, StringComparison.InvariantCulture));

            foreach (var fullRelationshipModel in entityRelationships)
            {
                builder
                    .HasMany(fullRelationshipModel.RelationshipEntityType.FullName!, fullRelationshipModel.Relationship.Related.Entity.PluralName)
                    .WithMany(fullRelationshipModel.Entity.PluralName);
            }
        }

        public virtual List<RelationshipFullModel> GetRelationshipsToCreate(
            NoxSolutionCodeGeneratorState codeGeneratorState,
            IReadOnlyList<Entity> entities,
            ModelBuilder builder)
        {
            var fullRelationshipModels = new List<RelationshipFullModel>();

            foreach (var entity in entities)
            {
                var totalRelationships = new List<EntityRelationship>();
                if (entity.Relationships != null)
                {
                    totalRelationships.AddRange(entity.Relationships);
                }

                if (entity.OwnedRelationships != null)
                {
                    totalRelationships.AddRange(entity.OwnedRelationships);
                }

                foreach (var relationship in totalRelationships)
                {
                    var isIgnored = false;
                    var fullModel = new RelationshipFullModel
                    {
                        Entity = entity,
                        Relationship = relationship
                    };

                    EntityRelationship? pairRelationship = null;
                    var pairEntity = entities
                        .FirstOrDefault(x => x.Name.Equals(relationship.Entity, StringComparison.InvariantCulture));
                    if (pairEntity != null)
                    {
                        pairRelationship = pairEntity
                            .Relationships?
                            .FirstOrDefault(x => x.Entity.Equals(entity.Name, StringComparison.InvariantCulture)) ??
                            pairEntity
                            .OwnedRelationships?
                            .FirstOrDefault(x => x.Entity.Equals(entity.Name, StringComparison.InvariantCulture));
                    }

                    if (pairRelationship != null)
                    {
                        if (pairRelationship.Relationship == EntityRelationshipType.OneOrMany &&
                            relationship.Relationship == EntityRelationshipType.ZeroOrMany)
                        {
                            isIgnored = true;
                        }
                        else if (pairRelationship.Relationship == relationship.Relationship &&
                                 // Ascending sort, if the same relationship is covered by other side, then ignore it
                                 string.Compare(relationship.Entity, pairRelationship.Entity, StringComparison.InvariantCulture) > 0)
                        {
                            isIgnored = true;
                        }
                    }

                    if (!isIgnored)
                    {
                        fullRelationshipModels.Add(fullModel);
                    }
                }
            }

            return fullRelationshipModels;
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