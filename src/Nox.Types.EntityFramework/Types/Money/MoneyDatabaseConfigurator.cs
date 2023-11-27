using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class MoneyDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Money;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        // TODO: Default values from static property in the Nox.Type
         var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        entityTypeBuilder
            .OwnsOne(typeof(Money), property.Name)
            .Ignore(nameof(Money.Value))
            .Property(nameof(Money.Amount))
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)));
    }

    public virtual string? GetColumnType(MoneyTypeOptions typeOptions)
    {
        return null;
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}