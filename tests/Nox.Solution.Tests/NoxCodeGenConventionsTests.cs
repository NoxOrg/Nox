using FluentAssertions;

namespace Nox.Solution.Tests;

public class NoxCodeGenConventionsTests
{
    [Theory]
    [InlineData("Europe", "Europe")]
    [InlineData("North America", "North_America")]
    [InlineData("North!America", "NorthAmerica")]
    [InlineData("North#$America", "NorthAmerica")]
    [InlineData("0Europe", "_0Europe")]
    [InlineData("Europe123", "Europe123")]
    public void GetEnumPropertyName_Should_Return_Valid_CSharp_Identifier(string name, string expected)
    {
        NoxCodeGenConventions.GetEnumPropertyName(name).Should().Be(expected);
    }
}
