using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.Sqlite.ToMoveEF;

/// <summary>
/// This will move to Nox.Types.EntityFramework, default implementation for LatLong
/// </summary>
public class MoneyDatabaseConfiguration : INoxTypeDatabaseConfiguration
{
    public void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
        string propertyName,
        EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class
    {
        // TODO get from Nox Solutin using propertyname
        // Need to invest some time to get a good solution
        MoneyTypeOptions typeOptions = new MoneyTypeOptions();

        Expression<Func<TEntity, Money>> noxProperty = (property as Expression<Func<TEntity, Money>>)!;

        builder
            .OwnsOne(noxProperty!)
            .Ignore(p => p.Value)
            .Property(p => p.Amount)
            .HasPrecision(typeOptions.DecimalDigits + typeOptions.IntegerDigits, typeOptions.DecimalDigits);
    }
}