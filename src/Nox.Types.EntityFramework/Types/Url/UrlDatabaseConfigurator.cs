using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class UrlDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Url;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, 
        EntityTypeBuilder builder, 
        NoxSimpleTypeDefinition property, 
        Entity entity, 
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(Url.MaxLength)
            .HasConversion<UrlConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
