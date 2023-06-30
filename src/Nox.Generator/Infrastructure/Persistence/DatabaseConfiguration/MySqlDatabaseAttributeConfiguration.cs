using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;

internal class MySqlDatabaseAttributeConfiguration : IDatabaseAttributeConfiguration
{
    public IDatabaseAttributeConfig GetConfig(NoxSimpleTypeDefinition tyeDefinition)
    {
        if (tyeDefinition.Type == NoxType.Text)
        {
            var options = tyeDefinition.TextTypeOptions ?? new TextTypeOptions();

            var config = ConfigurationDefaults.GetDefaultOptions(options);
            config.HasColumnType = $"VARCHAR({options.MaxLength})";
        }
        if (tyeDefinition.Type == NoxType.Number)
        {
            var options = tyeDefinition.NumberTypeOptions ?? new NumberTypeOptions();
            return ConfigurationDefaults.GetDefaultOptions(options);
        }
        //For now return default => When Completed return Exception
        return new DatabaseAttributeConfig() { };
    }
}