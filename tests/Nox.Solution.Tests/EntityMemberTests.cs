using Nox.Types;

namespace Nox.Solution.Tests;

public class EntityMemberTests
{
    [Fact]
    public void Entity_GetMembers_Returns_Valid_Result()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig?.Domain?.Entities);

        var country = noxConfig.Domain.Entities[0];
        Assert.Equal("Country", country.Name);

        var countryMembers = country.GetAllMembers().ToList();

        Assert.Equal(17, countryMembers.Count);

    }

}