using Json.Schema.Generation;
using Nox.Types;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class TranslatedTextTypeOptions : DefinitionBase
    {
        public int MinLength { get; internal set; } = 0;

        public int MaxLength { get; internal set; } = 511;

        public TextTypeCasing CharacterCasing { get; internal set; } = TextTypeCasing.Normal;
    }
}