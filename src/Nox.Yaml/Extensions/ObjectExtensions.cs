using Nox.Yaml.Attributes;
using System.Collections;
using System.Reflection;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Extensions;

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
            if (obj is IDictionary dictionary)
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
            if (obj is IEnumerable enumerable)
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
                if (property.GetCustomAttribute<YamlIgnoreAttribute>() is not null)
                {
                    continue;
                }

                var propertyName = property.Name;
                var propertyValue = property.GetValue(obj);
                var fullPath = string.IsNullOrEmpty(path) ? propertyName : $"{path}.{propertyName}";

                WalkProperties(propertyValue!, propertyAction, $"{fullPath}");

            }
        }
    }

    /// <summary>
    /// Walks the properties of an object and performs an action on each property.
    /// </summary>
    /// <param name="obj">The object to walk the properties of.</param>
    /// <param name="propertyAction">The action to perform on each property. The action will be passed the full path of the property and its value as arguments.</param>
    /// <param name="path">The current path of the object being walked. This parameter is for internal use and should not be specified when calling the method.</param>
    public static void WalkObjectTypes(this object obj, Action<string, Type, object, object> propertyAction, string path = "", object parent = null!)
    {
        if (obj == null)
        {
            return;
        }

        var type = obj.GetType();

        if (type.IsSimpleType())
        {
            // do nothing
        }
        else if (type.IsDictionary())
        {
            if (obj is IDictionary dictionary)
            {
                foreach (var key in dictionary.Keys)
                {
                    var value = dictionary[key];
                    var fullPath = string.IsNullOrEmpty(path) ? $"[{key}]" : $"{path}[{key}]";
                    if (value != null)
                    {
                        value.WalkObjectTypes(propertyAction, fullPath, parent);
                    }
                }
            }
        }
        else if (type.IsArray || type.IsEnumerable())
        {
            if (obj is IEnumerable enumerable)
            {
                var index = 0;
                foreach (var item in enumerable)
                {
                    item.WalkObjectTypes(propertyAction, $"{path}[{index}]", parent);
                    index++;
                }
            }
        }
        else
        {
            parent ??= obj; // for first call

            propertyAction(path, type, obj, parent);
            
            parent = obj;

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<YamlIgnoreAttribute>() is not null)
                {
                    continue;
                }

                if (property.GetCustomAttribute<IgnoreAttribute>() is not null)
                {
                    continue;
                }

                var propertyName = property.Name;

                try
                {
                    var propertyValue = property.GetValue(obj);
                    var fullPath = string.IsNullOrEmpty(path) ? propertyName : $"{path}.{propertyName}";
                    WalkObjectTypes(propertyValue!, propertyAction, $"{fullPath}", parent);
                }
                catch (Exception)
                {
                    // Ignore if invalid
                }


                }
            }
    }
}
