using System;
using System.IO;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="File"/> type and value object.
/// </summary>
public sealed class File : ValueObject<(string Url, string PrettyName, uint SizeInBytes), File>
{
    public const int MaxUrlLength = 2083;
    public const int MaxPrettyNameLength = 511;

    private FileTypeOptions _fileTypeOptions = new();

    /// <summary>
    /// Gets the URL of the file.
    /// </summary>
    public string Url
    {
        get => Value.Url;
        private set => Value = (Url: value, PrettyName: Value.PrettyName, SizeInBytes: Value.SizeInBytes);
    }

    /// <summary>
    /// Gets the pretty name of the file.
    /// </summary>
    public string PrettyName
    {
        get => Value.PrettyName;
        private set => Value = (Url: Value.Url, PrettyName: value, SizeInBytes: Value.SizeInBytes);
    }

    /// <summary>
    /// Gets the size of the file in bytes.
    /// </summary>
    public uint SizeInBytes
    {
        get => Value.SizeInBytes;
        private set => Value = (Url: Value.Url, PrettyName: Value.PrettyName, SizeInBytes: value);
    }

    /// <summary>
    /// Creates an instance of the <see cref="File"/> class with specified options from the specified URL, pretty name and size in bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    /// <exception cref="Nox.Types.TypeValidationException"></exception>
    public static File From((string Url, string PrettyName, uint SizeInBytes) value, FileTypeOptions options)
    {
        var newObject = new File
        {
            Value = value,
            _fileTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates an instance of the <see cref="File"/> class with default options from the specified URL, pretty name and size in bytes.
    /// </summary>
    /// <param name="url">The URL of the file.</param>
    /// <param name="prettyName">The pretty name of the file.</param>
    /// <param name="sizeInBytes">The size of the file in bytes.</param>
    /// <returns>An instance of the <see cref="File"/> class.</returns>
    public static File From(string url, string prettyName, uint sizeInBytes)
        => From((url, prettyName, sizeInBytes));

    /// <summary>
    /// Creates an instance of the <see cref="File"/> class with specified options from the specified URL, pretty name and size in bytes.
    /// </summary>
    /// <param name="url">The URL of the file.</param>
    /// <param name="prettyName">The pretty name of the file.</param>
    /// <param name="sizeInBytes">The size of the file in bytes.</param>
    /// <returns>An instance of the <see cref="File"/> class.</returns>
    public static File From(string url, string prettyName, uint sizeInBytes, FileTypeOptions options)
        => From((url, prettyName, sizeInBytes), options);

    /// <summary>
    /// Retrieves the file format type extension from the URL.
    /// </summary>
    /// <returns>String representing the file format type extension.</returns>
    public string GetFileExtension() => Path.GetExtension(new System.Uri(Url).LocalPath).ToLowerInvariant();

    /// <summary>
    /// Returns a string representation of the file value object.
    /// </summary>
    /// <returns>A string representation of the file value object.</returns>
    public override string ToString()
        => $"{PrettyName}: {Url}";

    /// <summary>
    /// Validates the <see cref="File"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="File"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (string.IsNullOrWhiteSpace(Value.Url))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Url), "Could not create a Nox File type with an empty Url."));
        }
        else if (Value.Url.Length > MaxUrlLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Url), $"Could not create a Nox File type with an Url length greater than max allowed length of {MaxUrlLength}."));
        }
        else if (!System.Uri.TryCreate(Value.Url, UriKind.Absolute, out _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Url), $"Could not create a Nox File type with an invalid Url '{Value.Url}'."));
        }
        else if (!_fileTypeOptions.GetSupportedExtensions().Contains(GetFileExtension()))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Url), $"Could not create a Nox File type with a file having an unsupported extension '{GetFileExtension()}'."));
        }

        if (string.IsNullOrWhiteSpace(Value.PrettyName))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PrettyName), "Could not create a Nox File type with an empty PrettyName."));
        }
        else if (Value.PrettyName.Length > MaxPrettyNameLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PrettyName), $"Could not create a Nox File type with a PrettyName length greater than max allowed length of {MaxPrettyNameLength}."));
        }

        return result;
    }
}
