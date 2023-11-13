using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;
using System.Collections;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionReadmeExtensionsTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void Solution_Creates_Valid_Readme_Markdown(string filePath)
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile(filePath)
            .Build();

        // Act
        var action = () => noxSolution.ToMarkdownReadme();

        // Assert
        action.Should().NotThrow();
    }

    public class TestData : IEnumerable<object[]>
    {
        private const string BasePath = "./Files/Design";
        private const string FileExtension = ".nox.yaml";

        public IEnumerator<object[]> GetEnumerator()
        {
            var files = Directory.GetFiles(BasePath, $"*{FileExtension}");
            foreach (var file in files)
            {
                yield return new object[] { file };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
