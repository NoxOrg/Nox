using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System.IO.Pipes;
using System.Reflection.Emit;

namespace Nox.Types.EntityFramework.Types;

internal class HashedTextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.HashedText;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
            .OwnsOne(typeof(HashedText), property.Name)
            .Ignore(nameof(HashedText.Value));
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

}
