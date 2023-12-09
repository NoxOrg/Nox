namespace Nox.Types;

public class UserTypeOptions : INoxTypeOptions
{
    public int MinLength { get; set; } = 0;

    public int MaxLength { get; set; } = 511;

    public bool ValidEmailFormat { get; set; } = true;

    public bool ValidGuidFormat { get; set;} = true;

    public bool IsCaseSensitive { get; set; } = true;

}
