using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using System.Reflection;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDtoDatabaseConfigurator
{
    /// <summary>
    /// Configure the database model for a DTO
    /// </summary>
    /// <param name="builder">Builder for the Dto Type</param>
    /// <param name="entity">The Dto (EF Entity)</param>
    /// <param name="clientAssembly">The Client Assembly where entity is generated.</param>
    void ConfigureDto(EntityTypeBuilder builder, Entity entity, Assembly clientAssembly);

    /// <summary>
    /// Configure the database model for a localized DTO
    /// </summary>
    /// <param name="builder">Builder for the Dto Type</param>
    /// <param name="entity">The Dto (EF Entity)</param>
    void ConfigureLocalizedDto(EntityTypeBuilder builder, Entity entity);
}
