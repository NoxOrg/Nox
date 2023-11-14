using System.Collections.Generic;
using System;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Parser;

internal sealed class ReadOnlyCollectionNodeTypeResolver : INodeTypeResolver
{
    public bool Resolve(NodeEvent? nodeEvent, ref Type type)
    {
        if (type.IsInterface && type.IsGenericType && _customGenericInterfaceImplementations.TryGetValue(type.GetGenericTypeDefinition(), out var concreteType))
        {
            type = concreteType.MakeGenericType(type.GetGenericArguments());
            return true;
        }
        return false;
    }

    private static readonly IReadOnlyDictionary<Type, Type> _customGenericInterfaceImplementations = new Dictionary<Type, Type>
    {
        {typeof(IReadOnlyCollection<>), typeof(List<>)},
        {typeof(IReadOnlyList<>), typeof(List<>)},
        {typeof(IReadOnlyDictionary<,>), typeof(Dictionary<,>)}
    };
}