using FluentAssertions;
using Nox.Presentation.Api.OData;

namespace Nox.Lib.Tests.Presentation.Api.OData
{
    public class ODataApiTests
    {
        [Theory]
        [InlineData("odata", "odata")]
        [InlineData("odata/v1", "odata/v1")]
        public void WhenRoutePrefixStartBySlash_ShouldRemoveIt(string routePrefix, string expectedODataRoutePrefix)
        {
            ODataApi.GetRoutePrefix(routePrefix).Should().Be(expectedODataRoutePrefix);
        }
    }
}