using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.EntityFramework.Postgres.Types.DateTime;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres.Types.DateTimeRange;

public class PostgresDateTimeRangeDatabaseConfiguration : DateTimeRangeDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public virtual void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(Nox.Types.DateTimeRange), property.Name, dtr =>
            {
                dtr.Property(nameof(Nox.Types.DateTimeRange.Start))
                    .HasConversion<PostgresDateTimeConverter>();

                dtr.Property(nameof(Nox.Types.DateTimeRange.End))
                    .HasConversion<PostgresDateTimeConverter>();

                dtr.Ignore(nameof(Nox.Types.DateTimeRange.Value));
            });
    }
}
