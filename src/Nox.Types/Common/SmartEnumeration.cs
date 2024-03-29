﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nox.Types.Common;

/// <summary>
/// Enumeration base class.
/// </summary>
public abstract class SmartEnumeration : IComparable
{
    /// <summary>
    /// Gets the ID of the enumeration.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    public string Name { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="SmartEnumeration"/> class with the specified ID, name, and value.
    /// </summary>
    /// <param name="id">The ID of the enumeration.</param>
    /// <param name="name">The name of the enumeration.</param>
    protected SmartEnumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Compares the current enumeration with another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>A value indicating the relative order of the objects being compared.</returns>
    public int CompareTo(object? obj)
        => Id.CompareTo(((SmartEnumeration)obj!).Id);

    /// <summary>
    /// Determines whether the current enumeration is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not SmartEnumeration otherValue)
        {
            return false;
        }

        var isEqualType = GetType() == obj.GetType();
        var isEqualId = Id.Equals(otherValue.Id);

        return isEqualType && isEqualId;
    }

    /// <summary>
    /// Returns the hash code for the current enumeration.
    /// </summary>
    /// <returns>A hash code for the current enumeration.</returns>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Returns a string representation of the current enumeration.
    /// </summary>
    /// <returns>A string representation of the current enumeration.</returns>
    public override string ToString() => Name;

    /// <summary>
    /// Determines whether two enumerations are equal.
    /// </summary>
    /// <param name="a">The first enumeration to compare.</param>
    /// <param name="b">The second enumeration to compare.</param>
    /// <returns>True if the enumerations are equal; otherwise, false.</returns>
    public static bool operator ==(SmartEnumeration? a, SmartEnumeration? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Determines whether two enumerations are not equal.
    /// </summary>
    /// <param name="a">The first enumeration to compare.</param>
    /// <param name="b">The second enumeration to compare.</param>
    /// <returns>True if the enumerations are not equal; otherwise, false.</returns>
    public static bool operator !=(SmartEnumeration? a, SmartEnumeration? b)
    {
        return !(a == b);
    }

    /// <summary>
    /// Retrieves all instances of the specified enumeration type.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <returns>An IEnumerable of the specified enumeration type containing all instances.</returns>
    public static IEnumerable<T> GetAll<T>() where T : SmartEnumeration
        => typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    /// <summary>
    /// Tries to retrieve an instance of the specified enumeration type by its name.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="name">The name of the enumeration value.</param>
    /// <param name="enumeration">The retrieved enumeration value.</param>
    /// <returns>true if the enumeration is defined.</returns>
    public static bool TryParseFromName<T>(string name, out T enumeration) where T : SmartEnumeration
    {
        enumeration = GetAll<T>().FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase))!;
        return enumeration is not null;
    }

    /// <summary>
    /// Retrieves an instance of the specified enumeration type by its name.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="name">The name of the enumeration value.</param>
    /// <returns>An instance of the specified enumeration type with the given name.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the name does not match any enumeration value.</exception>
    public static T ParseFromName<T>(string name) where T : SmartEnumeration
    {
        if (TryParseFromName<T>(name, out T enumeration))
            return enumeration;

        throw new InvalidOperationException($"'{name}' is not a valid name for {typeof(T)}");
    }

    /// <summary>
    /// Tries to retrieve an instance of the specified enumeration type by its id.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="id">The id of the enumeration value.</param>
    /// <param name="enumeration">The retrieved enumeration value.</param>
    /// <returns>true if the enumeration is defined.</returns>
    public static bool TryParseFromId<T>(int id, out T enumeration) where T : SmartEnumeration
    {
        enumeration = GetAll<T>().FirstOrDefault(e => e.Id.Equals(id))!;
        return enumeration is not null;
    }

    /// <summary>
    /// Retrieves an instance of the specified enumeration type by its ID.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="id">The ID of the enumeration value.</param>
    /// <returns>An instance of the specified enumeration type with the given ID.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the ID does not match any enumeration value.</exception>
    public static T ParseFromId<T>(int id) where T : SmartEnumeration
    {
        if (TryParseFromId(id, out T enumeration))
            return enumeration;

        throw new InvalidOperationException($"'{id}' is not a valid ID for {typeof(T)}");
    }


}