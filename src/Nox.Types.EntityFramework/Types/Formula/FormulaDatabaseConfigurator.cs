using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class FormulaDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Formula;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        AttributeConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        var options = property.FormulaTypeOptions ?? new FormulaTypeOptions();

        entityTypeBuilder
            .Property(property.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Property)
            .IsRequired(property.IsRequired)
            .HasConversion(options.Returns.AsNativeType());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}

