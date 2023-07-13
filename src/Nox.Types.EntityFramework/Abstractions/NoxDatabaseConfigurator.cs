using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.Abstractions
{
    public abstract class NoxDatabaseConfigurator : INoxDatabaseConfigurator
    {
        //We could use the container to manage this
        protected readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesDatabaseConfigurations =
            new()
            {
                // Use default implementation for all types
                { NoxType.Text, new TextDatabaseConfigurator() },
                { NoxType.Number, new NumberDatabaseConfigurator() },
                { NoxType.Money, new MoneyDatabaseConfigurator() },
                { NoxType.CountryCode2, new CountryCode2DatabaseConfigurator() },
                { NoxType.StreetAddress, new StreetAddressDatabaseConfigurator() },
                { NoxType.Entity, new EntityDatabaseConfigurator()},
            };

        public virtual void ConfigureEntity(NoxSolutionCodeGeneratorState codeGeneratorState, EntityTypeBuilder builder, Entity entity)
        {
            //TODO Relations

            ConfigureKeys(codeGeneratorState, builder, entity);

            ConfigureAttributes(codeGeneratorState ,builder, entity);
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
                        databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, key, entity,true);
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
                        databaseConfiguration.ConfigureEntityProperty(codeGeneratorState, builder, property, entity, false);
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