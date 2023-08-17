using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class MoneyDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Money;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        // TODO: Default values from static property in the Nox.Type
         var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        var ownedNavigation = builder
            .OwnsOne(typeof(Money), property.Name);
        if (ownedNavigation is EntityTypeBuilder etb)
        {
            etb
                .Ignore(nameof(Money.Value))
                .Property(nameof(Money.Amount))
                .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)));
        }
        else
        {
            ((OwnedNavigationBuilder)ownedNavigation)
                .Ignore(nameof(Money.Value))
                .Property(nameof(Money.Amount))
                .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)));
        }
    }

    public virtual string? GetColumnType(MoneyTypeOptions typeOptions)
    {
        return null;
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}