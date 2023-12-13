using FluentAssertions;

namespace Nox.Lib.Tests.ApiMiddleware;
public class NoxApiMidllewareTests
{

    private readonly string _testPattern = "/Customers/{CustomerId}/Contacts/{ContactId}?$select={Properties}";
    private readonly string _testPatternDuplicateParam = "/Customers/{CustomerId}/Contacts/{Properties}?$select={Properties}";
    private readonly string _testPatternConsecutiveParam = "/Customers/{CustomerId}/{ContactId}/{Properties}";
    private readonly string _testPatternStartsWithParam = "{CustomerId}/Contacts/{ContactId}?$select={Properties}";
    private readonly string _testPatternEndsWithoutParam = "/Customers/{CustomerId}/{ContactId}/{Properties}/Form";

    [Fact]
    public void RouteMatcher_Parses_String()
    {

        var routeMatcher = new ApiRouteMatcher(_testPattern);

        routeMatcher.HasParameter("CustomerId").Should().BeTrue();
        routeMatcher.HasParameter("ContactId").Should().BeTrue();
        routeMatcher.HasParameter("Properties").Should().BeTrue();  
        routeMatcher.HasParameter("DoesNotExist").Should().BeFalse();  
    }

    [Fact]
    public void RouteMatcher_With_Invalid_Braces_Throws_ArgumentException()
    {

        var notEnoughBraces = () => new ApiRouteMatcher("/this/{is/an/{invalid}/route");

        notEnoughBraces
            .Should()
            .Throw<ArgumentException>()
            .WithMessage($"Parameter open and closed brace mismatch in [*].");
    }

    [Fact]
    public void RouteMatcher_Parses_CnsecutiveParams_String()
    {

        var routeMatcher = new ApiRouteMatcher(_testPatternConsecutiveParam);

        routeMatcher.HasParameter("CustomerId").Should().BeTrue();
        routeMatcher.HasParameter("ContactId").Should().BeTrue();
        routeMatcher.HasParameter("Properties").Should().BeTrue();
        routeMatcher.HasParameter("DoesNotExist").Should().BeFalse();
    }

    [Fact]
    public void RouteMatcher_Throws_InvalidArgument_WithDuplicateParam()
    {

        var tryNewOnDuplicate = () => new ApiRouteMatcher(_testPatternDuplicateParam);

        tryNewOnDuplicate
            .Should()
            .Throw<ArgumentException>()
            .WithMessage($"The variable [*] should only appear once in [*].");

    }

    [Theory]
    [InlineData("/Customers/1/Contacts/42?$select=FirstName,LastName", "1", "42", "FirstName,LastName")]
    [InlineData("/Customers/100/Contacts/200?$select=A", "100", "200", "A")]
    [InlineData("/Customers/a1b2c3/Contacts/d4e5f6?$select=___", "a1b2c3", "d4e5f6", "___")]
    public void RouteMatcher_Matches_String(string testRoute, string customerId, string contactId, string properties)
    {

        var routeMatcher = new ApiRouteMatcher(_testPattern);

        routeMatcher
            .Match(testRoute, out var values)
            .Should().BeTrue();

        values.Should().NotBeNull();

        values!["CustomerId"].Should().Be(customerId);
        values!["ContactId"].Should().Be(contactId);
        values!["Properties"].Should().Be(properties);
    }

    [Theory]
    [InlineData("")]
    [InlineData("/")]
    [InlineData("/swagger")]
    [InlineData("/Countries/100/Customers/1/Contacts/42?$select=FirstName,LastName")]
    [InlineData("/Contacts/1/Customers/42?$select=FirstName,LastName")]
    [InlineData("/Customers/42/Customers/42?$select=FirstName,LastName")]
    public void RouteMatcher_Does_Not_Match_String(string testRoute)
    {

        var routeMatcher = new ApiRouteMatcher(_testPattern);

        routeMatcher
            .Match(testRoute, out var values)
            .Should().BeFalse();

        values.Should().BeNull();

    }

    [Theory]
    [InlineData("1/Contacts/42?$select=FirstName,LastName", "1", "42", "FirstName,LastName")]
    [InlineData("100/Contacts/200?$select=A", "100", "200", "A")]
    [InlineData("a1b2c3/Contacts/d4e5f6?$select=___", "a1b2c3", "d4e5f6", "___")]
    public void RouteMatcher_Matches_String_That_StartsWithParam(string testRoute, string customerId, string contactId, string properties)
    {

        var routeMatcher = new ApiRouteMatcher(_testPatternStartsWithParam);

        routeMatcher
            .Match(testRoute, out var values)
            .Should().BeTrue();

        values.Should().NotBeNull();

        values!["CustomerId"].Should().Be(customerId);
        values!["ContactId"].Should().Be(contactId);
        values!["Properties"].Should().Be(properties);
    }

    [Theory]
    [InlineData("/Customers/1/42/FirstName,LastName/Form", "1", "42", "FirstName,LastName")]
    [InlineData("/Customers/100/200/A/Form", "100", "200", "A")]
    [InlineData("/Customers/a1b2c3/d4e5f6/___/Form", "a1b2c3", "d4e5f6", "___")]
    public void RouteMatcher_Matches_String_That_EndsWithoutParam(string testRoute, string customerId, string contactId, string properties)
    {

        var routeMatcher = new ApiRouteMatcher(_testPatternEndsWithoutParam);

        routeMatcher
            .Match(testRoute, out var values)
            .Should().BeTrue();

        values.Should().NotBeNull();

        values!["CustomerId"].Should().Be(customerId);
        values!["ContactId"].Should().Be(contactId);
        values!["Properties"].Should().Be(properties);
    }


}
