using FluentAssertions;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests.Models.Application.Jobs;

public class JobTests
{
    [Fact]
    public void WhenJobsAreValid_ShouldLoadSolution()
    {
        // Act
        var solution = new NoxSolutionBuilder()
            .WithFile("./files/application.jobs.valid.nox.yaml")
            .Build();

        // Assert
        solution.Application!.Jobs.Count.Should().Be(2);
        solution.Application!.Jobs.Single(j => j.Name == "job1").RecurrentCronExpression.Should().Be("*/5 * * * *");
        solution.Application!.Jobs.Single(j => j.Name == "job2").RecurrentCronExpression.Should().Be("0 0 * * *");

    }

    [Fact]
    public void WhenAJobCronnIsInvalid_ShouldThrowException()
    {
        var action = () =>
        {
            new NoxSolutionBuilder()
            .WithFile("./files/application.jobs.invalid.cron.nox.yaml")
            .Build();
        };
        // Act Assert
        action.Should().Throw<NoxYamlValidationException>().WithMessage("*recurrentCronExpression*");
    }
}
