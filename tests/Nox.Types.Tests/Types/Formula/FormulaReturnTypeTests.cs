using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class FormulaReturnTypeTests
{
    [Theory]
    [InlineData(FormulaReturnType.@string, typeof(string))]
    [InlineData(FormulaReturnType.@int, typeof(int))]
    [InlineData(FormulaReturnType.@long, typeof(long))]
    [InlineData(FormulaReturnType.@double, typeof(double))]
    [InlineData(FormulaReturnType.@bool, typeof(bool))]
    [InlineData(FormulaReturnType.DateTime, typeof(System.DateTime))]
    public void AsNativeType_WithVariousFormulaReturnTypes_ReturnsNativeType(FormulaReturnType returnType, Type expectedType)
    {
        returnType.AsNativeType().Should().Be(expectedType);
    }
}
