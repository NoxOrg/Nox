using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Boolean"/> type and value object.
/// </summary>
public sealed class Boolean : ValueObject<bool, Boolean>
{
    public Boolean()
    {
    }

    private Boolean(bool value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a <see cref="System.Boolean"/>.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public new static Boolean From(bool value)
    {
        return new Boolean(value);
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a byte.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(byte value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a short.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(short value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a int.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(int value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a long.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(long value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a float.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(float value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a double.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(double value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a decimal.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(decimal value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }

    /// <summary>
    /// Creates a <see cref="Boolean"/> object from a string.
    /// </summary>
    /// <param name="value">Value to be parsed.</param>
    /// <returns>New <see cref="Boolean"/> object.</returns>
    public static Boolean From(string value)
    {
        return new Boolean(Convert.ToBoolean(value));
    }
}