#if !NETSTANDARD
using System;
using Json.Schema;
using Json.Schema.Generation.Intents;
using Json.Schema.Generation;
using System.Linq;

namespace Nox.Solution.Schema
{
    internal class EnumToCamelCaseRefiner : ISchemaRefiner
    {
        private readonly Type[] _excludeTypes;

        public EnumToCamelCaseRefiner() : this(Array.Empty<Type>())
        {
        }

        public EnumToCamelCaseRefiner(Type[] excludeTypes)
        {
            _excludeTypes = excludeTypes;
        }

        public bool ShouldRun(SchemaGenerationContextBase context)
        {
            // we only want to run this if the generated schema has a `enum` keyword

            if (_excludeTypes.Contains(context.Type))
                return false;

            return context.Intents.OfType<EnumIntent>().Any();
        }

        public void Run(SchemaGenerationContextBase context)
        {
            // find the enum keyword
            var enumIntent = context.Intents.OfType<EnumIntent>().First();
            enumIntent.Names = enumIntent.Names.Select(n => char.ToLowerInvariant(n[0]) + n.Substring(1)).ToList();
        }
    }
}
#endif