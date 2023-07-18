using Microsoft.Extensions.DependencyInjection;
using Nox.Types;

namespace Nox.Solution.Tests;

public class RefDeserializationTests
{

    [Fact]
    public void Can_create_a_full_configuration()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/ref/ref.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);

    }
}