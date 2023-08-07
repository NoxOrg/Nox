using System.Runtime.CompilerServices;
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
public sealed class Nuid : ValueObject<uint, Nuid>, IComparable, IComparable<Nuid>, IEquatable<Nuid>
{
    public static Nuid From(string textToEncode)
    {
        return From(textToEncode, new NuidTypeOptions { });
    }

    public static Nuid From(string textToEncode, NuidTypeOptions options)
    {
        var unsignedValue = ToUInt32(textToEncode);
        var nuid = From(unsignedValue);

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

    public Guid ToGuid()
    {
        byte[] bytes = new byte[16];
        BitConverter
            .GetBytes(Value)
            .Reverse()
            .ToArray()
            .CopyTo(bytes, 12);

        return new Guid(bytes);
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        if (obj is not Nuid nuidObj)
        {
            throw new ArgumentException("Object must be of type NUID.", nameof(obj));
        }
        return CompareTo(nuidObj);
    }

    public int CompareTo(Nuid? other)
    {
        if (other is null) return 1;

        return Value.CompareTo(other.Value);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Nuid other && Equals(other);
    }

    public bool Equals(Nuid? other)
    {
        return Value == other?.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
      
    public static bool operator ==(Nuid a, Nuid b) => EqualsCore(a, b);

    public static bool operator !=(Nuid a, Nuid b) => !EqualsCore(a, b);

    public static bool operator <(Nuid a, Nuid b) => a.CompareTo(b) < 0;

    public static bool operator >(Nuid a, Nuid b) => a.CompareTo(b) > 0;

    public static bool operator <=(Nuid a, Nuid b) => a.CompareTo(b) <= 0;

    public static bool operator >=(Nuid a, Nuid b) => a.CompareTo(b) >= 0;

    private static bool EqualsCore(in Nuid left, in Nuid right)
    {
        if (left is null || right is null)
        {
            return false;
        }

        uint leftVal = left.Value;
        uint rightVal = right.Value;
        ref uint rA = ref Unsafe.AsRef(in leftVal);
        ref uint rB = ref Unsafe.AsRef(in rightVal);

        // Compare each element
        return rA == rB;
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
}