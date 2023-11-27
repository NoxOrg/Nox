using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class NuidDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Nuid;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, 
        EntityTypeBuilder entityTypeBuilder)
    {
        var nuidOptions = property.NuidTypeOptions ?? new NuidTypeOptions();

        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IfNotNull(GetColumnType(nuidOptions), b => b.HasColumnType(GetColumnType(nuidOptions)))
            .HasConversion<NuidConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType(NuidTypeOptions typeOptions)
    {
        return null;
    }
}