using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                { NoxType.CountryCode2, new CountryCode2Configurator() }
            };

        public virtual void ConfigureEntity(EntityTypeBuilder builder, Entity entity)
        {
            //TODO Relations
            
            ConfigureKeys(builder, entity);

            ConfigureAttributes(builder, entity);
        }

        private void ConfigureKeys(EntityTypeBuilder builder, Entity entity)
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
                    }

                }
                builder.HasKey(keysPropertyNames.ToArray());

                foreach (var key in entity.Keys)
                {
                    if (TypesDatabaseConfigurations.TryGetValue(key.Type,
                            out var databaseConfiguration))
                    {
                        databaseConfiguration.ConfigureEntityProperty(builder, key, true);
                    }
                    else
                    {
                        Console.WriteLine($"Type {key.Type} not found");
                    }
                }
            }
        }

        private void ConfigureAttributes(EntityTypeBuilder builder, Entity entity)
        {
            if (entity.Attributes is { Count: > 0 })
            {
                foreach (var property in entity.Attributes)
                {
                    if (TypesDatabaseConfigurations.TryGetValue(property.Type,
                            out var databaseConfiguration))
                    {
                        databaseConfiguration.ConfigureEntityProperty(builder, property, false);
                    }
                    else
                    {

                        Console.WriteLine($"Type {property.Type} not found");
                    }
                }
            }
        }
    }
}
