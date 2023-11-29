using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeRangeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.DateTimeRange;

    public virtual bool IsDefault => true;

    public virtual void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey, ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .OwnsOne(typeof(DateTimeRange), property.Name, dtr =>
            {
                dtr.Property(nameof(DateTimeRange.Start))
                    .HasConversion<DateTimeOffsetConverter>();

                dtr.Property(nameof(DateTimeRange.End))
                    .HasConversion<DateTimeOffsetConverter>();

                dtr.Ignore(nameof(DateTimeRange.Value));
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
