using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class MarkdownDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Markdown;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var markdownTypeOptions = property.MarkdownTypeOptions ?? new MarkdownTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(markdownTypeOptions.IsUnicode)
            .HasMaxLength((int)markdownTypeOptions.MaxLength)
            .If(markdownTypeOptions.MaxLength == markdownTypeOptions.MinLength, builder2 => builder2.IsFixedLength())
            .IfNotNull(GetColumnType(markdownTypeOptions), b => b.HasColumnType(GetColumnType(markdownTypeOptions)))
            .HasConversion<MarkdownConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
    public virtual string? GetColumnType(MarkdownTypeOptions typeOptions)
    {
        return null;
    }
}