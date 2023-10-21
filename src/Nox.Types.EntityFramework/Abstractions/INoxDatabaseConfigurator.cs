using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    /// <summary>
    /// Configure the data base model for an Entity
    /// </summary>
    void ConfigureEntity(IEntityBuilder builder, Entity entity);

    /// <summary>
    /// Configure the data base model for an localized Entity
    /// </summary>
    void ConfigureLocalizedEntity(IEntityBuilder builder, Entity entity);
}