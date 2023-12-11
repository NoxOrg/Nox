using FluentAssertions;
using Nox.Docs.Extensions;
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
            .WithFile(filePath)
            .Build();

        // Act
        var action = () => noxSolution.ToMarkdownReadme();

        // Assert
        action.Should().NotThrow();
    }

    public class TestData : IEnumerable<object[]>
    {
        private const string _basePath = "./Files/Design";
        private const string _fileExtension = ".nox.yaml";

        public IEnumerator<object[]> GetEnumerator()
        {
            var files = Directory.GetFiles(_basePath, $"*{_fileExtension}");
            foreach (var file in files)
            {
                yield return new object[] { file };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
