using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;
/// <summary>
/// Configurator for the <see cref="InternetDomain"/> Nox type in the database.
/// This class implements the INoxTypeDatabaseConfigurator interface to provide configuration details for the <see cref="InternetDomain"/> Nox type in the database.
/// </summary>
public class InternetDomainDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <summary>
    /// Gets the NoxType associated with this configurator, which is InternetDomain.
    /// </summary>
    public NoxType ForNoxType => NoxType.InternetDomain;

    /// <summary>
    /// Gets a value indicating whether this configurator is the default one for the associated Nox type.
    /// In this case, it is set to true, indicating that this is the default configurator for InternetDomain.
    /// </summary>
    public bool IsDefault => true;

    /// <summary>
    /// Configures the database entity property for the InternetDomain type.
    /// This method is called by the NoxSolutionCodeGeneratorState during the code generation process to set up the entity property in the database.
    /// </summary>
    /// <param name="noxSolutionCodeGeneratorState">The state of the Nox solution code generator.</param>
    /// <param name="builder">The EntityTypeBuilder to configure the entity.</param>
    /// <param name="property">The NoxSimpleTypeDefinition representing the property being configured.</param>
    /// <param name="entity">The Entity to which the property belongs.</param>
    /// <param name="isKey">A flag indicating whether the property is a key property.</param>
    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IsUnicode(false)
            .HasMaxLength(63)
            .HasConversion<InternetDomainConverter>();
    }

    /// <summary>
    /// Gets the name of the key property for the InternetDomain type.
    /// This method is called by the NoxSolutionCodeGeneratorState to retrieve the name of the key property for the type.
    /// </summary>
    /// <param name="key">The NoxSimpleTypeDefinition representing the key property.</param>
    /// <returns>The name of the key property.</returns>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}