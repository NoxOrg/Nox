using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;
public class DateTimeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.DateTime;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(DateTime), property.Name, dtr =>
            {
                dtr.Property(nameof(DateTime.DateTimeValue))
                    .HasConversion<DateTimeConverter>();

                dtr.Property(nameof(DateTime.TimeZoneOffset))
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                dtr.Ignore(nameof(DateTime.Value));
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
