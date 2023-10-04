//using Microsoft.AspNetCore.OData.Deltas;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;

//namespace Cryptocash.Api.Infrastructure;

//internal class DeltaSchemaFilter : ISchemaFilter
//{
//    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
//    {
//        if (!context.Type.IsGenericType || !context.Type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Delta<>)))
//        {
//            return;
//        }

//        var objectType = context.Type.GetGenericArguments()[0];
//        var objectSchema = context.SchemaRepository.Schemas[objectType.Name];

//        schema.Properties = objectSchema.Properties;
//    }
//}