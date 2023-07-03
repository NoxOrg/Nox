﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.vNext.Types;

public class MoneyDatabaseConfigurator : INoxTypeDatabaseConfigurator
{

    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        if (isKey)
        {
            builder.HasKey(property.Name);
        }

        builder
            .OwnsOne(typeof(Money), property.Name)
            .Ignore(nameof(Money.Value));
    }
}