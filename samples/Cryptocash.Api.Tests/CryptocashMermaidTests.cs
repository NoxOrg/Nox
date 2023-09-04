using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;
using System.Text;
using Nox;
using Nox.Types;
using System.Net.WebSockets;
using System.Reflection;
using YamlDotNet.Serialization;
using Nox.Solution.Extensions;
using System.Globalization;

namespace Cryptocash.Api.Tests;

public class CryptocashMermaidTests
{
    [Fact]
    public void Solution_Creates_Valid_Mermaid_Erd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("../../../../.nox/design/cryptocash.solution.nox.yaml")
            .Build();

        var docs = noxSolution.ToMarkdownReadme();

        File.WriteAllText("../../../../README.md", docs);
    }


}