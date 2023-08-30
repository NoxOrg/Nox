using FluentAssertions;
using FluentAssertions.Execution;

namespace Nox.Types.Tests.Types;

public class FormulaTests
{
    [Theory]
    [InlineData("FirstName.ToString() + LastName.ToString()")]
    [InlineData("DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0) ")]
    [InlineData("DateOfBirth.ToString(\"\") + LastName.ToString()")]
    [InlineData("Arr[5+int.Parse(str)]")]
    [InlineData("1+2*{5+4/[2+2-(3-2)]}")]
    [InlineData("(((1+2+3)+4)+5)")]
    public void From_WithValidBrackets_ReturnsValue(string expression)
    {
        var formula = Formula.From(expression);

        formula.Value.Should().Be(expression);
    }

    [Theory]
    [InlineData("FirstName.ToString() + LastName.ToString()")]
    [InlineData("DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0) ")]
    [InlineData("DateOfBirth.ToString(\"\") + LastName.ToString()")]
    [InlineData("Arr[5+int.Parse(str)]")]
    [InlineData("1+2*{5+4/[2+2-(3-2)]}")]
    [InlineData("(((1+2+3)+4)+5)")]
    public void From_WithTypeOptionsAndValidBrackets_ReturnsValue(string expression)
    {
        var formula = Formula.From(new FormulaTypeOptions
        {
            Expression = expression,
        });

        formula.Value.Should().Be(expression);
    }

    [Theory]
    [InlineData("FirstName.ToString( + LastName.ToString()")]
    [InlineData("FirstName.ToString()) + LastName.ToString()")]
    [InlineData("DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0() ")]
    [InlineData("Arr[5+int.Parse(str)")]
    [InlineData("Arr(5+int.Parse(str)]")]
    [InlineData("1+2*{5+4/[2+1}+2-(3-2)]")]
    public void From_WithTypeOptionsAndInvalidBrackets_ThrowsValidationException(string expression)
    {
        var action = () => Formula.From(new FormulaTypeOptions
        {
            Expression = expression,
            Returns = FormulaReturnType.Bool,
        });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox Formula type as expression value {expression} contains invalid sequence of brackets.") });
    }

    [Theory]
    [InlineData(FormulaReturnType.String, typeof(string))]
    [InlineData(FormulaReturnType.Int, typeof(int))]
    [InlineData(FormulaReturnType.Long, typeof(long))]
    [InlineData(FormulaReturnType.Double, typeof(double))]
    [InlineData(FormulaReturnType.Bool, typeof(bool))]
    [InlineData(FormulaReturnType.DateTime, typeof(System.DateTime))]
    public void ExpressionAndReturnsProperties_WithValidObjet_ReturnValue(FormulaReturnType returnType, Type expectedType)
    {
        var formula = Formula.From(new FormulaTypeOptions
        {
            Expression = "Attr",
            Returns = returnType
        });

        formula.Expression.Should().Be("Attr");
        formula.ReturnType.Should().Be(expectedType);
    }

    [Fact]
    public void ToString_WithValidObject_ReturnsFormattedString()
    {
        var formula = Formula.From(new FormulaTypeOptions
        {
            Expression = "FirstName.ToString() + LastName.ToString()",
            Returns = FormulaReturnType.String

        });

        formula.ToString().Should().Be("(string):FirstName.ToString() + LastName.ToString()");
    }

    [Fact]
    public void Equality_WithSameExpressionAndReturnType_ShouldBeEquivalent()
    {
        var formula1 = Formula.From(new FormulaTypeOptions
        {
            Expression = "FirstName.ToString() + LastName.ToString()",
            Returns = FormulaReturnType.String
        });

        var formula2 = Formula.From(new FormulaTypeOptions
        {
            Expression = "FirstName.ToString() + LastName.ToString()",
            Returns = FormulaReturnType.String
        });

        AssertAreEquivalent(formula1, formula2);
    }

    [Theory]
    [InlineData("attr1 + attr2", FormulaReturnType.String, "attr1 + attr2", FormulaReturnType.Int)]    // Same expression, different return type
    [InlineData("attr1 + attr2", FormulaReturnType.String, "attr3 + attr4", FormulaReturnType.String)] // Different expression, same return type
    [InlineData("attr1 + attr2", FormulaReturnType.String, "attr3 + attr4", FormulaReturnType.Int)]    // Different expression, different return type
    public void NonEquality_WithVariousExpressionAndReturnTypeCombinations_ShouldNotBeEquivalent(string expression1, FormulaReturnType returnType1, string expression2, FormulaReturnType returnType2)
    {
        var formula1 = Formula.From(new FormulaTypeOptions
        {
            Expression = expression1,
            Returns = returnType1
        });

        var formula2 = Formula.From(new FormulaTypeOptions
        {
            Expression = expression2,
            Returns = returnType2
        });

        AssertAreNotEquivalent(formula1, formula2);
    }

    private static void AssertAreEquivalent(Formula expected, Formula actual)
    {
        using var scope = new AssertionScope();

        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Formula expected, Formula actual)
    {
        using var scope = new AssertionScope();

        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}