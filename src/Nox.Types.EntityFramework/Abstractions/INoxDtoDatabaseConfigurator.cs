using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDtoDatabaseConfigurator
{
    /// <summary>
    /// Configure the database model for a DTO
    /// </summary>
    /// <param name="builder">Builder for the Dto Type</param>
    /// <param name="entity">The Dto (EF Entity)</param>
    void ConfigureDto(EntityTypeBuilder builder, Entity entity);

    /// <summary>
    /// Configure the database model for a localized DTO
    /// </summary>
    /// <param name="builder">Builder for the Dto Type</param>
    /// <param name="entity">The Dto (EF Entity)</param>
    void ConfigureLocalizedDto(EntityTypeBuilder builder, Entity entity);
}
