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
         
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method && _auditEntityPaths.Contains(context.ApiDescription.RelativePath))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "query",
                Description = "query string parameter",
                In = ParameterLocation.Query,
                Style = ParameterStyle.Simple,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Required = false
            });
        }
    }
}