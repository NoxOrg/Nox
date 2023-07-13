using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nox.Types;


/// <summary>
/// Represents an image value object that encapsulates image-related information.
/// </summary>
public sealed class Image : ValueObject<(string Url, string PrettyName, int SizeInBytes), Image>
{
    
    private ImageTypeOptions _imageTypeOptions = new();
    
    /// <summary>
    /// Gets or sets the URL of the image.
    /// </summary>
    public string Url
    {
        get => Value.Url;
        private set => Value = (value, Value.PrettyName, Value.SizeInBytes);
    }

    /// <summary>
    /// Gets or sets the pretty name of the image.
    /// </summary>
    public string PrettyName
    {
        get => Value.PrettyName;
        private set => Value = (Value.Url, value, Value.SizeInBytes);
    }

    /// <summary>
    /// Gets or sets the size of the image in bytes.
    /// </summary>
    public int SizeInBytes
    {
        get => Value.SizeInBytes;
        private set => Value = (Value.Url, Value.PrettyName, value);
    }

    /// <summary>
    /// Creates an instance of the <see cref="Image"/> class with default options from the specified URL, pretty name, and size.
    /// </summary>
    /// <param name="url">The URL of the image.</param>
    /// <param name="prettyName">The pretty name of the image.</param>
    /// <param name="sizeInBytes">The size of the image in bytes.</param>
    /// <returns>An instance of the <see cref="Image"/> class.</returns>
    public static Image From(string url, string prettyName, int sizeInBytes)
        => From((url, prettyName, sizeInBytes));


    /// <summary>
    /// Creates an instance of the <see cref="Image"/> class with specified options from the specified URL, pretty name, and size.
    /// </summary>
    /// <param name="url">The URL of the image.</param>
    /// <param name="prettyName">The pretty name of the image.</param>
    /// <param name="sizeInBytes">The size of the image in bytes.</param>
    /// <param name="options">The <see cref="ImageTypeOptions"/> containing constraints for the value object.</param>
    /// <returns>An instance of the <see cref="Image"/> class.</returns>
    public static Image From(string url, string prettyName, int sizeInBytes, ImageTypeOptions options)
    {
        var newObject = new Image
        {
            Value = (url, prettyName, sizeInBytes),
            _imageTypeOptions = options
        };
        
        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Retrieves the image format type extension from the URL.
    /// </summary>
    /// <returns>String representing the image format type extension.</returns>
    public string GetImageExtension() => Path.GetExtension(Url); 

    /// <summary>
    /// Retrieves the equality components for the image value object.
    /// </summary>
    /// <returns>An enumerable collection of key-value pairs representing the equality components.</returns>
    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Url), Url);
        yield return new KeyValuePair<string, object>(nameof(PrettyName), PrettyName);
        yield return new KeyValuePair<string, object>(nameof(SizeInBytes), SizeInBytes);
    }

    /// <summary>
    /// Returns a string representation of the image.
    /// </summary>
    /// <returns>A string representation of the image.</returns>
    public override string ToString()
    {
        return $"{PrettyName}: {Url}";
    }

    /// <summary>
    /// Validates the <see cref="Image"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Image"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (string.IsNullOrWhiteSpace(Value.Url))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an empty Url."));
        }
        else if (!Uri.TryCreate(Value.Url, UriKind.Absolute, out _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an invalid Url '{Value.Url}'."));
        }
        else if (!ImageFormatType.GetSupportedFormatTypeExtension(_imageTypeOptions.ImageFormatTypes).Contains(Path.GetExtension(Value.Url).ToLower()))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an image having an unsupported extension '{Value.Url}'."));
        }

        if (string.IsNullOrWhiteSpace(Value.PrettyName))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an empty PrettyName."));
        }

        if (Value.SizeInBytes <= 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with a Size of {Value.SizeInBytes}."));
        }

        return result;
    }
}
