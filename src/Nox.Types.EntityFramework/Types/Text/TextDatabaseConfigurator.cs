﻿using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class TextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Text;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        //TODO: Default values from static property in the Nox.Type
        var textOptions = property.TextTypeOptions ?? new TextTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(textOptions.IsUnicode)
            .HasMaxLength((int)textOptions.MaxLength)
            .If(textOptions.MaxLength == textOptions.MinLength, builder2 => builder2.IsFixedLength())
            .IfNotNull(GetColumnType(textOptions), b => b.HasColumnType(GetColumnType(textOptions)))
            .HasConversion<TextConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
    public virtual string? GetColumnType(TextTypeOptions typeOptions)
    {
        return null;
    }
}