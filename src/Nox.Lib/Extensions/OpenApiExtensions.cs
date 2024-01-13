using Microsoft.OpenApi.Models;

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
            Tags = new List<OpenApiTag>
                {
                    new OpenApiTag { Name = tagName }
                }
        };
    }

    public static OpenApiOperation WithPathParameters(this OpenApiOperation operation, List<string> parameterNames)
    {
        foreach (var name in parameterNames)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = name,
                In = ParameterLocation.Path,
                Required = true,
                Schema = new OpenApiSchema()
                {
                    Type = "string",
                }
            });
        }
        return operation;
    }

    public static OpenApiOperation WithRequestBody(this OpenApiOperation operation, string? referenceId)
    {
        if (string.IsNullOrEmpty(referenceId))
            return operation;

        operation.RequestBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json",
                    new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.Schema,
                                Id = referenceId
                            }
                        }
                    }
                }
            }
        };
        return operation;
    }

    public static OpenApiOperation WithResponseBody(this OpenApiOperation operation, string? referenceId)
    {
        if (string.IsNullOrEmpty(referenceId))
            return operation;

        operation.Responses["200"].Content = new Dictionary<string, OpenApiMediaType>
        {
            {
                "application/json",
                new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.Schema,
                            Id = referenceId
                        }
                    }
                }
            }
        };
        return operation;
    }

}
