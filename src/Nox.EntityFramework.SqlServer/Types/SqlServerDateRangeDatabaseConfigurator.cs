using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer.Types;

public class SqlServerDateRangeDatabaseConfigurator : DateTimeRangeDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(NoxCodeGenConventions noxSolutionCodeGeneratorState, 
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, 
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
           .OwnsOne(typeof(DateTimeRange), property.Name, dtr =>
           {
               dtr.Ignore(nameof(DateTimeRange.Value));
           });
    }
}