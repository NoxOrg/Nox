using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Sqlite.ToMoveEF;

namespace Nox.Types.EntityFramework.Sqlite.ToMoveMySql;

public sealed class MySqlDatabaseConfiguration : INoxDatabaseConfiguration
{
    //We could use the container to manage this
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> _typesDatabaseConfigurations =
        new()
        {
            { NoxType.Text, new TextMySqlDatabaseConfiguration() }, //Use MySql Implementation
            { NoxType.Number, new NumberDatabaseConfiguration() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfiguration() } // use default implementation
        };

    public void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
        string propertyName,
        EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class
    {
        // TODO get from Nox Solutin
        // Need to invest some time to get a good solution
        NoxType noxType = NoxType.Text; // TODO Get From Nox Solution

        _typesDatabaseConfigurations[noxType].ConfigureEntityProperty(noxSolution,propertyName, builder, property);
    }


}