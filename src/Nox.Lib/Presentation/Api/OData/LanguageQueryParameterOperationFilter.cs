using Microsoft.OpenApi.Models;
using Nox.Solution;
using Swashbuckle.AspNetCore.SwaggerGen;
using Nox.Solution.Extensions;

namespace Nox.Presentation.Api.OData;

public class LanguageQueryParameterOperationFilter: IOperationFilter
{
    private readonly HashSet<string> _localizedEntityPaths;

    public LanguageQueryParameterOperationFilter(NoxSolution noxSolution)
    {
        var entityPaths = GetEntityPathsForLocalizedOwnedEntities(noxSolution);
        
        entityPaths.AddRange( GetEntityPathsForLocalizedEntities(noxSolution));

        _localizedEntityPaths = entityPaths.ToHashSet();
    }
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method && _localizedEntityPaths.Any(p =>context.ApiDescription.RelativePath!.Contains(p)))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = QueryParams.Language,
                Description = "language parameter",
                In = ParameterLocation.Query,
                Style = ParameterStyle.Simple,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Pattern = Nox.Types.Abstractions.CultureCode.RegularExpression
                },
                Required = false
            });
        }
    }
    
    private static IEnumerable<string> GetEntityPathsForLocalizedEntities(NoxSolution noxSolution)
    {
        return noxSolution.Domain!.Entities.Where(e => e is { IsLocalized: true, IsOwnedEntity: false })
            .Select(e => string.Concat("/", e.PluralName));
    }

    private static List<string> GetEntityPathsForLocalizedOwnedEntities(NoxSolution noxSolution )
    {
        List<string> entityPaths = new();
        var localizedOwnedEntities =
            noxSolution.Domain!.Entities.Where(e => e is { IsLocalized: true, IsOwnedEntity: true });

        foreach (var localizedOwnedEntity in localizedOwnedEntities)
        {
            var localizedRelationShips = localizedOwnedEntity.OwnerEntity!.OwnedRelationships.Where(e=>e.Entity == localizedOwnedEntity.Name).ToList();
            foreach (var rel in localizedRelationShips)
            {
                string name;
                if(localizedRelationShips.Count(r=>r.Entity == rel.Entity) == 1)
                    name = rel.WithSingleEntity()
                        ? rel.Entity
                        : rel.EntityPlural;
                else
                {
                    name = rel.Name;
                }
                
                entityPaths.Add(string.Concat("/", name));
            }
        }

        return entityPaths;
    }

}