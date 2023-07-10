using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions
{
    public abstract class NoxDatabaseConfigurator : INoxDatabaseConfigurator
    {
        private readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> _typesDatabaseConfigurations;

        protected NoxDatabaseConfigurator(Dictionary<NoxType, INoxTypeDatabaseConfigurator> typesConfiguration)
        {
            _typesDatabaseConfigurations = typesConfiguration;
        }

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
                    if (_typesDatabaseConfigurations.TryGetValue(key.Type,
                            out var databaseConfiguration))
                    {
                        keysPropertyNames.Add(databaseConfiguration.GetKeyPropertyName(key));
                    }

                }
                builder.HasKey(keysPropertyNames.ToArray());

                foreach (var key in entity.Keys)
                {
                    if (_typesDatabaseConfigurations.TryGetValue(key.Type,
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
                    if (_typesDatabaseConfigurations.TryGetValue(property.Type,
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
