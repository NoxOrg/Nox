using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDtoDatabaseConfigurator
{
    /// <summary>
    /// Configure the Dto Db Context
    /// </summary>
    /// <param name="builder">Builder for the Dto Type</param>
    /// <param name="entity">The Dto (EF Entity)</param>
    void ConfigureDto(IEntityBuilder builder,Entity entity);
}
