using System.Text;
using System;
using Nox.Types.Common;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.IO.Hashing;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Nuid"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Nuid : ValueObject<uint, Nuid>, IEquatable<Nuid>
{
    private NuidTypeOptions _options = new NuidTypeOptions();

    public static Nuid From(string textToEncode)
    {
        return From(textToEncode, new NuidTypeOptions());
    }

    public static Nuid From(string textToEncode, NuidTypeOptions options)
    {
        var unsignedValue = ToUInt32(textToEncode);
        return From(unsignedValue, options);
    }

    public static Nuid From(uint value, NuidTypeOptions options)
    {
        var nuid = From(value);
        nuid._options = options;
        return nuid;
    }

    public string ToHex()
    {
        return string.Format("{0:X}", Value).PadLeft(8, '0');
    }

    public string ToBase36()
    {
        return Base36Converter.ToBase36(Value);
    }

    public System.Guid ToGuid()
    {
        byte[] bytes = new byte[16];
        BitConverter
            .GetBytes(Value)
            .Reverse()
            .ToArray()
            .CopyTo(bytes, 12);

        return new System.Guid(bytes);
    }

    private static uint ToUInt32(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = XxHash64
            .Hash(bytes)
            .Reverse()
            .ToArray();

        var nuid = BitConverter.ToUInt32(hash, 0);

        return (nuid + uint.MaxValue + 1);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return  obj is Nuid other && Equals(other);
    }

    public bool Equals(Nuid? other)
    {
        return Value == other?.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}