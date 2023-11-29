using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class TextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Text;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        //TODO: Default values from static property in the Nox.Type
        var textOptions = property.TextTypeOptions ?? new TextTypeOptions();

        entityTypeBuilder
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