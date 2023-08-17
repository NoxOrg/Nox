using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseConfigurator
{
    void ConfigureEntity(
        NoxSolutionCodeGeneratorState codeGeneratorState,
        IEntityBuilderAdapter builder,
        Entity entity,
        NoxSolution noxSolution,
        Func<string, Type?> getTypeByNameFunc);
}