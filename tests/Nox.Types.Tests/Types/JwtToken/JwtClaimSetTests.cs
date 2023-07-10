using FluentAssertions;
using System.Security.Claims;

namespace Nox.Types.Tests.Types;

public class JwtClaimSetTests
{
    [Fact]
    public void JwtClaimSet_Constructor_ReturnsValue()
    {
        var encodedPayload = "eyJzdWIiOiIxMjM0NTY3ODkxIiwibmFtZSI6IkpvaG4gRG9lIiwicm9sZXMiOlt7Im5hbWUiOiJPd25lciIsImFzQXQiOiIyMDIzLTA3LTA1VDAwOjAwOjAwIn0seyJuYW1lIjoiQ29udHJpYnV0b3IiLCJhc0F0IjoiMjAyMy0wNy0wMVQwMDowMDowMCJ9XSwiaXNPd25lciI6dHJ1ZSwiaXNHdWVzdCI6ZmFsc2UsInRpbWVzdGFtcCI6IjIwMjMtMDctMTBUMTI6MDA6MDAiLCJpYXQiOjE1MTYyMzkwMjJ9";

        var claims = new JwtClaimSet(encodedPayload);

        claims.Should().BeEquivalentTo(new[]
        {
            new Claim("sub", "1234567891", "http://www.w3.org/2001/XMLSchema#string"),
            new Claim("name", "John Doe", "http://www.w3.org/2001/XMLSchema#string"),
            new Claim("roles", "{\"name\":\"Owner\",\"asAt\":\"2023-07-05T00:00:00\"}", "JSON"),
            new Claim("roles", "{\"name\":\"Contributor\",\"asAt\":\"2023-07-01T00:00:00\"}", "JSON"),
            new Claim("isOwner", "true", "http://www.w3.org/2001/XMLSchema#boolean"),
            new Claim("isGuest", "false", "http://www.w3.org/2001/XMLSchema#boolean"),
            new Claim("timestamp", "2023-07-10T10:00:00.0000000Z", "http://www.w3.org/2001/XMLSchema#dateTime"),
            new Claim("iat", "1516239022", "http://www.w3.org/2001/XMLSchema#integer"),
        });
    }
}