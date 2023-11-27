using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Nox.Exceptions;
using Nox.Extensions;

namespace Nox.Lib.Tests.Extensions
{
    public class HttpRequestExtensionsTests
    {
        [Theory]
        [AutoData]
        public void WhenEtagIsGuid_ShouldBeParsed(Mock<HttpRequest> httpRequest)
        {
            var headers = new HeaderDictionary();
            headers.Add("If-Match", "12345678-1234-1234-1234-123456789012");
            httpRequest.Setup(x=>x.Headers).Returns(headers);

            // Act // Assert 
            httpRequest.Object.GetDecodedEtagHeader().Should().NotBeEmpty();
        }
        [Theory]
        [AutoData]
        public void WhenEtagIsStringGuid_ShouldBeParsed(Mock<HttpRequest> httpRequest)
        {
            var headers = new HeaderDictionary();
            headers.Add("If-Match", "\"12345678-1234-1234-1234-123456789012\"");
            httpRequest.Setup(x => x.Headers).Returns(headers);

            // Act // Assert 
            httpRequest.Object.GetDecodedEtagHeader().Should().NotBeEmpty();
        }

        [Theory]
        [AutoData]
        public void WhenEtagIsInvalid_ShouldThrowConcurrencyException(Mock<HttpRequest> httpRequest)
        {
            var headers = new HeaderDictionary();
            headers.Add("If-Match", "slkdnsdlkfjdslkfjdslkjfdslkjfdslkfjdslkjflkdsjf");
            httpRequest.Setup(x => x.Headers).Returns(headers);

            Action act = () => httpRequest.Object.GetDecodedEtagHeader();

            // Act // Assert 
            act.Should().Throw<ConcurrencyException>();
        }
    }
}
