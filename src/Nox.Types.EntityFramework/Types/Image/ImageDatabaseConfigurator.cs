using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

public class ImageDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Image;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, 
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder.OwnsOne(typeof(Image), property.Name,
            x =>
            {
                x.Ignore(nameof(Image.Value));
                x.Property(nameof(Image.Url)).HasMaxLength(Image.MaxUrlLength);
                x.Property(nameof(Image.PrettyName)).HasMaxLength(Image.MaxPrettyNameLength);
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}