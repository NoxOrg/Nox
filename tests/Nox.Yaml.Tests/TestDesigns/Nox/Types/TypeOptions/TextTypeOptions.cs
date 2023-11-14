using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class TextTypeOptions : INoxTypeOptions
{
    public uint MinLength { get; set; } = 0;
    public uint MaxLength { get; set; } = 255;
    public bool IsUnicode { get; set; } = true;
    public bool IsLocalized { get; set; } = false;
    public TextTypeCasing Casing { get; set; } = TextTypeCasing.Normal;
}
