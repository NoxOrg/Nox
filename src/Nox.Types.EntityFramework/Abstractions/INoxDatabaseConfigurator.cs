using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using System.Reflection;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    /// <summary>
    /// Configure the data base model for an Entity
    /// </summary>
    /// <param name="modelBuilder">Model builder type of <see cref="ModelBuilder"/>.</param>
    /// <param name="builder">Entity builder type of <see cref="IEntityBuilder"/>.</param>
    /// <param name="entity">Entity param type of <see cref="Entity"/>.</param>
    /// <param name="domainAssembly">The Client Assembly where entity is generated.</param>
    void ConfigureEntity(ModelBuilder modelBuilder, EntityTypeBuilder builder, Entity entity, Assembly domainAssembly);

    /// <summary>
    /// Configure the data base model for an localized Entity
    /// </summary>
    void ConfigureLocalizedEntity(ModelBuilder modelBuilder, EntityTypeBuilder builder, Entity entity);
}