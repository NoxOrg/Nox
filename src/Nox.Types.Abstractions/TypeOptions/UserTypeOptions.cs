using Nox.Types;

namespace Nox.TypeOptions;

public class UserTypeOptions
{
    public int MinLength { get; internal set; } = 0;

    public int MaxLength { get; internal set; } = 511;

    public bool ValidEmailFormat { get; internal set; } = true;

    public bool ValidGuidFormat { get; internal set;} = true;

    public bool IsCaseSensitive { get; internal set; } = true;

}
