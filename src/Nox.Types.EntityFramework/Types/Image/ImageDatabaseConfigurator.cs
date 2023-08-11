using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class ImageDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Image;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder.OwnsOne(typeof(Image), property.Name,
            x =>
            {
                x.Ignore(nameof(Image.Value));
                x.Property(nameof(Image.Url)).HasMaxLength(Image.MaxUrlLength);
                x.Property(nameof(Image.PrettyName)).HasMaxLength(Image.MaxPrettyNameLength);
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}