using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

/// <summary>
/// The translated text type options.
/// </summary>

public class TranslatedTextTypeOptions : INoxTypeOptions
{
    /// <summary>
    /// Gets the min length.
    /// </summary>
    public int MinLength { get; set; } = 0;

    /// <summary>
    /// Gets the max length.
    /// </summary>
    public int MaxLength { get; set; } = 511;

    /// <summary>
    /// Gets the character casing.
    /// </summary>
    public TextTypeCasing CharacterCasing { get; set; } = TextTypeCasing.Normal;
}