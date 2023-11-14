using Nox.Yaml.Extensions;
using Nox.Yaml.Parser;

namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class UniqueItemPropertiesAttribute : Attribute
{
    private readonly string[] _propertyKeys;

    private readonly HashSet<string> _duplicates = new();

    internal string Keys => string.Join(".", _propertyKeys);

    internal string Duplicates => string.Join(",", _duplicates.Select(s => $"\"{s}\"").ToArray());

    public UniqueItemPropertiesAttribute(params string[] propertyKeys)
    {
        _propertyKeys = propertyKeys.Select(s => s.ToCamelCase()).ToArray();
    }

    internal bool IsValid(IReadOnlyList<Dictionary<string, (object? Value, YamlLineInfo LineInfo)>> objectInstances)
    {
        var valuesSeen = new HashSet<string>();

        foreach (var obj in objectInstances)
        {
            var value = string.Empty;
            foreach (var key in _propertyKeys)
            {
                if (!obj.ContainsKey(key))
                {
                    throw new ArgumentException($"Property '{key}' not found on element of collection.");
                }
                value += obj[key].Value?.ToString();
            }
            if (valuesSeen.Contains(value))
            {
                _duplicates.Add(value);
            }
            else
            {
                valuesSeen.Add(value);
            }
        }
        return _duplicates.Count == 0;
    }

}

