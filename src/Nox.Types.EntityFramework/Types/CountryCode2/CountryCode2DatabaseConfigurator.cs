using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;


namespace Nox.Types.EntityFramework.Types;

public class CountryCode2DatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.CountryCode2;
    public bool IsDefault  => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(false)
            .IsFixedLength()
            .HasMaxLength(2)
            .HasConversion<CountryCode2Converter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}