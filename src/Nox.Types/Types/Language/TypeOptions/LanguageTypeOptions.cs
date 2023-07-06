namespace Nox.Types;
public class LanguageTypeOptions
{
    public static readonly ushort DefaultMinLanguageValue = 2;
    public static readonly ushort DefaultMaxLanguageValue = 50;
    public ushort MinLangValue { get; set; } = DefaultMinLanguageValue;
    public ushort MaxLangValue { get; set; } = DefaultMaxLanguageValue;
}
