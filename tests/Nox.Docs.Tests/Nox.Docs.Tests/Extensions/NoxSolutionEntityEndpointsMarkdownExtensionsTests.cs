﻿using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionEntityEndpointsMarkdownExtensionsTests
{
    [Fact]
    public void Solution_Creates_Valid_EntityEndpoints_Markdown()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./Files/Design/sample-for-endpoints.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownEntityEndpoints()
            .OrderBy(m => m.Name);
        
        
        foreach (var item in actual)
        {
            File.WriteAllText( Path.Combine( "./../../../Files/Markdown",  Path.GetFileName(item.Name)), item.Content);
        }

        // Assert
        var expected = new[]
        {
            CreateMarkdownFile("People"),
            CreateMarkdownFile("Country"),
            CreateMarkdownFile("Continent"),
        }
        .OrderBy(m => m.Name);

        actual.Should().BeEquivalentTo(expected);
    }

    private static EntityMarkdownFile CreateMarkdownFile(string entity)
        => new()
        {
            Name = $"./endpoints/{entity}Endpoints.md",
            Content = ReadMarkdownFile($"{entity}Endpoints.md"),
            EntityName = entity,
        };

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
