using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;

namespace Nox.Types;

/// <summary>
/// The json element comparer.
/// The source is taken and modified from https://stackoverflow.com/questions/60580743/what-is-equivalent-in-jtoken-deepequals-in-system-text-json
/// </summary>

public class JsonElementComparer : IEqualityComparer<JsonElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonElementComparer"/> class.
    /// </summary>
    public JsonElementComparer() : this(-1, false) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonElementComparer"/> class.
    /// </summary>
    /// <param name="maxHashDepth">The max hash depth.</param>
    public JsonElementComparer(int maxHashDepth, bool ignoreArrayOrder = false)
    {
        this.MaxHashDepth = maxHashDepth;
        this.IgnoreArrayOrder = ignoreArrayOrder;
    }

    /// <summary>
    /// Gets the max hash depth.
    /// </summary>
    internal int MaxHashDepth { get; } = -1;

    /// <summary>
    /// Gets a value indicating whether to ignore array order.
    /// </summary>
    internal bool IgnoreArrayOrder { get; } =false;

    #region IEqualityComparer<JsonElement> Members

    /// <summary>
    /// Compares and returns if the two jsonelements provided are equivalent.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A bool indicating equivalence.</returns>
    public bool Equals(JsonElement x, JsonElement y)
    {
        if (x.ValueKind != y.ValueKind)
            return false; 
        
        switch (x.ValueKind)
        {
            case JsonValueKind.Null:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Undefined:
                return true;

            // Compare the raw values of numbers, and the text of strings.
            // Note this means that 0.0 will differ from 0.00 -- which may be correct as deserializing either to `decimal` will result in subtly different results.
            // Newtonsoft's JValue.Compare(JTokenType valueType, object? objA, object? objB) has logic for detecting "equivalent" values, 
            // you may want to examine it to see if anything there is required here.
            // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Linq/JValue.cs#L246
            case JsonValueKind.Number:
                return x.GetDecimal() == y.GetDecimal();

            case JsonValueKind.String:
                return x.GetString() == y.GetString(); // Do not use GetRawText() here, it does not automatically resolve JSON escape sequences to their corresponding characters.

            case JsonValueKind.Array:
                if(IgnoreArrayOrder)
                {
                    var xListUnsorted = x.EnumerateArray().ToList();
                    var yListUnsorted = y.EnumerateArray().ToList();
                    if (xListUnsorted.Count != yListUnsorted.Count)
                        return false;
                    var xSorted = xListUnsorted.OrderBy(p => p.GetRawText(), StringComparer.Ordinal);
                    var ySorted = yListUnsorted.OrderBy(p => p.GetRawText(), StringComparer.Ordinal);
                    foreach (var (px, py) in xSorted.Zip(ySorted, (x, y) => (x, y)))
                    {
                        if (!Equals(px, py))
                            return false;
                    }
                    return true;
                }
                else
                {
                    return x.EnumerateArray().SequenceEqual(y.EnumerateArray(), this);
                }

            case JsonValueKind.Object:
                {
                    // Surprisingly, JsonDocument fully supports duplicate property names.
                    // I.e. it's perfectly happy to parse {"Value":"a", "Value" : "b"} and will store both
                    // key/value pairs inside the document!
                    // A close reading of https://www.rfc-editor.org/rfc/rfc8259#section-4 seems to indicate that
                    // such objects are allowed but not recommended, and when they arise, interpretation of 
                    // identically-named properties is order-dependent.  
                    // So stably sorting by name then comparing values seems the way to go.
                    var xPropertiesUnsorted = x.EnumerateObject().ToList();
                    var yPropertiesUnsorted = y.EnumerateObject().ToList();
                    if (xPropertiesUnsorted.Count != yPropertiesUnsorted.Count)
                        return false;
                    var xProperties = xPropertiesUnsorted.OrderBy(p => p.Name, StringComparer.Ordinal);
                    var yProperties = yPropertiesUnsorted.OrderBy(p => p.Name, StringComparer.Ordinal);
                    foreach (var (px, py) in xProperties.Zip(yProperties, (x, y) => (x, y)))
                    {
                        if (px.Name != py.Name)
                            return false;
                        if (!Equals(px.Value, py.Value))
                            return false;
                    }
                    return true;
                }

            default:
                throw new JsonException(string.Format("Unknown JsonValueKind {0}", x.ValueKind));
        }
    }

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>An int.</returns>
    public int GetHashCode(JsonElement obj)
    {
        var hash = new List<object>(); // New in .Net core: https://learn.microsoft.com/en-us/dotnet/api/system.hashcode
        ComputeHashCode(obj, ref hash, 0);
        return hash.GetHashCode();
    }

    /// <summary>
    /// Computes the hash code.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="hash">The hash.</param>
    /// <param name="depth">The depth.</param>
    private void ComputeHashCode(JsonElement obj, ref List<object> hash, int depth)
    {
        hash.Add(obj.ValueKind);

        switch (obj.ValueKind)
        {
            case JsonValueKind.Null:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Undefined:
                break;

            case JsonValueKind.Number:
                hash.Add(obj.GetRawText());
                break;

            case JsonValueKind.String:
                hash.Add(obj.GetString()!);
                break;

            case JsonValueKind.Array:
                if (depth != MaxHashDepth)
                    foreach (var item in obj.EnumerateArray())
                        ComputeHashCode(item, ref hash, depth + 1);
                else
                    hash.Add(obj.GetArrayLength());
                break;

            case JsonValueKind.Object:
                foreach (var property in obj.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal))
                {
                    hash.Add(property.Name);
                    if (depth != MaxHashDepth)
                        ComputeHashCode(property.Value, ref hash, depth + 1);
                }
                break;

            default:
                throw new JsonException(string.Format("Unknown JsonValueKind {0}", obj.ValueKind));
        }
    }

    #endregion
}
