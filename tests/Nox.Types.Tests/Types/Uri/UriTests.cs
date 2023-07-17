using System;
using System.Security.Policy;
using FluentAssertions;
using Xunit.Abstractions;

namespace Nox.Types.Tests.Types;

public class UriTests
{

    private const string Sample_Uri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
    private readonly ITestOutputHelper _testOutputHelper;


    public UriTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void NoxUri_ShouldBe_SameAs_SystemUri()
    {
        var expected = new System.Uri(Sample_Uri);
        var actual = Uri.From(expected);

        actual.Value.Should().Be(expected);
    }


    [Fact]
    public void NoxUriFromString_ShouldBe_SameAs_SystemUri()
    {
        var expected = new System.Uri(Sample_Uri);
        var actual = Uri.From(Sample_Uri);

        actual.Value.Should().Be(expected);

        //Following cases shows the Uri's Properties
        actual.Value.AbsolutePath.Should().Be(expected.AbsolutePath);
        actual.Value.AbsoluteUri.Should().Be(expected.AbsoluteUri);
        actual.Value.DnsSafeHost.Should().Be(expected.DnsSafeHost);
        actual.Value.Fragment.Should().Be(expected.Fragment);
        actual.Value.Host.Should().Be(expected.Host);
        actual.Value.HostNameType.Should().Be(expected.HostNameType);
        actual.Value.IdnHost.Should().Be(expected.IdnHost);
        actual.Value.IsAbsoluteUri.Should().Be(expected.IsAbsoluteUri);
        actual.Value.IsDefaultPort.Should().Be(expected.IsDefaultPort);
        actual.Value.IsFile.Should().Be(expected.IsFile);
        actual.Value.IsLoopback.Should().Be(expected.IsLoopback);
        actual.Value.IsUnc.Should().Be(expected.IsUnc);
        actual.Value.LocalPath.Should().Be(expected.LocalPath);
        actual.Value.OriginalString.Should().Be(expected.OriginalString);
        actual.Value.PathAndQuery.Should().Be(expected.PathAndQuery);
        actual.Value.Port.Should().Be(expected.Port);
        actual.Value.Query.Should().Be(expected.Query);
        actual.Value.Scheme.Should().Be(expected.Scheme);
        actual.Value.Segments.Should().IntersectWith(expected.Segments);
        actual.Value.UserEscaped.Should().Be(expected.UserEscaped);
        actual.Value.UserInfo.Should().Be(expected.UserInfo);


        _testOutputHelper.WriteLine($"AbsolutePath: {actual.Value.AbsolutePath}");
        _testOutputHelper.WriteLine($"AbsoluteUri: {actual.Value.AbsoluteUri}");
        _testOutputHelper.WriteLine($"DnsSafeHost: {actual.Value.DnsSafeHost}");
        _testOutputHelper.WriteLine($"Fragment: {actual.Value.Fragment}");
        _testOutputHelper.WriteLine($"Host: {actual.Value.Host}");
        _testOutputHelper.WriteLine($"HostNameType: {actual.Value.HostNameType}");
        _testOutputHelper.WriteLine($"IdnHost: {actual.Value.IdnHost}");
        _testOutputHelper.WriteLine($"IsAbsoluteUri: {actual.Value.IsAbsoluteUri}");
        _testOutputHelper.WriteLine($"IsDefaultPort: {actual.Value.IsDefaultPort}");
        _testOutputHelper.WriteLine($"IsFile: {actual.Value.IsFile}");
        _testOutputHelper.WriteLine($"IsLoopback: {actual.Value.IsLoopback}");
        _testOutputHelper.WriteLine($"IsUnc: {actual.Value.IsUnc}");
        _testOutputHelper.WriteLine($"LocalPath: {actual.Value.LocalPath}");
        _testOutputHelper.WriteLine($"OriginalString: {actual.Value.OriginalString}");
        _testOutputHelper.WriteLine($"PathAndQuery: {actual.Value.PathAndQuery}");
        _testOutputHelper.WriteLine($"Port: {actual.Value.Port}");
        _testOutputHelper.WriteLine($"Query: {actual.Value.Query}");
        _testOutputHelper.WriteLine($"Scheme: {actual.Value.Scheme}");
        _testOutputHelper.WriteLine($"Segments: {string.Join(", ", actual.Value.Segments)}");
        _testOutputHelper.WriteLine($"UserEscaped: {actual.Value.UserEscaped}");
        _testOutputHelper.WriteLine($"UserInfo: {actual.Value.UserInfo}");
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("www.example.com")] //Missing Scheme
    [InlineData("http://")] //Missing Authority
    public void NoxUri_ShouldNotAllowBadUris(string badUri)
    {
        Action init = () => { var url = Uri.From(badUri); };

        init.Should().Throw<TypeValidationException>();
    }
}