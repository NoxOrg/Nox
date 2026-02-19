using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.Swagger;

internal class LanguageQueryParameterOperationFilter : IOperationFilter
{

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method)
        {
            operation.Parameters ??= new List<IOpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = QueryParams.Language,
                Description = "language parameter",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.String,
                    Pattern = Types.Abstractions.CultureCode.RegularExpression
                },
                Required = false
            });
        }
    }
}
