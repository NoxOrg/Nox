using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Nox.Types;

public class JwtToken : ValueObject<string, JwtToken>
{
    private string _encodedPayload = null!;
    private IEnumerable<Claim> _claims = null!;

    /// <summary>
    /// Validates a <see cref="JwtToken"/> object.
    /// </summary>
    /// <returns>true if the <see cref="JwtToken"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (string.IsNullOrEmpty(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), "Could not create a Nox JWT Token type as the value cannot be null or empty."));
        }
        else if (!HasValidJWTFormat(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox JWT Token type as value {Value} does not have a valid JWT format."));
        }

        return result;
    }

    private bool HasValidJWTFormat(string value)
    {
        var jwtParts = value.Split('.');

        if (jwtParts.Length == JwtConstants.JwsPartCount)
        {
            _encodedPayload = jwtParts[JwtConstants.JwsPayloadPartIndex];
            return JwtConstants.JwsFormatRegex.IsMatch(value);
        }

        if (jwtParts.Length == JwtConstants.JwePartCount)
            return JwtConstants.JweFormatRegex.IsMatch(value);

        return false;
    }

    public IEnumerable<Claim> GetClaims()
    {
        if (string.IsNullOrEmpty(_encodedPayload))
            return Array.Empty<Claim>();

        return _claims ??= new JwtClaimSet(_encodedPayload);
    }
}