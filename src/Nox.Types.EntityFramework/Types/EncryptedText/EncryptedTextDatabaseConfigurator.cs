using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class EncryptedTextDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.EncryptedText;
    public virtual bool IsDefault => false;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var encryptedTextOptions = property.EncryptedTextTypeOptions ?? new EncryptedTextTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(false)
            .IfNotNull(GetColumnType(encryptedTextOptions), b => b.HasColumnType(GetColumnType(encryptedTextOptions)))
            .HasConversion<EncryptedTextConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
    public virtual string? GetColumnType(EncryptedTextTypeOptions typeOptions)
    {
        return null;
    }
}