using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class FormulaReturnTypeTests
{
    [Theory]
    [InlineData(FormulaReturnType.String, typeof(string))]
    [InlineData(FormulaReturnType.Int, typeof(int))]
    [InlineData(FormulaReturnType.Long, typeof(long))]
    [InlineData(FormulaReturnType.Double, typeof(double))]
    [InlineData(FormulaReturnType.Bool, typeof(bool))]
    [InlineData(FormulaReturnType.DateAndTime, typeof(System.DateTime))]
    public void AsNativeType_WithVariousFormulaReturnTypes_ReturnsNativeType(FormulaReturnType returnType, Type expectedType)
    {
        returnType.AsNativeType().Should().Be(expectedType);
    }
}
