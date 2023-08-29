using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YamlDotNet.Serialization;

namespace Nox.Solution.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Walks the properties of an object and performs an action on each property.
    /// </summary>
    /// <param name="obj">The object to walk the properties of.</param>
    /// <param name="propertyAction">The action to perform on each property. The action will be passed the full path of the property and its value as arguments.</param>
    /// <param name="path">The current path of the object being walked. This parameter is for internal use and should not be specified when calling the method.</param>
    public static void WalkProperties(this object obj, Action<string, object> propertyAction, string path = "")
    {
        if (obj == null)
        {
            propertyAction(path, null!);
            return;
        }

        var type = obj.GetType();

        if (type.IsSimpleType())
        {
            propertyAction(path, obj);
        }
        else if (type.IsDictionary())
        {
            var dictionary = obj as IDictionary;
            if (dictionary != null)
            {
                foreach (var key in dictionary.Keys)
                {
                    var value = dictionary[key];
                    var fullPath = string.IsNullOrEmpty(path) ? $"[{key}]" : $"{path}[{key}]";
                    if (value == null)
                    {
                        propertyAction(fullPath, null!);
                    }
                    else
                    {
                        value.WalkProperties(propertyAction, fullPath);
                    }
                }
            }
        }
        else if (type.IsArray || type.IsEnumerable())
        {
            var enumerable = obj as IEnumerable;
            if (enumerable != null)
            {
                propertyAction(path, obj);

                var index = 0;
                foreach (var item in enumerable)
                {
                    item.WalkProperties(propertyAction, $"{path}[{index}]");
                    index++;
                }
            }
        }
        else
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);
                var fullPath = string.IsNullOrEmpty(path) ? propertyName : $"{path}.{propertyName}";

                WalkProperties(propertyValue!, propertyAction, $"{fullPath}");

            }
        }
    }

    /// <summary>
    /// Generates C# source code that creates an instance of a class with the same values as the input object.
    /// </summary>
    /// <param name="obj">The input object whose values will be used to generate source code.</param>
    /// <param name="variableName">The name of the variable that will hold the created instance in the source code.</param>
    /// <returns>C# source code as a string.</returns>
    public static string ToSourceCode(this object obj, string variableName, bool fullyQualifiedNames = true)
    {
        StringBuilder sourceCode = new StringBuilder();
        var cache = new HashSet<object>();
        GenerateSourceCode(obj, variableName, sourceCode, 0, cache, fullyQualifiedNames);
        cache.Clear();
        return sourceCode.ToString();
    }

    private static void GenerateSourceCode(object obj, string className, StringBuilder sourceCode, int indentationLevel, HashSet<object> cache, bool fullyQualifiedNames)
    {

        string indentation = GetIndentation(indentationLevel);
        string lineTerminator = ",";

        Type objType = obj.GetType();
        
        PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanWrite)
            .Where(p => !Attribute.IsDefined(p, typeof(YamlIgnoreAttribute)))
            .ToArray();

        if (indentationLevel == 0)
        {
            var valueTypeName = fullyQualifiedNames ? objType.FullName : objType.Name;
            sourceCode.AppendLine($"{GetIndentation(indentationLevel)}{valueTypeName} {className} = new ()");
            lineTerminator = ";";
        }
        sourceCode.AppendLine($"{indentation}{{");
        foreach (PropertyInfo property in properties)
        {
            var value = property.GetValue(obj);
            if (value != null)
            {
                GeneratePropertySourceCode(property.Name, value, className, sourceCode, indentationLevel + 1, cache, fullyQualifiedNames);
            }
        }
        sourceCode.AppendLine($"{indentation}}}{lineTerminator}");
    }

    private static void GeneratePropertySourceCode(string propertyName, object value, string className, StringBuilder sourceCode, int indentationLevel, HashSet<object> cache, bool fullyQualifiedNames)
    {
        string indentation = GetIndentation(indentationLevel);
        string assignOp = string.IsNullOrEmpty(propertyName) ? string.Empty : " = ";
        string genericLib = fullyQualifiedNames ? "System.Collections.Generic." : string.Empty;
        string systemLib = fullyQualifiedNames ? "System." : string.Empty;

        Type rawType = value.GetType();

        Type valueType = Nullable.GetUnderlyingType(rawType) ?? rawType;

        if (value == null)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}null");
        }
        else if (value is Uri uriValue)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {systemLib}Uri({GetValueAsString(uriValue.ToString())}),");
        }
        else if (value is Guid guidValue)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {systemLib}Guid({GetValueAsString(guidValue.ToString())}),");
        }
        else if (value is DateTime dateTimeValue)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {systemLib}DateTime({dateTimeValue.Year},{dateTimeValue.Month},{dateTimeValue.Day},{dateTimeValue.Hour},{dateTimeValue.Minute},{dateTimeValue.Second},{dateTimeValue.Millisecond}),");
        }
        else if (value is DateTimeOffset dtOffsetValue)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {systemLib}DateTimeOffset({dtOffsetValue.Year},{dtOffsetValue.Month},{dtOffsetValue.Day},{dtOffsetValue.Hour},{dtOffsetValue.Minute},{dtOffsetValue.Second},{dtOffsetValue.Millisecond}, new {systemLib}TimeSpan({dtOffsetValue.Offset.Ticks})),");
        }
        else if (value is TimeSpan tsValue)
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {systemLib}TimeSpan({tsValue.Ticks}),");
        }
        else if (valueType.IsSimpleType())
        {
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}{GetValueAsString(value)},");
        }
        else if (valueType.IsEnum)
        {
            var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}{valueTypeName}.{GetValueAsString(value)},");
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
        {
            IList list = (IList)value;
            var valueTypeName = fullyQualifiedNames ? valueType.GetGenericArguments()[0].FullName : valueType.GetGenericArguments()[0].Name;

            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {genericLib}List<{valueTypeName}>()");
            sourceCode.AppendLine($"{indentation}{{");
            foreach (var item in list)
            {
                GeneratePropertySourceCode("", item, className, sourceCode, indentationLevel + 1, cache, fullyQualifiedNames);
            }
            sourceCode.AppendLine($"{indentation}}},");
        }
        else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            IDictionary dictionary = (IDictionary)value;
            var valueTypeName1 = fullyQualifiedNames ? valueType.GetGenericArguments()[0].FullName : valueType.GetGenericArguments()[0].Name;
            var valueTypeName2 = fullyQualifiedNames ? valueType.GetGenericArguments()[1].FullName : valueType.GetGenericArguments()[1].Name;

            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {genericLib}Dictionary<{valueTypeName1}, {valueTypeName2}>()");
            sourceCode.AppendLine($"{indentation}{{");
            foreach (DictionaryEntry entry in dictionary)
            {
                if (entry.Key == null || entry.Value == null) continue;

                GeneratePropertySourceCode("[" + GetValueAsString(entry.Key) + "]", entry.Value, className, sourceCode, indentationLevel + 1, cache, fullyQualifiedNames);
            }
            sourceCode.AppendLine($"{indentation}}},");
        }
        else if (valueType.IsArray)
        {
            Array array = (Array)value;
            Type elementType = valueType.GetElementType()!;

            var elementTypeName = fullyQualifiedNames ? elementType.FullName : elementType.Name;


            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {elementTypeName}[]");
            sourceCode.AppendLine($"{indentation}{{");
            for (int i = 0; i < array.Length; i++)
            {
                GeneratePropertySourceCode($"", array.GetValue(i)!, className, sourceCode, indentationLevel + 1, cache, fullyQualifiedNames);
            }
            sourceCode.AppendLine($"{indentation}}},");
        }
        else
        {
            if (cache.Contains(value))
            {
                return;
            }
            cache.Add(value);
            var valueTypeName = fullyQualifiedNames ? valueType.FullName : valueType.Name;
            sourceCode.AppendLine($"{indentation}{propertyName}{assignOp}new {valueTypeName}()");
            GenerateSourceCode(value, $"{propertyName}Value", sourceCode, indentationLevel, cache, fullyQualifiedNames);
        }
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
            return $"{decValue}m";
        }
        else
        {
            return value.ToString()!;
        }
    }

    private static string GetIndentation(int level)
    {
        return new string(' ', level * 4);
    }
}
