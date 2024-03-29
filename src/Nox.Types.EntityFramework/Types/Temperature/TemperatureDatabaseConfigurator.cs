﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

public class TemperatureDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Temperature;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        var typeOptions = property.GetTypeOptions<TemperatureTypeOptions>();
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .If(typeOptions.PersistAs == TemperatureTypeUnit.Celsius,
                propertyToUpdate => propertyToUpdate.HasConversion<TemperatureToCelsiusConverter>())
            .If(typeOptions.PersistAs == TemperatureTypeUnit.Fahrenheit,
                propertyToUpdate => propertyToUpdate.HasConversion<TemperatureToFahrenheitConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}