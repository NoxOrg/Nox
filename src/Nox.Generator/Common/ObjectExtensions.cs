using System.Collections;
using System.Globalization;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Domain;
using Nox.Solution.Extensions;
using YamlDotNet.Serialization;

namespace Nox.Solution.Extensions;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

/// <summary>
/// Provides extension methods for converting an object's properties into a list of <see cref="OptionProperty"/>.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Converts an object's properties into a list of <see cref="OptionProperty"/>.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <param name="fullyQualifiedNames">Specifies whether to use fully qualified type names.</param>
    /// <returns>A list of <see cref="OptionProperty"/> representing the object's properties.</returns>
    public static List<OptionProperty> ToOptionProperties(this object obj, bool fullyQualifiedNames = true)
    {
        var optionProperties = GenerateOptionProperties(obj, fullyQualifiedNames);
        return optionProperties;
    }

    private static List<OptionProperty> GenerateOptionProperties(object obj, bool fullyQualifiedNames)
    {
        List<OptionProperty> optionProperties = new();
        Type objType = obj.GetType();
       
        PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanWrite)
            .Where(p => !Attribute.IsDefined(p, typeof(YamlIgnoreAttribute)))
            .ToArray();

        foreach (var property in properties)
        {
             var value = property.GetValue(obj);
             var propertyName = property.Name;
             var optionProperty = ToOptionProperty(propertyName, value, fullyQualifiedNames);
             optionProperties.Add(optionProperty);
        }
        
        return optionProperties;
    }
    
    private static OptionProperty ToOptionProperty(string propertyName, object? value, bool fullyQualifiedNames = true)
    {
        var optionProperty = new OptionProperty
        {
            Name =propertyName
        };
        
        if (value == null)
        {
            optionProperty.Type = string.Empty;
            optionProperty.Value = null;
            return optionProperty;
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
        else if (valueType.IsSimpleType())
        {
            optionProperty.Type = "SimpleType";
            optionProperty.Value = GetValueAsString(value);
        }
        else if (valueType.IsEnum)
        {
            GenerateOptionPropertyForEnum(value, fullyQualifiedNames, optionProperty, valueType);
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
        {
            GenerateOptionPropertyForList(value, fullyQualifiedNames, optionProperty, valueType);
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            GenerateOptionPropertyForDictionary(value, fullyQualifiedNames, optionProperty, valueType);
        }
        else if (valueType.IsArray)
        {
            GenerateOptionPropertyForArray(value, fullyQualifiedNames, optionProperty, valueType);
        }
        else
        {
            GenerateOptionPropertyForOtherTypes(value, fullyQualifiedNames, valueType, optionProperty);
        }
        
        return optionProperty;
    }

    private static void GenerateOptionPropertyForOtherTypes(object value, bool fullyQualifiedNames, Type valueType,
        OptionProperty optionProperty)
    {
        var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
        optionProperty.Type = valueTypeName!;
        var subProperties = GenerateOptionProperties(value, fullyQualifiedNames);
        optionProperty.Value = new { Properties = subProperties };
    }

    private static void GenerateOptionPropertyForArray(object value, bool fullyQualifiedNames,
        OptionProperty optionProperty, Type valueType)
    {
        optionProperty.Type = nameof(Array);
        Array array = (Array)value;
        Type elementType = valueType.GetElementType()!;

        var elementTypeName = fullyQualifiedNames ? elementType.FullName : elementType.Name;
        var properties = new List<OptionProperty>();
        for (int i = 0; i < array.Length; i++)
        {
            var subProperty = ToOptionProperty(string.Empty, array.GetValue(i)!, fullyQualifiedNames);
            properties.Add(subProperty);
        }

        optionProperty.Value = new { ElementTypeName = elementTypeName, Properties = properties };
    }

    private static void GenerateOptionPropertyForDictionary(object value, bool fullyQualifiedNames,
        OptionProperty optionProperty, Type valueType)
    {
        optionProperty.Type = nameof(IDictionary);
        IDictionary dictionary = (IDictionary)value;

        var dictionaryKeyType = fullyQualifiedNames
            ? valueType.GetGenericArguments()[0].FullName
            : valueType.GetGenericArguments()[0].Name;
        var dictionaryValueType = fullyQualifiedNames
            ? valueType.GetGenericArguments()[1].FullName
            : valueType.GetGenericArguments()[1].Name;

        var properties = new List<OptionProperty>();

        foreach (DictionaryEntry entry in dictionary)
        {
            if (entry.Key == null || entry.Value == null) continue;
            var subProperty = ToOptionProperty("[" + GetValueAsString(entry.Key) + "]", entry.Value!, fullyQualifiedNames);
            properties.Add(subProperty);
        }

        optionProperty.Value = new
            { KeyTypeName = dictionaryKeyType, ValueTypeName = dictionaryValueType, Properties = properties };
    }

    private static void GenerateOptionPropertyForList(object value, bool fullyQualifiedNames, OptionProperty optionProperty,
        Type valueType)
    {
        optionProperty.Type = nameof(IList);
        IList list = (IList)value;
        var elementTypeName = fullyQualifiedNames
            ? valueType.GetGenericArguments()[0].FullName
            : valueType.GetGenericArguments()[0].Name;

        var properties = new List<OptionProperty>();
        foreach (var item in list)
        {
            var subProperty = ToOptionProperty(string.Empty, item, fullyQualifiedNames);
            properties.Add(subProperty);
        }

        optionProperty.Value = new { ElementTypeName = elementTypeName, Properties = properties };
    }

    private static void GenerateOptionPropertyForEnum(object value, bool fullyQualifiedNames, OptionProperty optionProperty,
        Type valueType)
    {
        optionProperty.Type = nameof(Enum);
        var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
        var valueAsString = GetValueAsString(value);
        valueAsString = IsReservedKeyword(valueAsString) ? $"@{valueAsString}" : valueAsString;
        optionProperty.Value = $"{valueTypeName}.{valueAsString}";
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
