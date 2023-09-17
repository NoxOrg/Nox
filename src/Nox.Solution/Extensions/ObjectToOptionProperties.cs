using System.Collections;
using System.Globalization;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Solution.Extensions;
using YamlDotNet.Serialization;

namespace Nox.Solution.Extensions;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class OptionProperty
{
    public string Type { get; set; } = default!;
    public string Name { get; set; } = default!;
    public dynamic? Value { get; set; }

    // Add any other required attributes here
}

public static class ObjectToOptionProperties
{
    public static List<OptionProperty> ToOptionProperties(this object obj, bool fullyQualifiedNames = true)
    {
        var optionProperties = new List<OptionProperty>();
        var cache = new HashSet<object>();
        GenerateOptionProperties(obj, optionProperties, cache, fullyQualifiedNames);
        cache.Clear();
        return optionProperties;
    }

    private static void GenerateOptionProperties(object obj, List<OptionProperty> optionProperties, HashSet<object> cache, bool fullyQualifiedNames)
    {
        Type objType = obj.GetType();
       
        PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanWrite)
            .Where(p => !Attribute.IsDefined(p, typeof(YamlIgnoreAttribute)))
            .ToArray();

        foreach (PropertyInfo property in properties)
        {
            // var value = property.GetValue(obj);

             obj.ToOptionProperty(property, optionProperties, cache,fullyQualifiedNames);
           

            // // Recursively process nested objects
            // if (!cache.Contains(value))
            // {
            //     cache.Add(value);
            //     GenerateOptionProperties(value, optionProperties, cache, fullyQualifiedNames);
            // }
            
        }
    }
    
    private static void ToOptionProperty(this object obj, PropertyInfo property, List<OptionProperty> optionProperties, HashSet<object> cache,  bool fullyQualifiedNames = true)
    {
        var value = property.GetValue(obj);

        var optionProperty = new OptionProperty
        {
            Name = property.Name
        };
        
        
        if (value == null)
        {
            optionProperty.Type = string.Empty;
            optionProperty.Value = null;
            optionProperties.Add(optionProperty);
            return;
        }
        
        Type rawType = value.GetType();
        Type valueType = Nullable.GetUnderlyingType(rawType) ?? rawType;
        
        if (value is Uri uriValue)
        {
            optionProperty.Type = nameof(Uri);
            optionProperty.Value = GetValueAsString(uriValue.ToString());
        }  
        else if (value is Guid guidValue)
        {
            optionProperty.Type = nameof(Guid);
            optionProperty.Value = GetValueAsString(guidValue.ToString());
        }
        else if (value is DateTime dateTimeValue)
        {
            optionProperty.Type = nameof(DateTime);
            optionProperty.Value = dateTimeValue;
        }
        else if (value is DateTimeOffset dateTimeOffsetValue)
        {
            optionProperty.Type = nameof(DateTimeOffset);
            optionProperty.Value = dateTimeOffsetValue;
        }
        else if (value is TimeSpan timeSpanValue)
        {
            optionProperty.Type = nameof(TimeSpan);
            optionProperty.Value = timeSpanValue;
        }
        else if (value is string stringValue)
        {
            optionProperty.Type = nameof(String);
            optionProperty.Value = stringValue;
        }
        else if (valueType.IsSimpleType())
        {
            optionProperty.Type = "SimpleType";
            optionProperty.Value = value;
        }
        else if (valueType.IsEnum)
        {
            optionProperty.Type = nameof(Enum);
            var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
            var valueAsString = GetValueAsString(value);
            valueAsString = IsReservedKeyword(valueAsString) ? $"@{valueAsString}" : valueAsString;
            optionProperty.Value = $"{valueTypeName}.{valueAsString}";
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
        {
            optionProperty.Type = nameof(IList);
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            optionProperty.Type = nameof(IDictionary);
        }
        else if (valueType.IsArray)
        {
            optionProperty.Type = nameof(Array);
        }
        else
        {
            // optionProperty.Value = value.ToOptionProperties(fullyQualifiedNames);
        }
        
        
        optionProperties.Add(optionProperty);
    }
    
    private static bool IsReservedKeyword(string word)
    {
        if (SyntaxFacts.GetKeywordKind(word) != SyntaxKind.None || SyntaxFacts.GetContextualKeywordKind(word) != SyntaxKind.None)
        {
            return true;
        }
        return false;
    }
    private static string GetValueAsString(object value)
    {
        if (value is string stringValue)
        {
            return stringValue.ToLiteral();
        }
        else if (value is char)
        {
            return $"'{value}'";
        }
        else if (value is bool boolValue)
        {
            return boolValue ? "true" : "false";
        }
        else if (value is decimal decValue)
        {
            return $"{decValue.ToString(CultureInfo.InvariantCulture)}m";
        }
        else if (value is float floatValue)
        {
            return $"{floatValue.ToString(CultureInfo.InvariantCulture)}f";
        }
        else if (value is double doubleValue)
        {
            return $"{doubleValue.ToString(CultureInfo.InvariantCulture)}";
        }
        else
        {
            return value.ToString()!;
        }
    }
}
