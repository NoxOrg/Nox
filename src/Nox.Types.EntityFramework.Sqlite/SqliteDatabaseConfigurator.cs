using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.Types;

namespace Nox.Types.EntityFramework.Sqlite;

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