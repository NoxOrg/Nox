using System.Globalization;
using System.Reflection;
using Humanizer.Localisation.Formatters;

namespace Nox.Integration.Helpers;

public static class ObjectHelpers
{
    public static object? GetPropertyValue(object? instance, string name, PropertyInfo[] properties)
    {
        if (instance == null) return null;
        var prop = properties.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (prop != null)
        {
            return prop.GetValue(instance);
        }

        return null;
    }
    
    public static DateTime? GetDateTimePropertyValue(object? instance, string name, PropertyInfo[] properties)
    {
        if (instance == null) return null;
        var prop = properties.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (prop != null)
        {
            var value = prop.GetValue(instance);
            if (DateTime.TryParse(value?.ToString(), CultureInfo.InvariantCulture, out var dateValue))
            {
                return dateValue;
            }

            return null;
        }

        return null;
    }
    
    public static bool TryGetDateTimePropertyValue(object? instance, string name, PropertyInfo[] properties, out DateTime? value)
    {
        value = null;
        if (instance == null) return false;
        var prop = properties.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (prop != null)
        {
            var rawValue = prop.GetValue(instance);
            if (DateTime.TryParse(rawValue?.ToString(), CultureInfo.InvariantCulture, out var dateValue))
            {
                value = dateValue;
                return true;
            }
        }

        return false;
    }
}