﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The translated text database configuration.
/// </summary>
public class TranslatedTextDatabaseConfiguration : INoxTypeDatabaseConfigurator
{
    /// <summary>
    /// Gets the nox type.
    /// </summary>
    public NoxType ForNoxType => NoxType.TranslatedText;


    /// <summary>
    /// Gets a value indicating whether is default.
    /// </summary>
    public bool IsDefault => true;

    /// <summary>
    /// Configures the entity property.
    /// </summary>
    /// <param name="noxSolutionCodeGeneratorState">The nox solution code generator state.</param>
    /// <param name="property">The property.</param>
    /// <param name="entity">The entity.</param>
    /// <param name="isKey">If true, is key.</param>
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
        entityTypeBuilder.OwnsOne(typeof(TranslatedText), property.Name,
            x =>
            {
                x.Ignore(nameof(TranslatedText.Value));
            });
    }

    /// <summary>
    /// Gets the key property name.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>A string.</returns>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
