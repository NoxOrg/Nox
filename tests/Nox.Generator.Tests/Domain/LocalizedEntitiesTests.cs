﻿using Xunit;

namespace Nox.Generator.Tests.Domain;

public class LocalizedEntitiesTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public LocalizedEntitiesTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_localized_entity_files()
    {
        var path = "files/yaml/domain/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}domain-events.solution.nox.yaml"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(10, "Domain.CountryLocalized.g.cs")
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("CountryLocalized.expected.g.cs", "Domain.CountryLocalized.g.cs");
    }
}