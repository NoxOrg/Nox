using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// Configurator for the ReferenceNumber Nox type in the database.
/// This class implements the INoxTypeDatabaseConfigurator interface to provide configuration details for the AutoNumber Nox type in the database.
/// </summary>
public class ReferenceNumberDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <summary>
    /// Gets the NoxType associated with this configurator, which is AutoNumber.
    /// </summary>
    public NoxType ForNoxType => NoxType.ReferenceNumber;

    /// <summary>
    /// Gets a value indicating whether this configurator is the default one for the associated Nox type.
    /// In this case, it is set to true, indicating that this is the default configurator for AutoNumber.
    /// </summary>
    public virtual bool IsDefault => true;

    /// <summary>
    /// Configures the database entity property for the ReferenceNumber type.
    /// This method is called by the NoxSolutionCodeGeneratorState during the code generation process to set up the entity property in the database.
    /// </summary>
    /// <param name="noxSolutionCodeGeneratorState">The state of the Nox solution code generator.</param>
    /// <param name="property">The NoxSimpleTypeDefinition representing the property being configured.</param>
    /// <param name="entity">The Entity to which the property belongs.</param>
    /// <param name="isKey">A flag indicating whether the property is a key property.</param>
    /// <param name="modelBuilder"></param>
    /// <param name="entityTypeBuilder"></param>
    public virtual void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        var typeOptions = property.GetTypeOptions<ReferenceNumberTypeOptions>();

        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(10 + 28 + 1)// Prefix Max Lenght  + Sequence Max Lenght + CheckSum Digit
            .HasConversion<ReferenceNumberConverter>();

        if (!isKey)
        {
            entityTypeBuilder
                .HasIndex(property.Name)
                .IsUnique();
        }

        CreateSequence(noxSolutionCodeGeneratorState, property, entity, modelBuilder, typeOptions);
    }

    protected virtual void CreateSequence(NoxCodeGenConventions noxSolutionCodeGeneratorState, NoxTypeDatabaseConfiguration property, Entity entity, ModelBuilder modelBuilder, ReferenceNumberTypeOptions typeOptions)
    {
        modelBuilder.HasSequence<long>(NoxCodeGenConventions.GetDatabaseSequenceName(entity.Name, property.Name))
            .StartsAt(typeOptions.StartsAt)
            .IncrementsBy(typeOptions.IncrementsBy);
    }

    /// <summary>
    /// Gets the name of the key property for the ReferenceNumber type.
    /// This method is called by the NoxSolutionCodeGeneratorState to retrieve the name of the key property for the type.
    /// </summary>
    /// <param name="key">The NoxSimpleTypeDefinition representing the key property.</param>
    /// <returns>The name of the key property.</returns>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}