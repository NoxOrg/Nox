namespace Nox.Types.Tests.Types;

public class TextTests
{
    [Fact]
    public void Text_Constructor_ReturnsSameValue()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = Text.From(testString);

        Assert.Equal(testString, text.Value);
    }

    [Fact]
    public void TextOptions_Constructor_ReturnsDefaults()
    {
        var textOptions = new TextTypeOptions();

        Assert.True(textOptions.IsUnicode);
        Assert.Equal(0u,textOptions.MinLength);
        Assert.Equal(255u, textOptions.MaxLength);
        Assert.Equal(TextTypeCasing.Normal,textOptions.Casing);
    }

    [Fact]
    public void Text_Constructor_SpecifyingNonUnicode_WithNonUnicodeCharacterInput_ReturnsSameValue()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = Text.From(testString, new TextTypeOptions { IsUnicode = false });

        Assert.Equal(testString, text.Value);

    }

    [Fact]
    public void Text_Constructor_SpecifyingNonUnicode_WithUnicodeCharacterInput_ThrowsValidationException()

    {
        var testString = "二兎を追う者は一兎をも得ず。"; // English translation: “Those who chase two hares won’t even catch one.”

        Assert.Throws<TypeValidationException>(() => _ =
            Text.From(testString, new TextTypeOptions { IsUnicode = false })
        );

    }

    [Fact]
    public void Text_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsValidationException()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        Assert.Throws<TypeValidationException>(() => _ =
            Text.From(testString, new TextTypeOptions { MaxLength = 3 })
        );
    }

    [Fact]
    public void Text_Constructor_SpecifyingMinLength_WithShorterLengthInput_ThrowsValidationException()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        Assert.Throws<TypeValidationException>(() => _ = 
            Text.From(testString, new TextTypeOptions { MinLength = 100 })
        );
    }

    [Fact]
    public void Text_Constructor_SpecifyingUppercase_WithNormalCaseInput_ReturnsUpperInvariantCase()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = Text.From(testString, new TextTypeOptions { Casing = TextTypeCasing.Upper });

        Assert.Equal(testString.ToUpperInvariant(), text.Value);
    }

    [Fact]
    public void Text_Constructor_SpecifyingLowercase_WithNormalCaseInput_ReturnsLowerInvariantCase()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = Text.From(testString, new TextTypeOptions { Casing = TextTypeCasing.Lower });

        Assert.Equal(testString.ToLowerInvariant(), text.Value);
    }

    [Fact]
    public void Text_Equality_Tests()
    {
        var testString1 = "It's a test designed to provoke an emotional response - Holden";

        var text1 = Text.From(testString1);

        var testString2 = "It's a test designed to provoke an emotional response - Holden";

        var text2 = Text.From(testString2);

        Assert.Equal(text1,text2);

        Assert.True(text1.Equals(text2));

        Assert.True(text2.Equals(text1));

        Assert.True(text1 == text2);

        Assert.False(text1 != text2);
    }

    [Fact]
    public void Text_NonEquality_Tests()
    {
        var testString1 = "It's a test designed to provoke an emotional response - Holden";

        var text1 = Text.From(testString1);

        var testString2 = "二兎を追う者は一兎をも得ず。"; // English translation: “Those who chase two hares won’t even catch one.”

        var text2 = Text.From(testString2);

        Assert.NotEqual(text1, text2);

        Assert.False(text1.Equals(text2));

        Assert.False(text2.Equals(text1));

        Assert.False(text1 == text2);

        Assert.True(text1 != text2);
    }

    [Fact]
    public void Text_ToString_Returns_Value()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text = Text.From(testString);

        var testString2 = text.ToString();

        Assert.Equal(testString, testString2);
    }

    [Fact]
    public void Text_GetCopy_ReturnsCopy()
    {
        var testString = "It's a test designed to provoke an emotional response - Holden";

        var text1 = Text.From(testString);

        var text2 = text1.GetCopy();

        Assert.NotNull(text2);

        // they look equal
        Assert.Equal(text1, text2);
        Assert.True(text1 == text2);

        // ..and this obviously true
        Assert.True(Object.ReferenceEquals(text1, text1));

        // .. and this is obviously true too
        Assert.True(Object.ReferenceEquals(text2, text2));

        // .. but this is only true if the text1 was cloned/copied to text2
        Assert.False(Object.ReferenceEquals(text1, text2));
    }
}