﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class MoneyDatabaseConfigurator : INoxTypeDatabaseConfigurator
{

    public void ConfigureEntityProperty(
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity, 
        bool singleKey)
    {
        // TODO: Default values from static property in the Nox.Type
        // var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        builder
            .OwnsOne(typeof(Money), property.Name)
            .Ignore(nameof(Money.Value));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}