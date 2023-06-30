using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration
{
    internal interface IDatabaseAttributeConfiguration
    {
        IDatabaseAttributeConfig GetConfig(NoxSimpleTypeDefinition tyeDefinition);
    }
}