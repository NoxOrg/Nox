﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Exceptions;

namespace Nox.Types.EntityFramework.Types;

public class NumberDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Number;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = property.GetTypeOptions<NumberTypeOptions>();

        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion(GetConverter(typeOptions));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public Type GetConverter(NumberTypeOptions typeOptions)
    {
        var underlineType = typeOptions.GetUnderlyingType();

        if (underlineType == typeof(decimal))
        {
            return typeof(NumberToDecimalConverter);
        }
        if (underlineType == typeof(short))
        {
            return typeof(NumberToShortConverter);
        }
        if (underlineType == typeof(byte))
        {
            return typeof(NumberToByteConverter);
        }
        if (underlineType == typeof(int))
        {
            return typeof(NumberToInt32Converter);
        }
        if (underlineType == typeof(long))
        {
            return typeof(NumberToInt64Converter);
        }
        throw new NoxDatabaseProviderException($"Unsupported type {underlineType} for Number");
    }
}