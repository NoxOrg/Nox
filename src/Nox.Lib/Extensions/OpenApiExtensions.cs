using Microsoft.OpenApi;

namespace Nox.Extensions;

public static class OpenApiExtensions
{
    public static OpenApiOperation CreateOperation(string tagName)
    {
        return new OpenApiOperation
        {
            Summary = string.Empty,
            Description = string.Empty,
            Responses = new OpenApiResponses
            {
                ["200"] = new OpenApiResponse
                {
                    Description = "Success"
                }
            },
            Tags = new HashSet<OpenApiTagReference>
            {
                new OpenApiTagReference(tagName, new OpenApiDocument(), string.Empty)
            }
        };
    }

    public static OpenApiOperation WithPathParameters(this OpenApiOperation operation, List<string> parameterNames)
    {
        operation.Parameters ??= new List<IOpenApiParameter>();

        foreach (var name in parameterNames)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = name,
                In = ParameterLocation.Path,
                Required = true,
                Schema = new OpenApiSchema()
                {
                    Type = JsonSchemaType.String,
                }
            });
        }
        return operation;
    }

    public static OpenApiOperation WithRequestBody(this OpenApiOperation operation, string? referenceId, HttpMethod operationType)
    {
        if (string.IsNullOrEmpty(referenceId))
            return operation;

        if (operationType == HttpMethod.Get || operationType == HttpMethod.Delete)
            return operation;

        operation.RequestBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json",
                    new OpenApiMediaType
                    {
                        Schema = CreateSchemaReference(referenceId)
                    }
                }
            }
        };
        return operation;
    }

    public static OpenApiOperation WithResponseBody(this OpenApiOperation operation, string? referenceId, string? responseType = null)
    {
        operation.Responses ??= new OpenApiResponses();
        if (!operation.Responses.ContainsKey("200"))
            operation.Responses.Add("200", new OpenApiResponse { Description = "Success" });

        if (string.IsNullOrEmpty(referenceId))
            return operation;

        IOpenApiSchema schema = responseType is null
            ? CreateSchemaReference(referenceId)
            : new OpenApiSchema
            {
                Type = JsonSchemaType.Array,
                Items = CreateSchemaReference(referenceId)
            };

        if (operation.Responses["200"] is OpenApiResponse response)
        {
            response.Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json",
                    new OpenApiMediaType
                    {
                        Schema = schema
                    }
                }
            };
        }
        return operation;
    }

    private static IOpenApiSchema CreateSchemaReference(string referenceId)
    {
        return new OpenApiSchemaReference(referenceId, new OpenApiDocument(), string.Empty);
    }

}
