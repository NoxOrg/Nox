using FluentAssertions;
using Nox.Types;
using Nox.Yaml.Enums.CultureCode;

namespace Nox.Solution.Tests;

public class LocalizationTests
{
    [Fact]
    public void SetDefaults_ShouldAddDefaultCulture_WhenNotInSupportedCultures()
    {
        var solution = new NoxSolutionBuilder()
              .WithFile($"./files/localization-without-default-culture-in-supported-cultures.solution.nox.yaml")
              .Build();

        var defaultCulture = solution.Application!.Localization!.DefaultCulture;
        var supportedCultures = solution.Application.Localization.SupportedCultures;

        defaultCulture.Should().Be(Culture.en_US);
        supportedCultures.Should().BeEquivalentTo("en", "en-US", "de-DE", "fr-FR", "it-IT");
    }

    [Fact]
    public void SetDefaults_ShouldRemoveRedundantSupportedCultures()
    {
        var solution = new NoxSolutionBuilder()
              .WithFile($"./files/localization-with-redundant-supported-cultures.solution.nox.yaml")
              .Build();

        var defaultCulture = solution.Application!.Localization!.DefaultCulture;
        var supportedCultures = solution.Application.Localization.SupportedCultures;

        defaultCulture.Should().Be(Culture.en_US);
        supportedCultures.Should().BeEquivalentTo("en", "en-US", "de-DE", "fr-FR", "it-IT");
    }
}
