using Nox.Types.EntityFramework.vNext;
using Nox.Types.EntityFramework.vNext.TypesConfiguration;

namespace Nox.Types.EntityFramework.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseProvider
{
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> TypesConfiguration =
        new()
        {
            { NoxType.Text, new PostgresTextDatabaseConfiguration() }, //Use Postgres Implementation
            { NoxType.Number, new NumberDatabaseConfiguration() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfiguration() } // use default implementation
        };
    
    public PostgresDatabaseProvider(Dictionary<NoxType, INoxTypeDatabaseConfiguration> typesConfiguration) : base(TypesConfiguration)
    {
    }
}