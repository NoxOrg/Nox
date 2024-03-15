using FluentAssertions;
using Nox.Extensions;

namespace Nox.Lib.Tests.Extensions;

public class HttpClientExtensionsTests
{
    [Fact]    
    public void WhenEtagIsAdded_ShouldBeOnTheHeader()
    {
        var httpClient = new HttpClient();
        var eTag = Guid.NewGuid();
        httpClient.AddeTag(eTag);

        httpClient.DefaultRequestHeaders.IfNoneMatch.Should().NotBeEmpty();
        httpClient.DefaultRequestHeaders.IfNoneMatch.First().Tag.Should().Be($"\"{eTag}\"");
    }
}
