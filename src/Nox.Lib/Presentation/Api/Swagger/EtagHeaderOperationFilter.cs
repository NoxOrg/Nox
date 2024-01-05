using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.Swagger;

internal class EtagHeaderOperationFilter:  IOperationFilter
{
    private  static readonly  HashSet<string> ETagRequiredHttpMethods = new() { HttpMethod.Delete.Method, HttpMethod.Patch.Method, HttpMethod.Put.Method };
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (ETagRequiredHttpMethods.Contains(context.ApiDescription.HttpMethod!))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "If-Match",
                Description = "Concurrency check id",
                In = ParameterLocation.Header,
                Style = ParameterStyle.Simple,
                Schema = new OpenApiSchema
                {
                    Type = "string", 
                    Format = "uuid",
                    Pattern = "^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[89abAB][a-fA-F0-9]{3}-[a-fA-F0-9]{12}$"
                },
                Required = false
            });
        }
    }
}