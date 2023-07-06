using Nox.Solution;
using Nox.Docs.Extensions;

namespace Nox.Docs.Tests;

public class NoxDocsMermaidTests
{
    [Fact]
    public void Solution_Creates_Valid_Mermaid_Erd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        var mermaidText = noxSolution.ToMermaidErd();

        var expectedResult = """
        erDiagram
            Country {
                Text Name
                Text FormalName
                Text AlphaCode3
                Text AlphaCode2
                Number NumericCode
                Text DialingCodes
                Text Capital
                Text Demonym
                Number AreaInSquareKilometres
                LatLong GeoCoord
                Text GeoRegion
                Text GeoSubRegion
                Text GeoWorldRegion
                Number Population
                Text TopLevelDomains
            }
            CurrencyCashBalance {
                Number Amount
                Number OperationLimit
            }
            Country}o--|{Currency : accepts_as_legal_tender

        """;

        Assert.Equal(mermaidText, expectedResult);

    }
}