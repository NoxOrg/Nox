#if !NETSTANDARD
using System;
using Nox.Types;
using Json.Schema;
using Json.Schema.Generation;
using Nox.Solution.Schema;

namespace Nox.Solution.Resolvers;


/// <summary>
/// Generates schema for type according to data annotations.
/// </summary>
public static class SchemaGenerator
{
    /// <summary>
    /// Generates schema for type according to data annotations.
    /// </summary>
    /// <typeparam name="TType">Any class type</typeparam>
    /// <returns>JsonSchema</returns>
    public static JsonSchema Generate<TType>()
    {
        var schemaConfig = new SchemaGeneratorConfiguration()
        {
            PropertyNamingMethod = PropertyNamingMethods.CamelCase,
            Nullability = Nullability.AllowForNullableValueTypes,
            Refiners = { new EnumToCamelCaseRefiner(excludeTypes: new Type[] { typeof(CurrencyCode) }) },
            Generators = { new ReadOnlyStringDictionarySchemaGenerator() },
            Optimize = false
        };

        var schema = new JsonSchemaBuilder()
           .Schema(MetaSchemas.Draft7Id)
           .FromType<TType>(schemaConfig)
           .Build();

        return schema;
    }
}
#endif