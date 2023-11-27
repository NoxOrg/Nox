using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres.Types.DateTime;

public class PostgresDateTimeDatabaseConfiguration : DateTimeDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
          .Property(property.Name)
          .IsRequired(property.IsRequired)
          .HasConversion<PostgresDateTimeConverter>();
    }
}
