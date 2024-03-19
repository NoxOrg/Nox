namespace Nox.Yaml;

public class Constants
{
	// Well-known yaml patterns

	public const string YamlVariableRegex = @"\${{[^}]+.[^}]+}}";

	public const string VersionStringRegex = @"^(\d+\.)?(\d+\.)?(\*|\d+)$";

    public const string StringWithNoSpacesRegex = @"^[^\s]*$";

    public const string CronExpressionRegex = @"(@(annually|yearly|monthly|weekly|daily|hourly|reboot))|(@every (\d+(ns|us|µs|ms|s|m|h))+)|((((\d+,)+\d+|(\d+(\/|-)\d+)|\d+|\*) ?){5,7})";

    // Variable prefixes

    public const string EnvironmentVariablesKey = "env";

    public const string SecretVariablesKey = "secret";
}