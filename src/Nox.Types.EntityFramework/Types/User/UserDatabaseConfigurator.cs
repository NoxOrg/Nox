using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class UserDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.User;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
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
    public virtual string? GetColumnType(UserTypeOptions typeOptions)
    {
        return null;
    }
}