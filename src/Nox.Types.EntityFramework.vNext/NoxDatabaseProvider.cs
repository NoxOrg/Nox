using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.vNext
{
    public abstract class NoxDatabaseProvider : INoxDatabaseProvider
    {
        private readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> _typesDatabaseConfigurations;

        protected NoxDatabaseProvider(Dictionary<NoxType, INoxTypeDatabaseConfiguration> typesConfiguration)
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
