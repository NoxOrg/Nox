using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class JwtTokenConverter : ValueConverter<JwtToken, string>
{
    public JwtTokenConverter() : base(jwtToken => jwtToken.Value, jwtTokenValue => JwtToken.From(jwtTokenValue)) { }
}
