#if !NETSTANDARD
using System.Collections.Generic;
using System;
using Json.Schema.Generation.Generators;
using Json.Schema;
using Json.Schema.Generation.Intents;
using Json.Schema.Generation;

namespace Nox.Solution.Schema
{
    internal class ReadOnlyStringDictionarySchemaGenerator : ISchemaGenerator
    {
        public bool Handles(Type type)
        {
            if (!type.IsGenericType) return false;

            var generic = type.GetGenericTypeDefinition();

            if (generic != typeof(IReadOnlyDictionary<,>))
                return false;

            var keyType = type.GenericTypeArguments[0];
            return keyType == typeof(string);
        }

        public void AddConstraints(SchemaGenerationContextBase context)
        {
            context.Intents.Add(new TypeIntent(SchemaValueType.Object));

            var valueType = context.Type.GenericTypeArguments[1];
            var valueContext = SchemaGenerationContextCache.Get(valueType);

            context.Intents.Add(new AdditionalPropertiesIntent(valueContext));
        }
    }
}
#endif