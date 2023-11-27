using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    /// <summary>
    /// Configure the data base model for an Entity
    /// </summary>
    void ConfigureEntity(ModelBuilder modelBuilder, EntityTypeBuilder builder, Entity entity);

    /// <summary>
    /// Configure the data base model for an localized Entity
    /// </summary>
    void ConfigureLocalizedEntity(ModelBuilder modelBuilder, EntityTypeBuilder builder, Entity entity);
}