using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;
using Microsoft.EntityFrameworkCore;

namespace Nox.EntityFramework.Postgres.Types.DateTimeRange;

public class PostgresDateTimeRangeDatabaseConfiguration : DateTimeRangeDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public new virtual void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(Nox.Types.DateTimeRange), property.Name, dtr =>
            {
                dtr.Property(nameof(Nox.Types.DateTimeRange.Start))
                    .HasConversion<PostgresDateTimeRangeConverter>();

                dtr.Property(nameof(Nox.Types.DateTimeRange.End))
                    .HasConversion<PostgresDateTimeRangeConverter>();

                dtr.Ignore(nameof(Nox.Types.DateTimeRange.Value));
            });
    }
}
