using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    void ConfigureEntity(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        IEntityBuilder builder,
        Entity entity,
        Func<string, Type?> getTypeByNameFunc);
}