using System.Collections.Generic;
using System;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

internal sealed class ReadOnlyCollectionNodeTypeResolver : INodeTypeResolver
{
    public bool Resolve(NodeEvent? nodeEvent, ref Type type)
    {
        if (type.IsInterface && type.IsGenericType && CustomGenericInterfaceImplementations.TryGetValue(type.GetGenericTypeDefinition(), out var concreteType))
        {
            type = concreteType.MakeGenericType(type.GetGenericArguments());
            return true;
        }
        return false;
    }
    private static readonly IReadOnlyDictionary<Type, Type> CustomGenericInterfaceImplementations = new Dictionary<Type, Type>
    {
        {typeof(IReadOnlyCollection<>), typeof(List<>)},
        {typeof(IReadOnlyList<>), typeof(List<>)},
        {typeof(IReadOnlyDictionary<,>), typeof(Dictionary<,>)}
    };
}