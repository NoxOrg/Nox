using Nox.TypeOptions;
using System;

namespace Nox.Types;

/// <summary>
/// The user nox type.
/// </summary>
public sealed class User : ValueObject<string, User>
{
    private UserTypeOptions _userTypeOptions = new();

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public override string Value { protected set => base.Value = _userTypeOptions.IsCaseSensitive ? value : value.ToLowerInvariant(); }

    /// <summary>
    /// Creates a new instance of <see cref="User"/> using the specified <see cref="UserTypeOptions"/>
    /// </summary>
    /// <param name="value">The string to create the <see cref="User"/> with</param>
    /// <param name="options">The <see cref="UserTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">If the user value is invalid.</exception>
    public static User From(string value, UserTypeOptions options)
    {
        var newObject = new User
        {
            _userTypeOptions = options,
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="User"/> object.
    /// </summary>
    /// <returns>true if the <see cref="User"/> value is valid according to the default or specified <see cref="UserTypeOptions"/>.</returns>
    /// <exception cref="NotSupportedException">If the <see cref="UserFormatType"/> is not implemented by this method.</exception>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        var validateFormat = _userTypeOptions.ValidGuidFormat || _userTypeOptions.ValidEmailFormat;
        
        if (validateFormat)
        {
            bool? validGuid = _userTypeOptions.ValidGuidFormat ? Guid.TryParse(Value, out var guidResult) : null;

            bool? validEmail = _userTypeOptions.ValidEmailFormat ? Email.EmailRegex.IsMatch(Value) : null;

            if (validGuid != null && validEmail != null)
            {
                if (!validGuid.Value! && !validEmail.Value!)
                {
                    result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox User type {Value} as it is not a valid guid or email address."));
                }
            }
            else if (validGuid != null && !validGuid.Value)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox User type {Value} as it is not a valid Guid."));
            }
            else if (validEmail != null && !validEmail.Value)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox User type {Value} as it is not a valid email address."));
            }
        }
        
        if (Value.Length < _userTypeOptions.MinLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox User type that is {Value.Length} characters long and shorter than the minimum specified length of {_userTypeOptions.MinLength}."));
        }

        if (Value.Length > _userTypeOptions.MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox User type that is {Value.Length} characters long and longer than the maximum specified length of {_userTypeOptions.MaxLength}."));
        }

        return result;
    }
}
