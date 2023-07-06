namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Language"/> type and value object.
/// </summary>
public sealed class Language : ValueObject<string, Language>
{
    private LanguageTypeOptions _languageTypeOptions = new();

    public Language()
    {
        Value = string.Empty;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Language"/> using the specified <see cref="LanguageTypeOptions"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="Text"/> with</param>
    /// <param name="languageCode">The string to create the <see cref="Text"/> with</param>
    /// <param name="options">The <see cref="LanguageTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">If the email address is invalid.</exception>
    public static Language From(string value, LanguageTypeOptions options)
    {
        var newObject = new Language
        {
            Value = value,
            _languageTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Language"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Language"/> value is valid to Language.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Length < _languageTypeOptions.MinLangValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Language type that is {Value.Length} characters long and shorter than the minimum specified length of {_languageTypeOptions.MinLangValue}"));
        }

        if (Value.Length > _languageTypeOptions.MaxLangValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Language type that is {Value.Length} characters long and longer than the maximum specified length of {_languageTypeOptions.MaxLangValue}"));
        }

        if(!ValidLanguage.ValidateLanguage(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Language type that with unsupported value '{Value}'"));
        }

        return result;
    }
}
