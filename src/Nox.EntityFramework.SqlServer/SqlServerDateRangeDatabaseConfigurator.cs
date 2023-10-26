using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDateRangeDatabaseConfigurator : DateTimeRangeDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(NoxCodeGenConventions noxSolutionCodeGeneratorState, IEntityBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
           .OwnsOne(typeof(DateTimeRange), property.Name, dtr =>
           {
               dtr.Ignore(nameof(DateTimeRange.Value));
           });
    }
}