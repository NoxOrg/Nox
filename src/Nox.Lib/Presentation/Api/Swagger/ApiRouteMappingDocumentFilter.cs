using Azure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Nox.Extensions;
using Nox.Solution;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace Nox.Presentation.Api.Swagger;

/// <summary>
/// This filter is intended to format default OData generated API
/// to more usable form specyfing particular entities available
/// </summary>
internal partial class ApiRouteMappingDocumentFilter : IDocumentFilter
{
    private readonly NoxSolution _solution;

    public ApiRouteMappingDocumentFilter(NoxSolution solution)
    {
        _solution = solution;
    }

    /// <summary>
    /// Interface method that applies filter change to swagger definition
    /// </summary>
    /// <param name="swaggerDoc">Swagger definition</param>
    /// <param name="context">Filterting context</param>
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
    {
        var routes = _solution.Presentation.ApiConfiguration.ApiRouteMappings;

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

            if (route.JsonBodyType is null && route.ResponseOutput is null)
            {
                AddDefaultDocumentationByTargetUrl(context, route, operation);
            }
            else
            {
                AddDocumentationByRouteConfig(route, operation);
            }

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

        swaggerDoc.Paths.ToList()
            .ForEach(p => newPaths.Add(p.Key, p.Value));

        swaggerDoc.Paths = newPaths;
    }

    private static void AddDocumentationByRouteConfig(ApiRouteMapping route, OpenApiOperation operation)
    {
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
        if (route.ResponseOutput is not null)
            response.Content.Add(route.ResponseContentTypeString, new OpenApiMediaType
            {
                Schema = ToOpenApiSchema(route.ResponseOutput)
            });

        // adding response to operation
        operation.Responses.Add("200", response);
    }

    private void AddDefaultDocumentationByTargetUrl(DocumentFilterContext context, ApiRouteMapping route, OpenApiOperation operation)
    {
        int indexOfQuestionMark = route.TargetUrl.IndexOf('?');
        var targetUrl = indexOfQuestionMark != -1 ? route.TargetUrl[..indexOfQuestionMark] : route.TargetUrl;
        var apiRoutePrefix = _solution.Presentation.ApiConfiguration.ApiRoutePrefix.TrimStart('/');

        var apiDescriptions = context.ApiDescriptions
            .Where(ad => ad.HttpMethod != null
            && ad.HttpMethod.Equals(route.HttpVerbString, StringComparison.OrdinalIgnoreCase)
            && ad.RelativePath != null
            && ad.RelativePath.StartsWith(apiRoutePrefix));

        foreach (var apiDescription in apiDescriptions)
        {
            var relativePathRegex = ConvertToRegex(apiDescription.RelativePath!);
            if (Regex.IsMatch(targetUrl, relativePathRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100)))
            {
                AddRequestBody(operation, apiDescription);
                AddResponse(operation, apiDescription);
                break;
            }
        }
    }

    private static void AddRequestBody(OpenApiOperation operation, ApiDescription apiDescription)
    {
        var bodyParameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(pd => pd.Source.Id == "Body");
        var requestReferenceId = bodyParameterDescription?.Type.Name ?? string.Empty;
        if (requestReferenceId.Contains("Delta"))
            requestReferenceId = (GetTypeFromFullName(bodyParameterDescription?.Type.FullName) ?? string.Empty) + "Delta";
        else if (requestReferenceId.Contains("ReferencesDto"))
            requestReferenceId = (GetTypeFromFullName(bodyParameterDescription?.Type.FullName) ?? string.Empty) + "ReferencesDto";
        operation.WithRequestBody(requestReferenceId);
    }

    private static void AddResponse(OpenApiOperation operation, ApiDescription apiDescription)
    {
        var supportedResponseTypes = apiDescription.SupportedResponseTypes.FirstOrDefault();
        var responseReferenceId = supportedResponseTypes?.Type?.Name;
        if (responseReferenceId is null || responseReferenceId.Contains("IQueryable") || responseReferenceId.Contains("SingleResult"))
            responseReferenceId = GetTypeFromFullName(supportedResponseTypes?.Type?.FullName);

        var responseType = supportedResponseTypes?.Type?.Name;
        if (responseType is not null)
        {
            if (responseType.Contains("Queryable"))
                responseType = "array";
            else if (responseType.Contains("SingleResult"))
            {
                responseReferenceId += "SingleResult";
                responseType = null;
            }
            else
                responseType = null;
        }
        operation.WithResponseBody(responseReferenceId, responseType);
    }

    [GeneratedRegex("\\{.*?\\}")]
    private static partial Regex KeyRegex();

    private string ConvertToRegex(string path)
    {
        var pathWithoutPrefix = path[(_solution.Presentation.ApiConfiguration.ApiRoutePrefix.Length - 1)..];
        var regexPattern = KeyRegex().Replace(pathWithoutPrefix, "{(.+)}");
        regexPattern = regexPattern.Replace("$", "\\$");
        return $"^{regexPattern}$";
    }

    [GeneratedRegex("\\[\\[([^,]+)")]
    private static partial Regex FullNameRegex();

    private static string? GetTypeFromFullName(string? fullName)
    {
        if (fullName is null)
            return null;

        var match = FullNameRegex().Match(fullName);
        if (match.Success)
        {
            var fullType = match.Groups[1].Value.Trim();
            int lastDotIndex = fullType.LastIndexOf('.');
            if (lastDotIndex != -1)
                return fullType[(lastDotIndex + 1)..];
        }

        return null;
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