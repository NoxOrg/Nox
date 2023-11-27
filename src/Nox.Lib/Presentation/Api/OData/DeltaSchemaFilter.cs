using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;

namespace Nox.OData;

internal class DeltaSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsGenericType || !context.Type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Delta<>)))
        {
            return;
        }
        var objectType = context.Type.GetGenericArguments()[0];

        try
        {
            if (!context.SchemaRepository.Schemas.ContainsKey(objectType.Name))
            {
                context.SchemaGenerator.GenerateSchema(objectType, context.SchemaRepository);
            }

            var objectSchema = context.SchemaRepository.Schemas[objectType.Name];

            schema.Properties = objectSchema.Properties;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to generate schema for {objectType.Name}. {ex.Message}. {ex.StackTrace}");
            Debug.WriteLine($"Failed to generate schema for {objectType.Name}. {ex.Message}. {ex.StackTrace}");
        }
    }
}