using FluentAssertions;
using Nox.Reference;

namespace Nox.Types.Extensions.Tests.Types.CultureCode;

public class CultureExtensionsTests : WorldTestBase
{
    [Theory]
    [InlineData(Culture.tr_TR)]
    [InlineData(Culture.en_US)]
    [InlineData(Culture.bs_Latn_BA)]
    public void WhenGettingReferenceCulture_WithValidCultureCode_ThenReturnsCulture(Culture cultureEnum)
    {
        // Arrange Act
        var cultureCode = Nox.Types.CultureCode.From(cultureEnum);
        var culture = World.Cultures.FirstOrDefault(c=> c.Name == cultureCode.Value);
        
        // Assert
        culture.Should().NotBeNull();
        culture!.GetCultureCode().Should().Be(cultureCode);
    }
}