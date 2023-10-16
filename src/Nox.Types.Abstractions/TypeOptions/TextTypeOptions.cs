
namespace Nox.Types;

public class TextTypeOptions : INoxTypeOptions
{
    public uint MinLength { get; set; } = 0;
    public uint MaxLength { get; set; } = 255;
    public bool IsUnicode { get; set; } = true;
    public bool IsLocalized { get; set; } = false;
    public TextTypeCasing Casing { get; set; } = TextTypeCasing.Normal;
}
