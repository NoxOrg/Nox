
using Nox.Types;

namespace Nox.Solution.Tests;

public class SampleSolutionDeserializationTests
{
    [Fact]
    public void SampleSolution_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./SampleDesign/cryptocash.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);

    }

}