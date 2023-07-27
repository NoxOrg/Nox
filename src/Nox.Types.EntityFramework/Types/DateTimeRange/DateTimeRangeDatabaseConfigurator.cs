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
             .OwnsOne(typeof(DateTimeRange), property.Name)
             .Ignore(nameof(DateTimeRange.Value));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => throw new NotImplementedException();
}
