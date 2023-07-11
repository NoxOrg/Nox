
using FluentAssertions;
using Nox.Types.Tests.Types.LanguageCode;

namespace Nox.Types.Tests;

public class LanguageCodeTests
{
    [Theory]
    [ClassData(typeof(LanguageCodeTestsDataClass))]
    public void CreatingLanguageCode_From_IsValid(string languageCodeString)
    {
        var languageCode = LanguageCode.From(languageCodeString);

        languageCode.Value.Should().Be(languageCodeString);
    }

    [Fact]
    public void CreatingLanguageCode_UnsupportedLanguageCode_ThrowsValidationException()
    {
        var action = () => LanguageCode.From("abc");

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox LanguageCode type with unsupported value 'abc'.") });
    }

    [Fact]
    public void CreatingLanguageCode_SameLanguageCode_ReturnsEqual()
    {
        var languageCode1 = LanguageCode.From("en");

        var languageCode2 = LanguageCode.From("en");

        languageCode2.Should().Be(languageCode1);
    }


    [Fact]
    public void CreatingLanguageCode_CaseDifferentLanguageCode_ReturnsEqual()
    {
        var languageCode1 = LanguageCode.From("en");

        var languageCode2 = LanguageCode.From("EN");

        languageCode2.Should().Be(languageCode1);
    }


    [Fact]
    public void CreatingLanguageCode_DifferentLanguageCode_ReturnsUnEqual()
    {
        var languageCode3_1 = LanguageCode.From("EN");

        var languageCode3_2 = LanguageCode.From("PT");

        languageCode3_2.Should().NotBe(languageCode3_1);
    }

    [Fact]
    public void LanguageCode_ToString_ReturnsValueAsString()
    {
        var languageCode = LanguageCode.From("en");

        languageCode.ToString().Should().Be("en");
    }


    private static readonly string[] _languageCodes = 
    {
        "aa","ab","af","ak","am","an","ar","as","av","ay","az","ba","be","bg","bh","bi","bm","bn","bo","br","bs","ca","ce","ch","co","cr","cs","cv","cy",
        "da","de","dv","dz","ee","el","en","es","et","eu","fa","ff","fi","fj","fo","fr","fy","ga","gd","gl","gn","gu","gv","ha","he","hi","ho","hr","ht",
        "hu","hy","hz","id","ig","ii","ik","io","is","it","iu","ja","jv","ka","kg","ki","kj","kk","kl","km","kn","ko","kr","ks","ku","kv","kw","ky","lb",
        "lg","li","ln","lo","lt","lu","lv","mg","mh","mi","mk","ml","mn","mr","ms","mt","my","na","nb","nd","ne","ng","nl","nn","no","nr","nv","ny","oc",
        "oj","om","or","os","pa","pl","ps","pt","qu","rm","rn","ro","ru","rw","sa","sc","sd","se","sg","si","sk","sl","sm","sn","so","sq","sr","ss","st",
        "su","sv","sw","ta","te","tg","th","ti","tk","tl","tn","to","tr","ts","tt","tw","ty","ug","uk","ur","uz","ve","vi","wa","wo","xh","yi","yo","za",
        "zh","zu",
    };
    [Fact]
    public void LanguageCode_TestAllKnownLanguageCodes_Passes()
    {
        var action = () => _languageCodes.Select(code => LanguageCode.From(code));

        action.Should().NotThrow<TypeValidationException>();
    }
}