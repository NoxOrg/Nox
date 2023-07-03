using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.SqlServer;

public sealed class SqlServerDatabaseProvider : NoxDatabaseProvider
{
    //We could use the container to manage this
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> _typesConfiguration =
        new()
        {
            { NoxType.Text, new SqlServerTextDatabaseConfiguration() }, //Use MySql Implementation
            { NoxType.Number, new NumberDatabaseConfiguration() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfiguration() } // use default implementation
        };

    public SqlServerDatabaseProvider(Dictionary<NoxType, INoxTypeDatabaseConfiguration> typesConfiguration) : base(
        _typesConfiguration)
    {
    }
}