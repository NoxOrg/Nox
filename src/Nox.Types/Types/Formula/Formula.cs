using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Formula"/> type and value object.
/// </summary>
public class Formula : ValueObject<string, Formula>
{
    private FormulaTypeOptions _formulaTypeOptions = new();

    /// <summary>
    /// Creates a new instance of <see cref="Formula"/> object.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Formula From(FormulaTypeOptions options)
    {
        var newObject = new Formula
        {
            Value = options.Expression,
            _formulaTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Gets the return type of the formula.
    /// </summary>
    public Type ReturnType => _formulaTypeOptions.Returns.AsNativeType();

    /// <summary>
    /// Gets the formula expression.
    /// </summary>
    public string Expression => Value;

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!AreBracketsValid())
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Formula type as expression value {Value} contains invalid sequence of brackets."));
        }

        return result;
    }

    /// <summary>
    /// Converts the instance of the object to string in format (returnType):expression.
    /// </summary>
    public override string ToString()
        => $"({_formulaTypeOptions.Returns}):{Value}";

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), Value!);
        yield return new KeyValuePair<string, object>(nameof(_formulaTypeOptions.Returns), _formulaTypeOptions.Returns);
    }

    private bool AreBracketsValid()
    {
        Stack<char> openingBrackets = new();
        foreach (char character in Value!)
        {
            if (character is '(' or '[' or '{')
            {
                openingBrackets.Push(character);
            }
            else if (character is ')' or ']' or '}')
            {
                if (openingBrackets.Count == 0 || !AreMatchingBrackets(openingBrackets.Pop(), character))
                {
                    return false;
                }
            }
        }

        return openingBrackets.Count == 0;
    }

    private static bool AreMatchingBrackets(char openingBracket, char closingBracket)
    {
        return (openingBracket == '(' && closingBracket == ')')
            || (openingBracket == '[' && closingBracket == ']')
            || (openingBracket == '{' && closingBracket == '}');
    }
}
