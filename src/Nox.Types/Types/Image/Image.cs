using System;
using System.Collections.Generic;
using System.IO;

namespace Nox.Types;


/// <summary>
/// Represents an image value object that encapsulates image-related information.
/// </summary>
public sealed class Image : ValueObject<(string Url, string PrettyName, int Size), Image>
{
    /// <summary>
    /// Gets or sets the URL of the image.
    /// </summary>
    public string Url
    {
        get => Value.Url;
        private set => Value = (value, Value.PrettyName, Value.Size);
    }

    /// <summary>
    /// Gets or sets the pretty name of the image.
    /// </summary>
    public string PrettyName
    {
        get => Value.PrettyName;
        private set => Value = (Value.Url, value, Value.Size);
    }

    /// <summary>
    /// Gets or sets the size of the image in bytes.
    /// </summary>
    public int Size
    {
        get => Value.Size;
        private set => Value = (Value.Url, Value.PrettyName, value);
    }

    /// <summary>
    /// Creates an instance of the <see cref="Image"/> class from the specified URL, pretty name, and size.
    /// </summary>
    /// <param name="url">The URL of the image.</param>
    /// <param name="prettyName">The pretty name of the image.</param>
    /// <param name="size">The size of the image in bytes.</param>
    /// <returns>An instance of the <see cref="Image"/> class.</returns>
    public static Image From(string url, string prettyName, int size)
        => From((url, prettyName, size));

    /// <summary>
    /// Retrieves the equality components for the image value object.
    /// </summary>
    /// <returns>An enumerable collection of key-value pairs representing the equality components.</returns>
    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Url), Url);
        yield return new KeyValuePair<string, object>(nameof(PrettyName), PrettyName);
        yield return new KeyValuePair<string, object>(nameof(Size), Size);
    }

    /// <summary>
    /// Returns a string representation of the image.
    /// </summary>
    /// <returns>A string representation of the image.</returns>
    public override string ToString()
    {
        return PrettyName;
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
        else if (!ImageType.AllowedExtensions.Contains(Path.GetExtension(Value.Url).ToLower()))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an image having an invalid extension '{Value.Url}'."));
        }

        if (string.IsNullOrWhiteSpace(Value.PrettyName))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with an empty PrettyName."));
        }

        if (Value.Size <= 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Image type with a Size of {Value.Size}."));
        }

        return result;
    }
    
}
