using System.Linq;
using Nox.Yaml.Attributes;

namespace Nox.Types.Abstractions.Extensions;

public static class CultureExtensions
{
    public static string ToDisplayName(this Culture culture)
    {
        var field = culture.GetType().GetField(culture.ToString());
        var attribute = field?.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
        return attribute?.DisplayName ?? culture.ToString();
    }
}