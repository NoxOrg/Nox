﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// Configurator for the <see cref="LatLong"/> Nox type in the database.
/// This class implements the INoxTypeDatabaseConfigurator interface to provide configuration details for the  <see cref="LatLong"/> Nox type in the database.
/// </summary>
public class LatLongDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <summary>
    /// Gets the NoxType associated with this configurator, which is LatLong.
    /// </summary>
    public NoxType ForNoxType => NoxType.LatLong;

    /// <summary>
    /// Gets a value indicating whether this configurator is the default one for the associated Nox type.
    /// In this case, it is set to true, indicating that this is the default configurator for LatLong.
    /// </summary>
    public virtual bool IsDefault => true;

    /// <summary>
    /// Configures the database entity property for the LatLong type.
    /// This method is called by the NoxSolutionCodeGeneratorState during the code generation process to set up the entity property in the database.
    /// </summary>
    /// <param name="noxSolutionCodeGeneratorState">The state of the Nox solution code generator.</param>
    /// <param name="property">The NoxSimpleTypeDefinition representing the property being configured.</param>
    /// <param name="entity">The Entity to which the property belongs.</param>
    /// <param name="isKey">A flag indicating whether the property is a key property.</param>
    /// <param name="modelBuilder"></param>
    /// <param name="entityTypeBuilder"></param>
    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {

        entityTypeBuilder.OwnsOne(typeof(LatLong), property.Name,
            ba =>
            {
                ba.Ignore(nameof(LatLong.Value));
                ba.Property(nameof(LatLong.Latitude)).HasConversion<double>();
                ba.Property(nameof(LatLong.Longitude)).HasConversion<double>();
            });
    }

    /// <summary>
    /// Gets the name of the key property for the LatLong type.
    /// This method is called by the NoxSolutionCodeGeneratorState to retrieve the name of the key property for the type.
    /// </summary>
    /// <param name="key">The NoxSimpleTypeDefinition representing the key property.</param>
    /// <returns>The name of the key property.</returns>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
