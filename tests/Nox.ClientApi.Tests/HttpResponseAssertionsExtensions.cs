using System.Net;
using System.Net.Http;
using FluentAssertions.Primitives;

namespace FluentAssertions;

internal static class HttpResponseAssertionsExtensions
{
    public static AndConstraint<ObjectAssertions> HaveStatusCode(
        this ObjectAssertions assertions,
        HttpStatusCode expectedStatusCode,
        string because = "",
        params object[] becauseArgs)
    {
        assertions.Subject
            .Should()
            .BeAssignableTo<HttpResponseMessage>(because, becauseArgs);

        var response = (HttpResponseMessage)assertions.Subject!;

        response.StatusCode
            .Should()
            .Be(expectedStatusCode, because, becauseArgs);

        return new AndConstraint<ObjectAssertions>(assertions);
    }

    public static AndConstraint<ObjectAssertions> BeSuccessful(
        this ObjectAssertions assertions,
        string because = "",
        params object[] becauseArgs)
    {
        assertions.Subject
            .Should()
            .BeAssignableTo<HttpResponseMessage>(because, becauseArgs);

        var response = (HttpResponseMessage)assertions.Subject!;

        response.IsSuccessStatusCode
            .Should()
            .BeTrue(because, becauseArgs);

        return new AndConstraint<ObjectAssertions>(assertions);
    }
}
