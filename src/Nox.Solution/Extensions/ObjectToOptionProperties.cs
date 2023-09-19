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

        foreach (PropertyInfo property in properties)
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
            IList list = (IList)value;
            var elementTypeName = fullyQualifiedNames ? valueType.GetGenericArguments()[0].FullName : valueType.GetGenericArguments()[0].Name;

            var properties = new List<OptionProperty>();
            foreach (var item in list )
            {
                var subProperty = ToOptionProperty(string.Empty, item, fullyQualifiedNames);
                properties.Add(subProperty);
            }
            
            optionProperty.Value = new { ElementTypeName = elementTypeName, Properties = properties };
            
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            optionProperty.Type = nameof(IDictionary);
            IDictionary dictionary = (IDictionary)value;
            
            var dictionaryKeyType = fullyQualifiedNames ? valueType.GetGenericArguments()[0].FullName : valueType.GetGenericArguments()[0].Name;
            var dictionaryValueType = fullyQualifiedNames ? valueType.GetGenericArguments()[1].FullName : valueType.GetGenericArguments()[1].Name;

            var properties = new List<OptionProperty>();
            
            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null || entry.Value == null) continue;
                var subProperty = ToOptionProperty("[" + GetValueAsString(entry.Key) + "]", entry.Value!, fullyQualifiedNames);
                properties.Add(subProperty);
            }
            optionProperty.Value = new { KeyTypeName = dictionaryKeyType, ValueTypeName = dictionaryValueType, Properties = properties };
            
        }
        else if (valueType.IsArray)
        {
            optionProperty.Type = nameof(Array);
            Array array = (Array)value;
            Type elementType = valueType.GetElementType()!;

            var elementTypeName = fullyQualifiedNames ? elementType.FullName : elementType.Name;
            var properties = new List<OptionProperty>();
            for (int i = 0; i < array.Length; i++)
            {
                var subProperty =ToOptionProperty(string.Empty, array.GetValue(i)!, fullyQualifiedNames);
                properties.Add(subProperty);
            }
            optionProperty.Value = new { ElementTypeName = elementTypeName, Properties = properties };
            
        }
        else
        {
            var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
            optionProperty.Type = valueTypeName!;
            var subProperties = GenerateOptionProperties(value, fullyQualifiedNames);
            optionProperty.Value = new { Properties = subProperties };
        }
        
        return optionProperty;
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
