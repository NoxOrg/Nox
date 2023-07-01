using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Sqlite.ToMoveEF;

namespace Nox.Types.EntityFramework.Sqlite;

public sealed class SqliteDatabaseConfiguration : INoxDatabaseConfiguration
{
    //We could use the container to manage this
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfiguration> _typesDatabaseConfigurations =
        new()
        {
            // Use default implementation for all types
            { NoxType.Text, new TextDatabaseConfiguration() }, 
            { NoxType.Number, new NumberDatabaseConfiguration()},  
            { NoxType.Money, new MoneyDatabaseConfiguration() } 
        };

    public void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
        string propertyName,
        EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class
    {
        // TODO get from Nox Solutin
        // TODO get from Nox Solutin using propertyname
        NoxType noxType = NoxType.Text; 

        _typesDatabaseConfigurations[noxType].ConfigureEntityProperty(noxSolution, propertyName, builder, property);
    }
}

