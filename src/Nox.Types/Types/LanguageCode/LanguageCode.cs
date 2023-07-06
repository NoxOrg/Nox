using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Class for two-letter language codes (ISO 639-1)
/// </summary>
public sealed class LanguageCode : ValueObject<string, LanguageCode>
{
    private static readonly Regex _languageCodeRegex = new(@"^([a][f]|sq|am|[a]r|[h]y|as|eu|[b]e|[b]n|[b]s|[b]r|[b]g|[m]y|[k]m|[c]a|[c]h|[c]e|[n]y|[z]h|[c]o|[h]r|[c]s|[d]a|[n]l|[d]z|[e]n|[e]t|[t]l|[f]i|[f]r|[f]y|[g]l|[k]a|[d]e|[e]l|[g]u|[h]t|[h]a|[h]e|[h]i|[h]u|[i]s|[i]o|[g]a|[i]t|[j]a|[j]v|[k]n|[k]k|[r]w|[k]y|[k]o|[k]u|[l]o|[l]v|[l]t|[l]b|[m]k|[m]g|[m]s|[m]l|[m]t|[m]i|[m]r|[m]n|[n]e|[n]o|[o]r|[p]s|[f]a|[p]l|[p]t|[p]a|[r]o|[r]u|[g]d|[s]r|[g]d|[s]i|[s]k|[s]l|[s]o|[s]o|[e]s|[s]w|[s]v|[t]a|[t]e|[t]h|[t]r|[u]k|[u]r|[v]i|[c]y|[x]h|yi|zu)$", RegexOptions.Compiled);

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        Value = Value.ToLowerInvariant();

        if (!_languageCodeRegex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LanguageCode type with unsupported value '{Value}'."));
        }

        return result;
    }
}