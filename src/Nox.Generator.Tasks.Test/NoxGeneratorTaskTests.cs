using FluentAssertions;
using Microsoft.Build.Framework;
using Moq;
using Xunit;

namespace Nox.Generator.Tasks.Test;

public class NoxGeneratorTaskTests
{
    [Fact]
    public void EmptyInputFilesList_NoFilesGenerated()
    {
        //Arrange
        var noxGeneratorTask = new NoxGeneratorTask { NoxYamlFiles = new ITaskItem[0] };
        noxGeneratorTask.BuildEngine = new Mock<IBuildEngine>().Object;

        //Act
        var success = noxGeneratorTask.Execute();

        //Assert
        success.Should().BeTrue();
    }
}