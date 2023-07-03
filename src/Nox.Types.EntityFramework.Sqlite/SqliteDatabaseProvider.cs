using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.Sqlite;

public sealed class SqliteDatabaseProvider : NoxDatabaseProvider
{
    //We could use the container to manage this

    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> _typesConfiguration = new()
    {
        // Use default implementation for all types
        { NoxType.Text, new TextDatabaseConfiguration() },
        { NoxType.Number, new NumberDatabaseConfiguration() },
        { NoxType.Money, new MoneyDatabaseConfiguration() }
    };

    public SqliteDatabaseProvider(Dictionary<NoxType, INoxTypeDatabaseConfiguration> typesConfiguration) : base(
        _typesConfiguration)
    {
    }
}