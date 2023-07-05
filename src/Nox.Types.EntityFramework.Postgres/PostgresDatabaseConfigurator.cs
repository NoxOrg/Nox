using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.Types;

namespace Nox.Types.EntityFramework.Postgres;

public sealed class PostgresDatabaseConfigurator: NoxDatabaseConfigurator
{
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesConfiguration =
        new()
        {
            { NoxType.Text, new PostgresTextDatabaseConfiguration() }, //Use Postgres Implementation
            { NoxType.Number, new NumberDatabaseConfigurator() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfigurator() } // use default implementation
        };
    
    public PostgresDatabaseConfigurator() : base(TypesConfiguration)
    {
    }
}