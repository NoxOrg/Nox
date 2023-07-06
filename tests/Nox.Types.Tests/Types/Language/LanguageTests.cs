using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class LanguageTests
{
    [Fact]
    public void Language_Constructor_ReturnsSameValue()
    {
        var languageString = "English";

        var language = Language.From(languageString);

        language.Value.Should().Be(languageString);
    }

    [Fact]
    public void LanguageOptions_Constructor_ReturnsDefaults()
    {
        var languageOptions = new LanguageTypeOptions();

        languageOptions.MinLangValue.Should().Be(2);
        languageOptions.MaxLangValue.Should().Be(50);
    }

    [Fact]
    public void Language_Constructor_SpecifyingUnknownLanguage_ThrowsValidationException()
    {
        var languageString = "Germanese";

        var action = () => Language.From(languageString);

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Language type that with unsupported value 'Germanese'") });
    }

    [Fact]
    public void Language_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsValidationException()
    {
        var languageString = "German";

        var action = () => Language.From(languageString, new LanguageTypeOptions { MaxLangValue = 3 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Language type that is 6 characters long and longer than the maximum specified length of 3") });
    }

    [Fact]
    public void Language_Constructor_SpecifyingMinLength_WithShorterLengthInput_ThrowsValidationException()
    {
        var languageString = "French";

        var action = () => Language.From(languageString, new LanguageTypeOptions { MinLangValue = 10 });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Language type that is 6 characters long and shorter than the minimum specified length of 10") });
    }

    [Fact]
    public void Language_Equality_Tests()
    {
        var languageString1 = "English";

        var language1 = Language.From(languageString1);

        var languageString2 = "English";

        var language2 = Language.From(languageString2);

        language1.Value.Should().Be(languageString1);
        language2.Value.Should().Be(languageString2);
        language1.Value.Should().Be(language2.Value);
        language2.Value.Should().Be(language1.Value);
    }

    [Fact]
    public void Language_NonEquality_Tests()
    {
        var languageString1 = "English";

        var language1 = Language.From(languageString1);

        var languageString2 = "Portuguese";

        var language2 = Language.From(languageString2);

        language1.Value.Should().NotBe(language2.Value);
        language2.Value.Should().NotBe(language1.Value);
    }

    [Fact]
    public void Text_ToString_Returns_Value()
    {
        var languageString = "Portuguese";

        var language = Language.From(languageString);

        var languageString2 = language.ToString();

        languageString.Should().Be(languageString2);
    }
}