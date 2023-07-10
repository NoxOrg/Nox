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
                    Text Id PK
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
                    Collection CountryLocalNames
                    Text CurrencyId FK
                }
                Currency {
                    Text Id PK
                    Text CountryId FK
                }
                Currency}|--o{Country : "is legal tender for"
                CountryLocalNames {
                    AutoNumber Id PK
                }
                CurrencyCashBalance {
                    Entity Store PK
                    Entity Currency PK
                    Number Amount
                    Number OperationLimit
                }

            """;

        Assert.Equal(mermaidText, expectedResult);

    }

    [Fact]
    public void Solution_Creates_Valid_Mermaid_DetailedErd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        var mermaidText = noxSolution.ToMermaidErd(ErdDetail.Detailed);

        var expectedResult = """
            erDiagram
                Country {
                    Text Id PK ""
                    Text Name "The country's common name (Required)"
                    Text FormalName "The country's official name (Required)"
                    Text AlphaCode3 "The country's official ISO 4217 alpha-3 code (Required)"
                    Text AlphaCode2 "The country's official ISO 4217 alpha-2 code (Required)"
                    Number NumericCode "The country's official ISO 4217 alpha-3 code (Required)"
                    Text DialingCodes "The country's phone dialing codes (comma-delimited)"
                    Text Capital "The capital city of the country"
                    Text Demonym "Noun denoting the natives of the country"
                    Number AreaInSquareKilometres "Country area in square kilometers (Required)"
                    LatLong GeoCoord "The the position of the workplace's point on the surface of the Earth"
                    Text GeoRegion "The region the country is in (Required)"
                    Text GeoSubRegion "The sub-region the country is in (Required)"
                    Text GeoWorldRegion "The world region the country is in (Required)"
                    Number Population "The estimated population of the country"
                    Text TopLevelDomains "The top level internet domains regitered to the country (comma-delimited)"
                    Text CountryLocalNamesId ""
                    Text CurrencyId FK ""
                }
                Currency {
                    Text Id PK ""
                    Text CountryId FK ""
                }
                Currency}|--o{Country : "is legal tender for"
                CountryLocalNames {
                    Text Id PK ""
                }
                CurrencyCashBalance {
                    Entity Store PK " (Required)"
                    Entity Currency PK " (Required)"
                    Number Amount "The amount (Required)"
                    Number OperationLimit "The Operation Limit"
                }

            """;

        Assert.Equal(mermaidText, expectedResult);

    }

    [Fact]
    public void Solution_Creates_Valid_Mermaid_SummaryErd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        var mermaidText = noxSolution.ToMermaidErd(ErdDetail.Summary);

        var expectedResult = """
            erDiagram
                Country {
                }
                Currency {
                }
                Currency}|--o{Country : "is legal tender for"
                CountryLocalNames {
                }
                CurrencyCashBalance {
                }

            """;

        Assert.Equal(mermaidText, expectedResult);

    }


}