using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class TemperatureDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Temperature;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
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