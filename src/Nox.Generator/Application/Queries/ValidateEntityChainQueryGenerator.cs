using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Queries;

internal class ValidateEntityChainQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var navigationNameToEntityPluralName = new Dictionary<string, string>();

        var isSingleRelationship = new Dictionary<(string EntityPluralName, string NavigationName), bool>();

        foreach (var entity in entities.Where(e => !e.IsOwnedEntity))
        {
            foreach (var relationship in entity.Relationships)
            {
                var navigationName = entity.GetNavigationPropertyName(relationship).ToLower();
                if (!navigationNameToEntityPluralName.ContainsKey(navigationName))
                {
                    navigationNameToEntityPluralName[navigationName] = relationship.EntityPlural.ToLower();
                }

                isSingleRelationship.Add((entity.PluralName.ToLower(), navigationName.ToLower()), relationship.WithSingleEntity);
            }
        }
        isSingleRelationship.TryGetValue(("a", "asd"), out var isSingle);

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"ValidateEntityChainQuery")
            .WithFileNamePrefix($"Application.Queries")
            .WithObject("entities", entities.Where(e => !e.IsOwnedEntity))
            .WithObject("navigationNameToEntityPluralName", navigationNameToEntityPluralName)
            .WithObject("isSingleRelationship", isSingleRelationship)
            .GenerateSourceCodeFromResource("Application.Queries.ValidateEntityChainQuery");        
    }
}