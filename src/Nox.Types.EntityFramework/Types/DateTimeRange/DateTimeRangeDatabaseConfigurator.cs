using Microsoft.EntityFrameworkCore;

using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class DateTimeRangeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.DateTimeRange;

    public virtual bool IsDefault => true;

    public virtual void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
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

                dtr.Ignore(nameof(DateTimeRange.Value));
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
