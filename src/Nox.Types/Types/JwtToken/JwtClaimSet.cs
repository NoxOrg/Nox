using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Nox.Types;

internal sealed class JwtClaimSet : IEnumerable<Claim>
{
    private readonly List<Claim> _claims;

    public JwtClaimSet(string encodedPayload)
    {
        _claims = GetClaimsFromEncodedPayload(encodedPayload);
    }

    private static List<Claim> GetClaimsFromEncodedPayload(string encodedPayload)
    {
        var decodedPayload = DecodePayload(encodedPayload);
        return GetClaimsFromDecodedPayload(decodedPayload);
    }

    private static string DecodePayload(string encodedPayload)
    {
        var base64String = ResolveAsValidBase64String(encodedPayload);
        return DecodeBase64String(base64String);
    }

    private static string ResolveAsValidBase64String(string encodedPayload)
        => encodedPayload.Length % 4 == 0 ? encodedPayload : encodedPayload + new string('=', encodedPayload.Length % 4);

    private static string DecodeBase64String(string base64String)
    {
        var bytes = Convert.FromBase64String(base64String);
        return Encoding.UTF8.GetString(bytes);
    }

    private static List<Claim> GetClaimsFromDecodedPayload(string decodedPayload)
    {
        var claims = new List<Claim>();
        var payload = JsonDocument.Parse(decodedPayload).RootElement;

        foreach (var property in payload.EnumerateObject())
        {
            if (property.Value.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in property.Value.EnumerateArray())
                {
                    var claim = CreateClaim(property.Name, element);
                    if (claim is not null)
                        claims.Add(claim);
                }
            }
            else
            {
                var claim = CreateClaim(property.Name, property.Value);
                if (claim is not null)
                    claims.Add(claim);
            }
        }

        return claims;
    }

    private static Claim CreateClaim(string key, object value)
    {
        var (underlyingValue, underlyingValueType) = ResolveUnderlyingValueAndType((JsonElement)value);
        return new Claim(key, underlyingValue, underlyingValueType);
    }

    private static (string Value, string ValueType) ResolveUnderlyingValueAndType(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Null => (string.Empty, JsonClaimValueTypes.JsonNull),
            JsonValueKind.String => ResolveStringType(element),
            JsonValueKind.Number => ResolveNumberType(element),
            JsonValueKind.True => ResolveBooleanType(element),
            JsonValueKind.False => ResolveBooleanType(element),
            JsonValueKind.Object => (element.ToString(), JsonClaimValueTypes.Json),
            JsonValueKind.Array => (element.ToString(), JsonClaimValueTypes.JsonArray),
            _ => (element.ToString(), ClaimValueTypes.String),
        };
    }

    private static (string Value, string ValueType) ResolveStringType(JsonElement element)
    {
        if (element.TryGetDateTime(out DateTime dateTime))
            return (dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), ClaimValueTypes.DateTime);

        return (element.ToString(), ClaimValueTypes.String);
    }

    private static (string Value, string ValueType) ResolveNumberType(JsonElement element)
    {
        if (element.TryGetInt16(out short _))
            return (element.ToString(), ClaimValueTypes.Integer);
        else if (element.TryGetInt32(out int _))
            return (element.ToString(), ClaimValueTypes.Integer);
        else if (element.TryGetInt64(out long _))
            return (element.ToString(), ClaimValueTypes.Integer64);
        else if (element.TryGetDecimal(out decimal _))
            return (element.ToString(), ClaimValueTypes.Double);
        else if (element.TryGetDouble(out double _))
            return (element.ToString(), ClaimValueTypes.Double);
        else if (element.TryGetUInt32(out uint _))
            return (element.ToString(), ClaimValueTypes.UInteger32);
        else if (element.TryGetUInt64(out ulong _))
            return (element.ToString(), ClaimValueTypes.UInteger64);

        return (element.ToString(), ClaimValueTypes.Double);
    }

    private static (string, string Boolean) ResolveBooleanType(JsonElement element)
            => (element.GetBoolean().ToString().ToLowerInvariant(), ClaimValueTypes.Boolean);

    public IEnumerator<Claim> GetEnumerator()
        => _claims.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}