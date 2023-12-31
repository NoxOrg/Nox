
using System.Collections.Immutable;
using Nox.Yaml.Attributes;
using Nox.Yaml.Enums.CultureCode;

namespace Nox.Yaml;

public class Constants
{
    // Well-known yaml patterns

    public const string YamlVariableRegex = @"^\$\{\{\s*(.+)\.(.+)\s*\}\}$";

    public const string VersionStringRegex = @"^(\d+\.)?(\d+\.)?(\*|\d+)$";

    public const string StringWithNoSpacesRegex = @"^[^\s]*$";

    // Variable prefixes

    public const string EnvironmentVariablesKey = "env";

    public const string SecretVariablesKey = "secret";
    
    public static readonly ImmutableSortedDictionary<string,Culture> CultureCodes = Enum.GetValues(typeof(Culture))
        .Cast<Culture>()
        .ToImmutableSortedDictionary(x =>
            {
                var field = x.GetType().GetField(x.ToString())!;
                var attribute = field.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
                return attribute?.DisplayName ?? x.ToString();
            }, 
            x => x);
}