using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types.LanguageCode;

public class LanguageExtensionsTests : WorldTestBase
{
    [Fact]
    public void GetReferenceLanguageCode_ValidIsoLanguage_ReturnsExpectedLanguageCode()
    {
        //Arrange
        var languageHasIsoCode = World.Languages.FirstOrDefault(x => x.Iso_639_1 != null)!;
        var languageHasNoIsoCode = World.Languages.FirstOrDefault(x => x.Iso_639_1 == null)!;

        //Act & Assert
        languageHasIsoCode.GetReferenceLanguageCode().Should()
            .Be(Nox.Types.LanguageCode.From(languageHasIsoCode.Iso_639_1!));

        var action = new Action(() => languageHasNoIsoCode.GetReferenceLanguageCode());
        action.Should().Throw<ArgumentNullException>();
    }
}