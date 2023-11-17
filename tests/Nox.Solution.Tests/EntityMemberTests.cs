using FluentAssertions;

namespace Nox.Solution.Tests;

public class EntityMemberTests
{
    [Fact]
    public void Entity_GetMembers_Returns_Valid_Result()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/sample.solution.nox.yaml")
            .Build();

        var country = noxConfig.Domain!.Entities[0];
        var countryMembers = country.GetAllMembers().ToList();


        (noxConfig?.Domain?.Entities).Should().NotBeNull();
        country.Name.Should().Be("Country");
        
        countryMembers
            .Count(member => member.Key == EntityMemberType.Key)
            .Should().Be(1);

        countryMembers
            .Count(member => member.Key == EntityMemberType.Attribute)
            .Should().Be(15);

        countryMembers
            .Count(member => member.Key == EntityMemberType.Relationship)
            .Should().Be(1);

        countryMembers
            .Count(member => member.Key == EntityMemberType.OwnedRelationship)
            .Should().Be(1);

    }

}