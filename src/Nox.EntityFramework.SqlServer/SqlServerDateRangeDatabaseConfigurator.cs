using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDateRangeDatabaseConfigurator : DateTimeRangeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, IEntityBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
           .OwnsOne(typeof(DateTimeRange), property.Name, dtr =>
           {
               dtr.Ignore(nameof(DateTimeRange.Value));
           });
    }
}