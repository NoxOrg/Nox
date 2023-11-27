using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        if(!context.SchemaRepository.Schemas.ContainsKey(objectType.Name))
        {
            context.SchemaGenerator.GenerateSchema(objectType, context.SchemaRepository);
        }

        var objectSchema = context.SchemaRepository.Schemas[objectType.Name];

        schema.Properties = objectSchema.Properties;
    }
}