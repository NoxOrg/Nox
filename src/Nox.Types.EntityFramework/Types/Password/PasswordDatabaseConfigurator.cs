using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class PasswordDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Password;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(Password), property.Name)
            .Ignore(nameof(Password.Value));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}