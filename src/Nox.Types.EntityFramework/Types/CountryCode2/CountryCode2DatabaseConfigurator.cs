using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class CountryCode2DatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.CountryCode2;
    public bool IsDefault  => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(false)
            .IsFixedLength()
            .HasMaxLength(2)
            .HasConversion<CountryCode2Converter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}