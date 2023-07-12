namespace Nox.Types
{
    public class TranslatedTextTypeOptions : INoxTypeOptions
    {
        public int MinLength { get; internal set; } = 0;

        public int MaxLength { get; internal set; } = 511;

        public TextTypeCasing CharacterCasing { get; internal set; } = TextTypeCasing.Normal;
    }
}