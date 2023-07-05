using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Class for two-letter language codes (ISO 639-1)
/// </summary>
public sealed class LanguageCode : ValueObject<string, LanguageCode>
{
    private static readonly Regex _languageCodeRegex = new(@"^([A][F]|SQ|AM|[A]R|[H]Y|AS|EU|[B]E|[B]N|[B]S|[B]R|[B]G|[M]Y|[K]M|[C]A|[C]H|[C]E|[N]Y|[Z]H|[C]O|[H]R|[C]S|[D]A|[N]L|[D]Z|[E]N|[E]T|[T]L|[F]I|[F]R|[F]Y|[G]L|[K]A|[D]E|[E]L|[G]U|[H]T|[H]A|[H]E|[H]I|[H]U|[I]S|[I]O|[G]A|[I]T|[J]A|[J]V|[K]N|[K]K|[R]W|[K]Y|[K]O|[K]U|[L]O|[L]V|[L]T|[L]B|[M]K|[M]G|[M]S|[M]L|[M]T|[M]I|[M]R|[M]N|[N]E|[N]O|[O]R|[P]S|[F]A|[P]L|[P]T|[P]A|[R]O|[R]U|[G]D|[S]R|[G]D|[S]I|[S]K|[S]L|[S]O|[S]O|[E]S|[S]W|[S]V|[T]A|[T]E|[T]H|[T]R|[U]K|[U]R|[V]I|[C]Y|[X]H|YI|ZU)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_languageCodeRegex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LanguageCode type with unsupported value '{Value}'."));
        }

        return result;
    }
}