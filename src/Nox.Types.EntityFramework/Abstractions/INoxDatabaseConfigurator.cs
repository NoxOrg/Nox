using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    /// <summary>
    /// Configure the data base model for an Entity
    /// </summary>
    /// <param name="entityResolverByName">Function to resolve an Entity name to a Type</param>
    void ConfigureEntity(IEntityBuilder builder,Entity entity);
}