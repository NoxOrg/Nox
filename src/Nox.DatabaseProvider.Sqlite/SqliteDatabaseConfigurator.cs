using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurators;

namespace Nox.DatabaseProvider.Sqlite;

public sealed class SqliteDatabaseConfigurator : NoxDatabaseConfigurator 
{
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> _typesConfiguration = new()
    {
        // Use default implementation for all types
        { NoxType.Text, new TextDatabaseConfigurator() },
        { NoxType.Number, new NumberDatabaseConfigurator() },
        { NoxType.Money, new MoneyDatabaseConfigurator() }
    };

    public SqliteDatabaseConfigurator() : base(_typesConfiguration)
    {
    }
}