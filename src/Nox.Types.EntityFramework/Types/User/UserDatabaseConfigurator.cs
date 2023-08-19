using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class UserDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.User;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var userOptions = property.UserTypeOptions ?? new UserTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(userOptions.MaxLength)
            .If(userOptions.MaxLength == userOptions.MinLength, builder2 => builder2.IsFixedLength())
            .HasConversion<UserConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}