using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Presentation.Api.OData;

internal abstract class EntityControllerGeneratorBase : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public abstract void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      );

    protected static string GetPrimaryKeysQuery(Entity entity, string prefix = "key", bool withKeyName = false)
    {
        if (entity?.Keys?.Count > 1)
        {
            return string.Join(", ", entity.Keys.Select(k => $"{prefix}{k.Name}"));
        }
        else if (entity?.Keys?.Count == 1)
        {
            return withKeyName ? $"{prefix}{entity.Keys[0].Name}" : prefix;
        }

        return string.Empty;
    }

    protected static string GetPrimaryKeysRoute(Entity entity, NoxSolution solution, string keyPrefix = "key", string attributePrefix = "[FromRoute]")
    {
        if (entity?.Keys?.Count > 1)
        {
            return string.Join(", ", entity.Keys.Select(k => $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(k)} {keyPrefix}{k.Name}"))
                .Trim();
        }
        else if (entity?.Keys?.Count == 1)
        {
            return $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])} {keyPrefix}"
                .Trim();
        }

        return string.Empty;
    }

    protected static string GetPrimaryKeysToString(Entity entity, string prefix = "key")
    {
        var withKeyName = entity.Keys.Count > 1;
        return string.Join(", ", entity.Keys.Select(k => $"{{{prefix}{(withKeyName ? k.Name : "")}.ToString()}}"));
    }
    
    protected static bool CanDelete(Entity entity) => entity.Persistence?.Delete?.IsEnabled ?? true;
    protected static bool CanRead(Entity entity) => entity.Persistence?.Read?.IsEnabled ?? true;
    protected static bool CanCreate(Entity entity) => entity.Persistence?.Create?.IsEnabled ?? true;
    protected static bool CanUpdate(Entity entity) => entity.Persistence?.Update?.IsEnabled ?? true;
}
