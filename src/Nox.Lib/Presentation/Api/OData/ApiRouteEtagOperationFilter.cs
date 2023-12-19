using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.OData;

public class ApiRouteEtagOperationFilter:  IOperationFilter
{
    private  static readonly  string[] _eTagRequiredHttpMethods = { "PUT", "PATCH", "DELETE" };
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        Console.WriteLine(context.ApiDescription.HttpMethod);
        if (_eTagRequiredHttpMethods.Contains(context.ApiDescription.HttpMethod))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "etag",
                Description = "etag parameter for concurrency check",
                In = ParameterLocation.Header,
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