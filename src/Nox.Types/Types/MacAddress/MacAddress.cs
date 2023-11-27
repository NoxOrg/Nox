using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="MacAddress"/> type and value object.
/// </summary>
public sealed class MacAddress : ValueObject<string, MacAddress>
{
    private const int MacAddressLengthInBytes = 6;

    /// <summary>
    /// Creates a new instance of <see cref="MacAddress"/> object.
    /// </summary>
    /// <param name="macAddressText">The string value to create the <see cref="MacAddress"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public new static MacAddress From(string macAddressText)
    {
        TryParse(macAddressText, out string macAddressValue);

        var newObject = new MacAddress
        {
            Value = macAddressValue
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MacAddress"/> object.
    /// </summary>
    /// <param name="macAddressHexNumber">The ulong value to create the <see cref="MacAddress"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static MacAddress From(ulong macAddressHexNumber)
    {
        var macAddressValue = PadToMacAddressLength(macAddressHexNumber.ToString("X2", CultureInfo.InvariantCulture));
        return From(macAddressValue);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MacAddress"/> object.
    /// </summary>
    /// <param name="macAddressBytes">The byte array value to create the <see cref="MacAddress"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static MacAddress From(byte[] macAddressBytes)
    {
        var macAddressValue = ConvertToHexString(macAddressBytes);
        return From(macAddressValue);
    }

    /// <summary>
    /// Converts the instance to string and formats it in <see cref="MacAddressFormat.ByteGroupWithColon"/> format
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public new string ToString()
        => ToString(MacAddressFormat.ByteGroupWithColon);

    /// <summary>
    /// Converts the instance to string in specified <see cref="MacAddressFormat"/> format.
    /// </summary>
    /// <param name="format">The format.</param>
    public string ToString(MacAddressFormat format)
        => format switch
        {
            MacAddressFormat.NoSeparator => Value.ToString(CultureInfo.InvariantCulture),
            MacAddressFormat.ByteGroupWithColon => string.Join(":", SplitAddress(2)),
            MacAddressFormat.ByteGroupWithDash => string.Join("-", SplitAddress(2)),
            MacAddressFormat.DoubleByteGroupWithColon => string.Join(":", SplitAddress(4)),
            MacAddressFormat.DoubleByteGroupWithDot => string.Join(".", SplitAddress(4)),
            _ => throw new NotImplementedException()
        };

    /// <summary>
    /// Validates a <see cref="MacAddress"/> object.
    /// </summary>
    /// <returns>true if the <see cref="MacAddress"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!TryParse(Value, out var _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox MAC Address type as value {Value} is not a valid MAC Address."));
        }

        return result;
    }

    private static bool TryParse(string inputValue, out string macAddressValue)
    {
        macAddressValue = inputValue;
        try
        {
            var macAddress = PhysicalAddress.Parse(inputValue);
            var bytes = macAddress.GetAddressBytes();
            if (bytes.Length != MacAddressLengthInBytes)
            {
                return false;
            }

            macAddressValue = FormatAsMacAddressHexString(bytes);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private IEnumerable<string> SplitAddress(int chunkSize)
        => Enumerable.Range(0, Value.Length / chunkSize).Select(i => Value.Substring(i * chunkSize, chunkSize));

    /// <summary>
    /// Converts to byte array to string of hexadecimal digits.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    private static string ConvertToHexString(byte[] input)
        => string.Join(string.Empty, input.Select(x => x.ToString("X2", CultureInfo.InvariantCulture)).ToArray());

    /// <summary>
    /// Pads the string to the length of to mac address.
    /// </summary>
    /// <param name="input">The input.</param>
    private static string PadToMacAddressLength(string input)
        => input.PadLeft(2 * MacAddressLengthInBytes, '0');

    /// <summary>
    /// Formats byte array as upper case hexadecimal digits and pads it to 12 characters
    /// </summary>
    /// <param name="input">The input.</param>
    private static string FormatAsMacAddressHexString(byte[] input)
        => PadToMacAddressLength(ConvertToHexString(input)).ToUpperInvariant();
}
