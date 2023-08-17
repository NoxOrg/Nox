using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class PasswordDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Password;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {

        var ownedNavigation = builder
            .OwnsOne(typeof(Password), property.Name);
        if (ownedNavigation is EntityTypeBuilder etb)
        {
            etb
                .Ignore(nameof(Password.Value));
        }
        else
        {
            ((OwnedNavigationBuilder)ownedNavigation)
                .Ignore(nameof(Password.Value));
        }
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}