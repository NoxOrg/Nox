using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.Swagger;

internal class LanguageQueryParameterOperationFilter : IOperationFilter
{

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method)
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
                    Pattern = Types.Abstractions.CultureCode.RegularExpression
                },
                Required = false
            });
        }
    }
}