using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.Types;

namespace Nox.Types.EntityFramework.SqlServer;

public sealed class SqlServerDatabaseConfigurator : NoxDatabaseConfigurator
{
    //We could use the container to manage this
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> _typesConfiguration =
        new()
        {
            { NoxType.Text, new SqlServerTextDatabaseConfigurator() }, //Use MySql Implementation
            { NoxType.Number, new NumberDatabaseConfigurator() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfigurator() } // use default implementation
        };

    public SqlServerDatabaseConfigurator() : base(_typesConfiguration)
    {
    }
}