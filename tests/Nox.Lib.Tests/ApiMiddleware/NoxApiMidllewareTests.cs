﻿using Castle.Core.Resource;
using FluentAssertions;

namespace Nox.Lib.Tests.ApiMiddleware;
public class NoxApiMidllewareTests
{

    private readonly string _testPattern = "/Customers/{CustomerId}/Contacts/{ContactId}?$select={Properties}";
    private readonly string _testPatternDuplicateParam = "/Customers/{CustomerId}/Contacts/{Properties}?$select={Properties}";

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
            .Matches(testRoute, out var values)
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
            .Matches(testRoute, out var values)
            .Should().BeFalse();

        values.Should().BeNull();

    }

}