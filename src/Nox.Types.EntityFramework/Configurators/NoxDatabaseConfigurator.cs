using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Configurators
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
            //TODO Composite Keys
            //TODO Relations
            if (entity.Keys != null && entity.Keys.Any())
            {
                foreach (var property in entity.Keys)
                {
                    if (_typesDatabaseConfigurations.TryGetValue(property.Type,
                            out var databaseConfiguration))
                    {
                        databaseConfiguration.ConfigureEntityProperty(builder, property, true);
                    }
                    else
                    {

                        Console.WriteLine($"Type {property.Type} not found");
                    }
                }
            }

            if (entity.Attributes != null && entity.Attributes.Any())
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
