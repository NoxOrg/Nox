using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class FileDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.File;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder.OwnsOne(typeof(File), property.Name,
            x =>
            {
                x.Ignore(nameof(File.Value));
                x.Property(nameof(File.Url)).HasMaxLength(File.MaxUrlLength);
                x.Property(nameof(File.PrettyName)).HasMaxLength(File.MaxPrettyNameLength);
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
