﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class CountryCode2Configurator : INoxTypeDatabaseConfigurator
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        if (isKey)
        {
            builder.HasKey(property.Name);
        }

        builder
            .Property(property.Name)
            .IsRequired(isKey || property.IsRequired)
            .IsUnicode(false)
            .IsFixedLength(true)
            .HasMaxLength(2)
            .HasConversion<CountryCode2Converter>();
    }
}