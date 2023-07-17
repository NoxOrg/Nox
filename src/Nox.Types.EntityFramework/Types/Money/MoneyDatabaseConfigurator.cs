﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class MoneyDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Money;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        // TODO: Default values from static property in the Nox.Type
        // var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        builder
            .OwnsOne(typeof(Money), property.Name)
            .Ignore(nameof(Money.Value));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}