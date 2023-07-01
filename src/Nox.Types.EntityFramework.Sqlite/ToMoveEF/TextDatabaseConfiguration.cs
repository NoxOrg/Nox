using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.Sqlite.ToMoveEF;

/// <summary>
/// This will move to Nox.Types.EntityFramework, default implementation for Number
/// </summary>
public class TextDatabaseConfiguration : INoxTypeDatabaseConfiguration
{
    public void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
        string propertyName,
        EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class
    {
        // TODO get from Nox Solutin
        // TODO get from Nox Solutin using propertyname
        var typeOptions = new TextTypeOptions();

        var noxPropertyBuilder = builder.Property(property) as PropertyBuilder<Text>;

        noxPropertyBuilder!.HasConversion<TextConverter>()
            .IsUnicode(typeOptions.IsUnicode)
            .HasMaxLength((int)typeOptions.MaxLength)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)));
    }
        
    public virtual string? GetColumnType(TextTypeOptions typeOptions)
    {
        return null;
    }
}