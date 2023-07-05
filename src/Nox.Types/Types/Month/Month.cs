namespace Nox.Types;

/// <summary>
/// Month value object that represents a month of the year.
/// </summary>
public class Month : ValueObject<byte, Month>
{
    /// <summary>
    /// The minimum valid month value.
    /// </summary>
    private const byte MinMonthValue = 1;

    /// <summary>
    /// The maximum valid month value.
    /// </summary>
    private const byte MaxMonthValue = 12;

    /// <summary>
    /// Validates the <see cref="Month"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Month"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value is < MinMonthValue or > MaxMonthValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Month type with unsupported value '{Value}'. The value must be between {MinMonthValue} and {MaxMonthValue}."));
        }
        return result;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString("00");
    }
}
