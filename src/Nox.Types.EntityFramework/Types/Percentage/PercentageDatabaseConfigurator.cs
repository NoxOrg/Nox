using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

public class PercentageDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Percentage;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        var typeOptions = property.GetTypeOptions<PercentageTypeOptions>();

        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(typeOptions.Digits)
            .HasConversion<PercentageConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
