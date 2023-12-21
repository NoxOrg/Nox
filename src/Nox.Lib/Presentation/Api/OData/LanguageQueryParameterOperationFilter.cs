using Microsoft.OpenApi.Models;
using Nox.Solution;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.OData;

public class LanguageQueryParameterOperationFilter: IOperationFilter
{
    private readonly HashSet<string> _auditEntityPaths;

    public LanguageQueryParameterOperationFilter(NoxSolution noxSolution)
    {
        _auditEntityPaths = 
            noxSolution.Domain!.Entities.Where(e => e.IsLocalized)
                .Select(e=> string.Concat(noxSolution.Presentation.ApiConfiguration.ApiRoutePrefix, "/", e.PluralName)).ToHashSet();
    }
    
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method && _auditEntityPaths.Any(p => p.Contains(context.ApiDescription.RelativePath!)))
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
}