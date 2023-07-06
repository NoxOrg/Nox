using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class LanguageConverter : ValueConverter<Language, string>
{
    public LanguageConverter() : base(language => language.Value, languageValue => Language.From(languageValue))
    {
    }
}