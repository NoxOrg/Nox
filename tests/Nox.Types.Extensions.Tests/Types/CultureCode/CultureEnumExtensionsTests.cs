using FluentAssertions;
using Nox.Types.Abstractions.Extensions;

namespace Nox.Types.Extensions.Tests.Types.CultureCode;

public class CultureEnumExtensionsTests
{
    [Theory]
    [InlineData(Culture.tr_TR)]
    [InlineData(Culture.en)]
    [InlineData(Culture.agq_CM)]
    [InlineData(Culture.bs_Latn_BA)]
    public void WhenGettingReferenceCulture_WithValidCultureEnum_ThenReturnsCulture(Culture cultureEnum)
    {
        // Arrange Act
        var culture = cultureEnum.GetReferenceCulture();
        // Assert
        culture.Should().NotBeNull();
        culture.Name.Should().Be(cultureEnum.ToDisplayName());
    }
}