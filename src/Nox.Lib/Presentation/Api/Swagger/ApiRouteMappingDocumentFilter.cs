﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Nox.Solution;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.Presentation.Api.Swagger;

/// <summary>
/// This filter is intended to format default OData generated API
/// to more usable form specyfing particular entities available
/// </summary>
internal class ApiRouteMappingDocumentFilter : IDocumentFilter
{
    private readonly NoxSolution _solution;

    public ApiRouteMappingDocumentFilter(NoxSolution solution)
    {
        _solution = solution;
    }

    /// <summary>
    /// Interface method that applies filter change to swagger definition
    /// </summary>
    /// <param name="openApiDocument">Swagger definition</param>
    /// <param name="context">Filterting context</param>
    public void Apply(OpenApiDocument openApiDocument, DocumentFilterContext context)
    {
        var routes = _solution.Presentation.ApiConfiguration.ApiRouteMappings;

        var tags = new[]
{
            new OpenApiTag
            {
                Name = "Mapppings",
            }
        };

        var newPaths = new OpenApiPaths();

        foreach (var route in routes)
        {

            // define operation
            var operation = new OpenApiOperation
            {
                OperationId = route.Route,
                Summary = route.Description,
            };

            // assign tag
            operation.Tags.Add(new OpenApiTag { Name = route.Name });

            // create parameter properties
            foreach (var inputParam in route.RequestInput)
            {
                var p = new OpenApiParameter
                {
                    Name = inputParam.Name,
                    Description = inputParam.Description ?? string.Empty,
                    AllowEmptyValue = !inputParam.IsRequired,
                    In = FindParameterLocationInRoute(inputParam.Name, route.Route),
                    Schema = new OpenApiSchema()
                    {
                        Type = inputParam.JsonTypeString,
                    }
                };

                if (inputParam.Default is not null)
                {
                    p.Schema.Default = DefaultToOpenApiAny(inputParam);
                }

                if (inputParam.Format is not null)
                {
                    p.Schema.Format = inputParam.JsonFormatString;
                }

                operation.Parameters.Add(p);
            }

            // add request body if it's supplied

            if (route.JsonBodyType is not null 
                && route.HttpVerb != HttpVerb.Get)
            {
                operation.RequestBody = new OpenApiRequestBody()
                {
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>()
                    {
                        [route.RequestContentTypeString] = new OpenApiMediaType
                        {
                            Schema = ToOpenApiSchema(route.JsonBodyType)
                        }
                    },
                };
            }


            // create response
            var response = new OpenApiResponse
            {
                Description = "Success"
            };

            // add response type
            response.Content.Add(route.ResponseContentTypeString, new OpenApiMediaType
            {
                Schema = ToOpenApiSchema(route.ResponseOutput)
            });

            // adding response to operation
            operation.Responses.Add("200", response);

            // finally add the path to document
            var routeKey = $"{_solution.Presentation.ApiConfiguration.ApiRoutePrefix}{route.Route}";
            if (newPaths.TryGetValue(routeKey, out var existing))
            {
                existing.Operations.Add(RouteHttpVerbToOperationType(route.HttpVerb), operation);
            }
            else
            {
                // create path item
                var pathItem = new OpenApiPathItem();

                // add operation to the path
                pathItem.AddOperation(RouteHttpVerbToOperationType(route.HttpVerb), operation);
                newPaths.Add(routeKey, pathItem);
            }
        }

        openApiDocument.Paths.ToList()
            .ForEach(p => newPaths.Add(p.Key, p.Value));

        openApiDocument.Paths = newPaths;


    }

    private static ParameterLocation FindParameterLocationInRoute(string paramName, string route)
    {
        var parts = route.Split('?');

        if (parts.Length == 2 && parts[1].Contains($"{paramName}"))
            return ParameterLocation.Query;

        return ParameterLocation.Path;
    }

    private static OpenApiSchema ToOpenApiSchema(JsonTypeDefinition typeDefinition)
    {

        var schema = new OpenApiSchema
        {
            AdditionalPropertiesAllowed = false,
            Description = typeDefinition.Description,
            Type = typeDefinition.JsonTypeString,
            Format = typeDefinition.JsonFormatString,
        };

        switch (typeDefinition.Type)
        {
            case JsonType.Array:
                schema.Items = ToOpenApiSchema(typeDefinition.Items);
                break;

            case JsonType.Object:
                schema.Properties = typeDefinition.Attributes
                    .ToDictionary(t => t.Name, ToOpenApiSchema);
                break;

            default:
                break;
        }

        return schema;
    }

    private static OperationType RouteHttpVerbToOperationType(HttpVerb httpVerb)
    {
        return httpVerb switch
        {
            HttpVerb.Get => OperationType.Get,
            HttpVerb.Post => OperationType.Post,
            HttpVerb.Put => OperationType.Put,
            HttpVerb.Delete => OperationType.Delete,
            HttpVerb.Patch => OperationType.Patch,
            _ => throw new NotSupportedException()
        };
    }


    private static IOpenApiAny? DefaultToOpenApiAny(JsonTypeDefinition t)
    {
        if (t.Default is null) return null;

        return t.Type switch
        {
            JsonType.Number => new OpenApiDouble(Convert.ToDouble(t.Default)),
            JsonType.Integer => new OpenApiInteger(Convert.ToInt32(t.Default)),
            JsonType.String => new OpenApiString((string)t.Default),
            JsonType.Boolean => new OpenApiBoolean(Convert.ToBoolean(t.Default)),
            JsonType.Null => new OpenApiNull(),
            _ => throw new NotImplementedException(),
        };
    }

}