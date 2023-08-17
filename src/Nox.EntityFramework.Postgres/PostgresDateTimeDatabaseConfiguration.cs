using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;
using DateTime = Nox.Types.DateTime;

namespace Nox.EntityFramework.Postgres;

public class PostgresDateTimeDatabaseConfiguration : DateTimeDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
          .Property(property.Name)
          .IsRequired(property.IsRequired)
          .HasConversion<PostGresDateTimeConverter>();
    }
    public class PostGresDateTimeConverter : ValueConverter<DateTime, System.DateTime>
    {
        public PostGresDateTimeConverter()
            : base(
                dateTime => dateTime.Value.UtcDateTime,
                dateTimeValue => DateTime.FromDatabase(new DateTimeOffset(dateTimeValue, TimeSpan.Zero)))
        { }
    }
}