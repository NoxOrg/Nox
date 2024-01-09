using FluentAssertions;

namespace Nox.Solution.Tests.RelatedEntityRoutingTests;


public class RelatedEntityRoutingTests
{

    [Fact]
    public void WhenCallRelatedEntityPathBuilder_ShouldSucceed()
    {       
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./files/related-entity-routing.solution.nox.yaml")
            .Build();
        var entities = noxSolution.Domain!.Entities;
        var builder = new RelatedEntityRoutingPathBuilder(entities);
        var maxDepth = noxSolution.Presentation.ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth;

        var expectedPathsPerEntity = new Dictionary<string, List<string>>
        {
            {
                "Country",
                new List<string>()
        {
            "Countries/{countriesKey}/Currencies/{currenciesKey}/Stores/{storesKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/Stores/{storesKey}/License/{licenseKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/Stores/{storesKey}/License/{licenseKey}/Agent/{agentKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/Stores/{storesKey}/License/{licenseKey}/Agent/{agentKey}/Workplaces/{workplacesKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}/Store/{storeKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}/Agent/{agentKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}/Store/{storeKey}",
            "Countries/{countriesKey}/Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}/Agent/{agentKey}"
        }
            },
            {
                "Currency",
                new List<string>()
        {
            "Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}",
            "Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}",
            "Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}",
            "Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}/Agent/{agentKey}",
            "Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}/Agent/{agentKey}/Workplaces/{workplacesKey}",
            "Currencies/{currenciesKey}/DefaultCurrencyForLicense/{defaultCurrencyForLicenseKey}/Agent/{agentKey}/Workplaces/{workplacesKey}/Countries/{countriesKey}",
            "Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}/Agent/{agentKey}",
            "Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}/Agent/{agentKey}/Workplaces/{workplacesKey}",
            "Currencies/{currenciesKey}/SoldInCurrencyForLicense/{soldInCurrencyForLicenseKey}/Agent/{agentKey}/Workplaces/{workplacesKey}/Countries/{countriesKey}"
        }
            },
            {
                "Store",
                new List<string>()
        {
            "Stores/{storesKey}/Currencies/{currenciesKey}/Countries/{countriesKey}",
            "Stores/{storesKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Stores/{storesKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}",
            "Stores/{storesKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}"
        }
            },
            {
                "License",
                new List<string>()
        {
            "Licenses/{licensesKey}/Store/{storeKey}/Currencies/{currenciesKey}",
            "Licenses/{licensesKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}",
            "Licenses/{licensesKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Licenses/{licensesKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}/Agents/{agentsKey}",
            "Licenses/{licensesKey}/DefaultCurrency/{defaultCurrencyKey}/Countries/{countriesKey}",
            "Licenses/{licensesKey}/DefaultCurrency/{defaultCurrencyKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Licenses/{licensesKey}/DefaultCurrency/{defaultCurrencyKey}/Stores/{storesKey}",
            "Licenses/{licensesKey}/SoldInCurrency/{soldInCurrencyKey}/Countries/{countriesKey}",
            "Licenses/{licensesKey}/SoldInCurrency/{soldInCurrencyKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Licenses/{licensesKey}/SoldInCurrency/{soldInCurrencyKey}/Stores/{storesKey}"
        }
            },
            {
                "Agent",
                new List<string>()
        {
            "Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}",
            "Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}/Currencies/{currenciesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}/Workplaces/{workplacesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/DefaultCurrency/{defaultCurrencyKey}",
            "Agents/{agentsKey}/License/{licenseKey}/DefaultCurrency/{defaultCurrencyKey}/Countries/{countriesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/DefaultCurrency/{defaultCurrencyKey}/Stores/{storesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/SoldInCurrency/{soldInCurrencyKey}",
            "Agents/{agentsKey}/License/{licenseKey}/SoldInCurrency/{soldInCurrencyKey}/Countries/{countriesKey}",
            "Agents/{agentsKey}/License/{licenseKey}/SoldInCurrency/{soldInCurrencyKey}/Stores/{storesKey}"

        }
            },
            {
                "Workplace",
                new List<string>()
        {
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}/Currencies/{currenciesKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/Store/{storeKey}/Currencies/{currenciesKey}/Countries/{countriesKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/DefaultCurrency/{defaultCurrencyKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/DefaultCurrency/{defaultCurrencyKey}/Stores/{storesKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/SoldInCurrency/{soldInCurrencyKey}",
            "Workplaces/{workplacesKey}/Agents/{agentsKey}/License/{licenseKey}/SoldInCurrency/{soldInCurrencyKey}/Stores/{storesKey}"
        }
            }
        };

        foreach (var entity in entities)
        {
            var paths = builder.GetAllRelatedPathsForEntity(entity, maxDepth);
            paths.Should().BeEquivalentTo(expectedPathsPerEntity[entity.Name]);
        }
    }
}