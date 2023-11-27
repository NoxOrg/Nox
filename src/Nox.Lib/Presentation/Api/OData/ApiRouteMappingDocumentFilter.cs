using Azure.Security.KeyVault.Keys;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nox.Docs.Extensions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nox.OData;

/// <summary>
/// This filter is intended to format default OData generated API
/// to more usable form specyfing particular entities available
/// </summary>
public class ApiRouteMappingDocumentFilter : IDocumentFilter
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
                Summary = route.Description
            };

            // assign tag
            operation.Tags.Add(new OpenApiTag { Name = route.Name });

            // create parameter properties
            route.ParameterDefaults
                .Select(t => new OpenApiParameter()
                    {
                        Name = t.Key,
                        AllowEmptyValue = true,
                        Description = $"Default = {t.Value}",
                    }
                )
                .ToList()
                .ForEach( p => operation.Parameters.Add(p) );

            

            // create response properties
            var properties = (route.ResponseOutput.ObjectTypeOptions?.Attributes ?? Array.Empty<NoxSimpleTypeDefinition>())
                .ToDictionary(t => t.Name, t => new OpenApiSchema()
                {
                    Type = t.Type.ToString(),
                    Description = t.Description,
                }
                );

            // create response
            var response = new OpenApiResponse
            {
                Description = "Success"
            };

            // add response type
            response.Content.Add("application/json;odata.metadata=minimal;odata.streaming=true", new OpenApiMediaType
            {
                Schema = new OpenApiSchema
                {
                    Type = "object", 
                    AdditionalPropertiesAllowed = false,
                    Properties = properties,
                }
            });

            // adding response to operation
            operation.Responses.Add("200", response);

            // create path item
            var pathItem = new OpenApiPathItem();
            
            // add operation to the path
            pathItem.AddOperation(RouteHttpVerbToOperationType(route.HttpVerb), operation);
         
            
            // finally add the path to document
            newPaths.Add(
                $"{_solution.Presentation.ApiConfiguration.ApiRoutePrefix}{route.Route}"
                , pathItem);
        
        }

        openApiDocument.Paths.ToList()
            .ForEach(p => newPaths.Add(p.Key, p.Value));

        openApiDocument.Paths = newPaths;

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

}