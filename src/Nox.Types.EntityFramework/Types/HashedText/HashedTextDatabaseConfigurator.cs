using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class HashedTextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.HashedText;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var ownedNavigation = builder
            .OwnsOne(typeof(HashedText), property.Name);

        if (ownedNavigation is EntityTypeBuilder etb)
        {
            etb
                .Ignore(nameof(HashedText.Value));
        }
        else
        {
            ((OwnedNavigationBuilder)ownedNavigation)
                .Ignore(nameof(HashedText.Value));
        }
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}
