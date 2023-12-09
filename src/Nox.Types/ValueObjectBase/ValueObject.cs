using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;
/// <summary>
/// Base abstract class for creating value objects in the Nox framework.
/// A value object is an immutable type that represents an attribute or component of an entity.
/// Value objects have no identity and are compared by their value rather than by reference.
/// </summary>
/// <typeparam name="T">The underlying type of the value object.</typeparam>
/// <typeparam name="TValueObject">The specific type of the value object.</typeparam>
public abstract class ValueObject<T, TValueObject> : INoxType
    where TValueObject : ValueObject<T, TValueObject>, new()
{
    /// <summary>
    /// Gets or sets the value of the value object.
    /// </summary>
    public virtual T Value { get; protected set; } = default!;

  
    
    protected ValueObject()
    { }

    /// <summary>
    /// Creates a new instance of the value object from a database value. It does not validate the value and it is for internal use only.
    /// </summary>
    /// <param name="value">The value from the database.</param>
    /// <returns>The newly created value object instance.</returns>
    public static TValueObject FromDatabase(T value)
    {
        return new TValueObject { Value = value };
    }

    /// <summary>
    /// Creates a new instance of the value object from a given value.
    /// </summary>
    /// <param name="value">The value to be used for the value object.</param>
    /// <returns>The newly created value object instance.</returns>
    /// <exception cref="NoxTypeValidationException">Thrown when the validation of the value object fails.</exception>
    public static TValueObject From(T value)
    {
        var newObject = new TValueObject
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
    /// <summary>
    /// Tries to create a new instance of the value object from a given value.
    /// </summary>
    /// <param name="value">The value to be used for the value object.</param>
    /// <param name="result">The newly created value object instance.</param>
    /// <returns>True if the value object was created successfully, false otherwise.</returns>
    public static ValidationResult TryFrom(T value, out TValueObject? result)
    {
        var newObject = new TValueObject
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            result = null;
        }
        else
        {
            result = newObject;
        }
        
        return validationResult;
    }

    /// <summary>
    /// Validates the value object.
    /// </summary>
    /// <returns>A validation result indicating whether the value object is valid or not.</returns>
    internal virtual ValidationResult Validate()
    {
        return new ValidationResult() { };
    }

    protected static bool EqualOperator(ValueObject<T, TValueObject>? left, ValueObject<T, TValueObject>? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return left is null || left.Equals(right!);
    }

    protected static bool NotEqualOperator(ValueObject<T, TValueObject> left, ValueObject<T, TValueObject> right)
    {
        return !(EqualOperator(left, right));
    }

    public static bool operator ==(ValueObject<T, TValueObject>? a, ValueObject<T, TValueObject>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T, TValueObject>? a, ValueObject<T, TValueObject>? b)
    {
        return !(a == b);
    }

    protected virtual IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), Value!);
    }

    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(this, obj))
        {
            return true;
        }
            
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<T, TValueObject>)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.Value != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject<T, TValueObject>? GetCopy()
    {
        return this.MemberwiseClone() as ValueObject<T, TValueObject>;
    }

    /// <remarks>
    ///  Nox does not follow the usual convention for ToString(),
    ///  The ToString() should return the same result independently of the current culture, for example for DateTime, Currency, etc... dependent types.
    ///  The reasoning behind this is to ensure a fully predictable result that facilitates ETL process's and interopability with other systems.
    ///
    ///  The same is expected for the ToString(string format) overload.
    ///
    ///  If you need a culture dependent representation create an overload with a <seealso cref="IFormatProvider"/> parameter, example ToString(IFormatProvider formatProvider)
    /// </remarks>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Join(",", this.GetEqualityComponents().Select(o => o.Value?.ToString() ?? string.Empty).ToArray());
    }

    /// <summary>
    /// Gets the underlying type of the value object.
    /// </summary>
    /// <returns>The type of the underlying value.</returns>
    public virtual Type GetUnderlyingType() => typeof(T);
}