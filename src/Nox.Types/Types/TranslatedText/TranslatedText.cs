﻿using System;

namespace Nox.Types;

/// <summary>
/// The translated text class.
/// </summary>
public sealed class TranslatedText : ValueObject<(CultureCode CultureCode, string Phrase), TranslatedText>
{
    public TranslatedTextTypeOptions _translatedTextTypeOptions = new();

    /// <summary>
    /// Gets the phrase.
    /// </summary>
    public string Phrase
    {
        get => Value.Phrase;
        private set => Value = (Value.CultureCode, value);
    }

    /// <summary>
    /// Gets the locale.
    /// </summary>
    public CultureCode CultureCode
    {
        get => Value.CultureCode;
        private set => Value = (value, Value.Phrase);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TranslatedText"/> class.
    /// </summary>
    public TranslatedText() { Value = (CultureCode.From("en-US"), string.Empty); }


    /// <summary>
    /// Creates an instance of  <see cref="TranslatedText"/> class From the provided parameters.
    /// </summary>
    /// <param name="translatedText">The translated text.</param>
    /// <param name="translatedTextTypeOptions">The translated text type options.</param>
    /// <returns>A TranslatedText.</returns>
    public static TranslatedText From((CultureCode cultureCode, string phrase) translatedText, TranslatedTextTypeOptions translatedTextTypeOptions)
    {
        var newObject = new TranslatedText
        {
            _translatedTextTypeOptions = translatedTextTypeOptions,
            CultureCode = translatedText.cultureCode,
            Phrase = translatedText.phrase
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
    /// <inheritdoc />
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Phrase.Length < _translatedTextTypeOptions.MinLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox TranslatedText type that is {Value.Phrase.Length} characters long and shorter than the minimum specified length of {_translatedTextTypeOptions.MinLength}."));
        }

        if (Value.Phrase.Length > _translatedTextTypeOptions.MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox TranslatedText type that is {Value.Phrase.Length} characters long and longer than the maximum specified length of {_translatedTextTypeOptions.MaxLength}."));
        }

        if (_translatedTextTypeOptions.CharacterCasing != TextTypeCasing.Normal)
        {
            Value = _translatedTextTypeOptions.CharacterCasing switch
            {
                TextTypeCasing.Upper => (Value.CultureCode, Value.Phrase.ToUpperInvariant()),
                TextTypeCasing.Lower => (Value.CultureCode, Value.Phrase.ToLowerInvariant()),
                _ => throw new NotSupportedException("Invalid text type casing provided for the translated text type."),
            };
        }

        return result;
    }

    /// <summary>
    /// Returns the translated text.
    /// </summary>
    /// <returns>A string.</returns>
    public override string ToString()
    {
        return Phrase;
    }
}
