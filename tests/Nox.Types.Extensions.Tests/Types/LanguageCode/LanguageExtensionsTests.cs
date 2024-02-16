using FluentAssertions;
using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions.Tests.Types.LanguageCode;

public class LanguageExtensionsTests : WorldTestBase
{
    [Fact]
    public void GetReferenceLanguageCode_ValidIsoLanguage_ReturnsExpectedLanguageCode()
    {
        //Arrange
        using var worldContext = new WorldContext();
        var languageHasIsoCode = worldContext.GetLanguagesQuery().FirstOrDefault(x => x.Iso_639_1 != null)!;
       
        //Act & Assert
        languageHasIsoCode.GetLanguageCode().Should()
            .Be(Nox.Types.LanguageCode.From(languageHasIsoCode.Iso_639_1!));
        
    }
    
    [Fact]
    public void GetReferenceLanguageCode_NullLanguage_ThrowsArgumentNullException()
    {
        //Arrange
        using var worldContext = new WorldContext();
        var languageHasNoIsoCode = worldContext.GetLanguagesQuery().FirstOrDefault(x => x.Iso_639_1 == null)!;

        //Act & Assert
        var action = new Action(() => languageHasNoIsoCode!.GetLanguageCode());
        action.Should().Throw<ArgumentNullException>();
    }
}