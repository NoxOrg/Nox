namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class UserTypeOptions
{
    public int MinLength { get; set; } = 0;

    public int MaxLength { get; set; } = 511;

    public bool ValidEmailFormat { get; set; } = true;

    public bool ValidGuidFormat { get; set; } = true;

    public bool IsCaseSensitive { get; set; } = true;

}
