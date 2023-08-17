using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeRangeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.DateTimeRange;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(DateTimeRange), property.Name, dtr =>
            {
                dtr.Property(nameof(DateTimeRange.Start))
                    .HasConversion<DateTimeOffsetConverter>();

                dtr.Property(nameof(DateTimeRange.End))
                    .HasConversion<DateTimeOffsetConverter>();

                dtr.Property(nameof(DateTimeRange.StartTimeZoneOffset))
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                dtr.Property(nameof(DateTimeRange.EndTimeZoneOffset))
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                dtr.Ignore(nameof(DateTimeRange.Value));
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
