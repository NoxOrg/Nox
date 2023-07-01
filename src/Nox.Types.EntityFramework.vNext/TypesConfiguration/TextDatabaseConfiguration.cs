using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.vNext.TypesConfiguration;

/// <summary>
/// This will move to Nox.Types.EntityFramework, default implementation for Number
/// </summary>
public class TextDatabaseConfiguration : INoxTypeDatabaseConfiguration
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var textOptions = property.TextTypeOptions ?? new TextTypeOptions();

        if (isKey)
        {
            builder.HasKey(property.Name);
        }

        builder
            .Property(property.Name)
            .IsRequired(isKey || property.IsRequired)
            .IsUnicode(textOptions.IsUnicode)
            .IfNotNull(GetColumnType(textOptions), b => b.HasColumnType(GetColumnType(textOptions)))
            .HasConversion<TextConverter>();
    }
    public virtual string? GetColumnType(TextTypeOptions typeOptions)
    {
        return null;
    }
}