
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
}