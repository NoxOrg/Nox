using FluentAssertions;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests.Models.Domain.Entities;

public class EntityTests
{
    [Fact]
    public void WhenReferenceNumber_ShouldLoadTypeOptions()
    {
        var solution = new NoxSolutionBuilder()
            .WithFile("./files/domain.solution.nox.yaml")
            .Build();

        var referenceNumber =
            solution.Domain!.Entities
            .Single(e => e.Name == "Currency")
            .Attributes.Single(e => e.Name == "Code");

        referenceNumber.Should().NotBeNull();
        referenceNumber.ReferenceNumberTypeOptions.Should().NotBeNull();
        referenceNumber.ReferenceNumberTypeOptions!.Prefix.Should().Be("C-");
        referenceNumber.ReferenceNumberTypeOptions.SuffixCheckSumDigit.Should().BeFalse();
    }

    [Fact]
    public void WhenReferenceNumberTypeotionsInvalid_ShouldThrowException()
    {

        Action act = () => new NoxSolutionBuilder()
               .WithFile("./files/invalid.referencenumbertypeoptions.solution.nox.yaml")
               .Build();
       
        act.Should()
            .Throw<NoxYamlValidationException>()
            .Where(exception => exception.Errors[0].ErrorMessage.Contains("ReferenceNumber [Code] on entity [Currency] Prefix invalid. Prefix is required with a max length of 10."));

    }
    [Fact]
    public void WhenReferenceNumberDuplicatedPrefix_ShouldThrowException()
    {

        Action act = () => new NoxSolutionBuilder()
               .WithFile("./files/invalid.referencenumber.duplicated.solution.nox.yaml")
               .Build();

        act.Should()
            .Throw<NoxYamlValidationException>()
            .Where(exception => exception.Errors[0].ErrorMessage.Contains("Reference Number type must have a unique Prefix. Prefix [C - ] is duplicated."));

    }

    [Fact]
    public void WhenEntityHasMultipleRelationsToAnotherEntity_ShouldLoadCorrectRelationships()
    {
        var solution = new NoxSolutionBuilder()
            .WithFile("./files/relationships-valid-multiple-relations-to-same-entity.solution.nox.yaml")
            .Build();

        var currency = solution.Domain!.Entities
            .Single(e => e.Name == "Currency");

        var exchangeRate = solution.Domain!.Entities
            .Single(e => e.Name == "ExchangeRate");

        currency.Relationships.Single(r => r.Name == "ExchangeRateTo")
            .Related.EntityRelationship
            .Should().Be(exchangeRate.Relationships.Single(x => x.Name == "CurrencyTo"));

        currency.Relationships.Single(r => r.Name == "ExchangeRateFrom")
            .Related.EntityRelationship
            .Should().Be(exchangeRate.Relationships.Single(x => x.Name == "CurrencyFrom"));

        exchangeRate.Relationships.Single(r => r.Name == "CurrencyTo")
            .Related.EntityRelationship
            .Should().Be(currency.Relationships.Single(x => x.Name == "ExchangeRateTo"));

        exchangeRate.Relationships.Single(r => r.Name == "CurrencyFrom")
            .Related.EntityRelationship
            .Should().Be(currency.Relationships.Single(x => x.Name == "ExchangeRateFrom"));
    }
}
