
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;
public class EmailDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Email;

    public bool IsDefault => true;

    public void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion<EmailConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
