using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class DateDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Date;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion<DateConverter>()
            .IfNotNull(GetColumnType(), b => b.HasColumnType(GetColumnType()));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType() => null;
}
