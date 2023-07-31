using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class TemperatureDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Temperature;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var typeOptions = property.TemperatureTypeOptions ?? new TemperatureTypeOptions();
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .If(typeOptions.PersistAs == TemperatureTypeUnit.Celsius,
                propertyToUpdate => propertyToUpdate.HasConversion<TemperatureToCelsiusConverter>())
            .If(typeOptions.PersistAs == TemperatureTypeUnit.Fahrenheit,
                propertyToUpdate => propertyToUpdate.HasConversion<TemperatureToFahrenheitConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}