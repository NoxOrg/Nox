using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class TranslatedTextTests
{
    [Fact]
    public void TranslatedText_Constructor_ReturnsSameValue()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar-SA");


        var translatedText = TranslatedText.From((arabicCultureCode, translatedTestString));

        translatedText.Value.Phrase.Should().Be(translatedTestString);
        translatedText.Value.CultureCode.Should().Be(arabicCultureCode);
    }

    [Fact]
    public void TranslatedTextOptions_Constructor_ReturnsDefaults()
    {
        var translatedTextOptions = new TranslatedTextTypeOptions();

        translatedTextOptions.MinLength.Should().Be(0);
        translatedTextOptions.MaxLength.Should().Be(511);
        translatedTextOptions.CharacterCasing.Should().Be(TextTypeCasing.Normal);
    }

    [Fact]
    public void TranslatedText_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsValidationException()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var exception =  Assert.Throws<NoxTypeValidationException>(() => _ =
            TranslatedText.From((arabicCultureCode, translatedTestString), new TranslatedTextTypeOptions { MaxLength = 15 })
        );

        exception.Errors.First().ErrorMessage.Should().Be($"Could not create a Nox TranslatedText type that is {translatedTestString.Length} characters long and longer than the maximum specified length of 15.");
    }

    [Fact]
    public void TranslatedText_Constructor_SpecifyingMinLength_WithShorterLengthInput_ThrowsValidationException()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var exception = Assert.Throws<NoxTypeValidationException>(() => _ =
            TranslatedText.From((arabicCultureCode, translatedTestString), new TranslatedTextTypeOptions { MinLength = 100 })
            ); 

        exception.Errors.First().ErrorMessage.Should().Be($"Could not create a Nox TranslatedText type that is {translatedTestString.Length} characters long and shorter than the minimum specified length of 100.");
    }

    [Fact]
    public void TranslatedText_Constructor_SpecifyingUppercase_WithNormalCaseInput_ReturnsUpperInvariantCase()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var translatedText = TranslatedText.From((arabicCultureCode, translatedTestString), new TranslatedTextTypeOptions { CharacterCasing = TextTypeCasing.Upper });

        translatedText.Value.Phrase.Should().Be(translatedTestString.ToUpperInvariant());
    }

    [Fact]
    public void TranslatedText_Constructor_SpecifyingLowercase_WithNormalCaseInput_ReturnsLowerInvariantCase()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var translatedText = TranslatedText.From((arabicCultureCode, translatedTestString), new TranslatedTextTypeOptions { CharacterCasing = TextTypeCasing.Lower });

        translatedText.Value.Phrase.Should().Be(translatedTestString.ToLowerInvariant());
    }

    [Fact]
    public void TranslatedText_Equality_Tests()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var translatedText1 = TranslatedText.From((arabicCultureCode, translatedTestString));

        var translatedText2 = TranslatedText.From((arabicCultureCode, translatedTestString));

        translatedText1.Should().Be(translatedText2);

        translatedText1.Phrase.Should().Be(translatedText2.Phrase);
        translatedText1.CultureCode.Should().Be(translatedText2.CultureCode);
        translatedText1.Should().BeEquivalentTo(translatedText2);
    }

    [Fact]
    public void TranslatedText_WithDifferentOptions_NonEquality_Tests()
    {
        var translatedTestString = "It's a test designed to provoke an emotional response - Holden";
        var cultureCode = CultureCode.From("en-UK");

        var translatedText1 = TranslatedText.From((cultureCode, translatedTestString), new TranslatedTextTypeOptions { MinLength =5, MaxLength=1000, CharacterCasing = TextTypeCasing.Lower});

        var translatedText2 = TranslatedText.From((cultureCode, translatedTestString));

        translatedText1.Should().NotBe(translatedText2);

        translatedText1.Phrase.Should().NotBe(translatedText2.Phrase);
        translatedText1.Phrase.Should().Be(translatedText2.Phrase.ToLowerInvariant());
        translatedText1.CultureCode.Should().Be(translatedText2.CultureCode);
        translatedText1.Should().NotBeEquivalentTo(translatedText2);
    }

    [Fact]
    public void TranslatedText_WithInvalidTextCasing_ThrowsException()
    {
        var translatedTestString = "It's a test designed to provoke an emotional response - Holden";
        var cultureCode = CultureCode.From("en-UK");

        var exception = Assert.Throws<NotSupportedException>(() => _ =
                 TranslatedText.From((cultureCode, translatedTestString), new TranslatedTextTypeOptions { MinLength = 5, MaxLength = 1000, CharacterCasing = (TextTypeCasing)100 })
        );
    }

    [Fact]
    public void TranslatedText_NonEquality_Tests()
    {
        var translatedTestString = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicSACultureCode = CultureCode.From("ar-SA");
        var arabicAECultureCode = CultureCode.From("ar-AE");

        var translatedText1 = TranslatedText.From((arabicSACultureCode, translatedTestString));

        var translatedText2 = TranslatedText.From((arabicAECultureCode, translatedTestString));

        translatedText1.Should().NotBe(translatedText2);

        translatedText1.Phrase.Should().Be(translatedText2.Phrase);
        translatedText1.CultureCode.Should().NotBe(translatedText2.CultureCode);
        translatedText1.Should().NotBeEquivalentTo(translatedText2);
    }

    [Fact]
    public void TranslatedText_ToString_Returns_TextValue()
    {
        var translatedTestString1 = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var translatedText = TranslatedText.From((arabicCultureCode, translatedTestString1));

        var translatedTestString2 = translatedText.ToString();

        Assert.Equal(translatedTestString1, translatedTestString2);
    }

    [Fact]
    public void TranslatedText_GetCopy_ReturnsCopy()
    {
        var translatedTestString1 = "إنه اختبار مصمم لإثارة استجابة عاطفية - هولدن";
        var arabicCultureCode = CultureCode.From("ar");

        var translatedText1 = TranslatedText.From((arabicCultureCode, translatedTestString1));

        var translatedText2 = translatedText1.GetCopy();

        translatedText2.Should().NotBeNull();
        translatedText2.Should().Be(translatedText1);
        translatedText2.Should().BeEquivalentTo(translatedText1);
        translatedText2.Should().BeSameAs(translatedText2);
        translatedText1.Should().BeSameAs(translatedText1);
        translatedText2.Should().NotBeSameAs(translatedText1);
        translatedText1.CultureCode.Should().Be(translatedText2!.Value.CultureCode.Value);
        translatedText1.Phrase.Should().Be(translatedText2!.Value.Phrase);
    }
}
