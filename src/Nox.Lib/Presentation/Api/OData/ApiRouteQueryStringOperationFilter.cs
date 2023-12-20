using Microsoft.OpenApi.Models;
using Nox.Solution;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.OData;

public class ApiRouteQueryStringOperationFilter: IOperationFilter
{
    private readonly IEnumerable<string> _auditEntityPaths;

    public ApiRouteQueryStringOperationFilter(NoxSolution noxSolution)
    {
        var noxSolution1 = noxSolution;
        _auditEntityPaths = 
            noxSolution1.Domain!.Entities.Where(e => e.Persistence.IsAudited)
                .Select(e=> string.Concat(noxSolution1.Presentation.ApiConfiguration.ApiRoutePrefix.Trim('/'), "/", e.PluralName));
    }
    
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method && _auditEntityPaths.Any(p => context.ApiDescription.RelativePath!.Contains(p)))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "lang",
                Description = "language parameter",
                In = ParameterLocation.Query,
                Style = ParameterStyle.Simple,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Pattern = "^[a-z]{2}-[A-Z]{2}$"
                },
                Required = false
            });
        }
    }
}