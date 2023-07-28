using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class LatLongConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.LatLong;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {

        builder
            .OwnsOne(typeof(LatLong), property.Name)
            .Ignore(nameof(LatLong.Value))
            .Property(nameof(LatLong.Latitude));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}