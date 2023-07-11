using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class TextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var textOptions = property.TextTypeOptions ?? new TextTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(isKey || property.IsRequired)
            .IsUnicode(textOptions.IsUnicode)
            .IfNotNull(GetColumnType(textOptions), b => b.HasColumnType(GetColumnType(textOptions)))
            .HasConversion<TextConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
    public virtual string? GetColumnType(TextTypeOptions typeOptions)
    {
        return null;
    }
}