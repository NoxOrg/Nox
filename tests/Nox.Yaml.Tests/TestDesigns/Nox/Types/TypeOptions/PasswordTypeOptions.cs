using System.Text.RegularExpressions;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;
public class PasswordTypeOptions
{
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;
    public int SaltLength { get; set; } = 64;
    public int MinLength { get; set; } = 8;
    public int MaxLength { get; set; } = 128;
    public bool ForceUppercase { get; set; } = true;
    public bool ForceLowercase { get; set; } = true;
    public bool ForceSymbol { get; set; } = true;
    public bool ForceNumber { get; set; } = true;

    public Regex PasswordContainsUpperCase { get; } = new(@"(.*[A-Z].*)+", RegexOptions.Compiled, new TimeSpan(0, 0, 1));
    public Regex PasswordContainsLowerCase { get; } = new(@"(.*[a-z].*)+", RegexOptions.Compiled, new TimeSpan(0, 0, 1));
    public Regex PasswordContainsSymbol { get; } = new(@"(.*[!@#$%^&*(),.?"":{}|<>\-_].*)+", RegexOptions.Compiled, new TimeSpan(0, 0, 1));
    public Regex PasswordContainsNumber { get; } = new(@"(.*[0-9].*)+", RegexOptions.Compiled, new TimeSpan(0, 0, 1));
}
