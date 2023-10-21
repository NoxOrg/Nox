using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class FormulaDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Formula;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var options = property.FormulaTypeOptions ?? new FormulaTypeOptions();

        builder
            .Property(property.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Property)
            .IsRequired(property.IsRequired)
            .HasConversion(options.Returns.AsNativeType());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}

