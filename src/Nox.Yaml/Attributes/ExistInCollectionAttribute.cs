using Nox.Yaml.Extensions;
using Nox.Yaml.Parser;

namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class ExistInCollectionAttribute : Attribute
{
    private readonly string[] _collectionPathKeys;

    private readonly string _propertyKey;

    internal string Path => string.Join(".", _collectionPathKeys);

    public ExistInCollectionAttribute(params string[] propertyPath)
    {
        if (propertyPath.Length < 2)
            throw new ArgumentException("You need to specify at least one path to the collection and the property name as the last parameter.");

        _collectionPathKeys = propertyPath.Take(propertyPath.Length - 1)
            .Select(e => e.ToCamelCase())
            .ToArray();

        _propertyKey = propertyPath.Last().ToCamelCase();
    }

    internal bool IsValid(string value, Dictionary<string, (object? Value, YamlLineInfo LineInfo)> objectInstance, string fileInfo)
    {
        var targetNode = objectInstance;

        // Traverse the properties
        foreach (var prop in _collectionPathKeys.Take(_collectionPathKeys.Length - 1))
        {
            if (!targetNode.ContainsKey(prop))
            {
                throw new ArgumentException($"Invalid '{prop}' in path '{Path}'. {fileInfo}");
            }

            var element = targetNode[prop].Value;

            if (element is Dictionary<string, (object? Value, YamlLineInfo LineInfo)> objElement)
            {
                targetNode = objElement;
            }
            else
            {
                throw new ArgumentException($"Invalid '{prop}' in path '{Path}'. {fileInfo}");
            }
        }

        // This should be the collection
        var collectionKey = _collectionPathKeys.Last();

        if (!targetNode.ContainsKey(collectionKey))
        {
            throw new ArgumentException($"Invalid '{collectionKey}' in path '{Path}'. {fileInfo}");
        }

        var collection = targetNode[collectionKey].Value;

        if (collection is object[] targetCollection)
        {
            foreach (var objectElement in targetCollection)
            {
                if (objectElement is Dictionary<string, (object? Value, YamlLineInfo LineInfo)> element)
                {
                    if (!element.ContainsKey(_propertyKey))
                    {
                        throw new ArgumentException($"Property '{_propertyKey}' not found in collection '{Path}'. {fileInfo}");
                    }
                    if (value.Equals(element[_propertyKey].Value))
                    {
                        return true;
                    }
                }
            }
        }
        else
        {
            throw new ArgumentException($"Property '{collectionKey}' in collection '{Path}' is not a list or enumarable. {fileInfo}");
        }
        return false;
    }

}

