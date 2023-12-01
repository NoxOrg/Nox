using FluentAssertions;
using Nox.Yaml.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Solution.Tests;

public class LocalizationTests
{
    [Fact]
    public void ApplyDefaults_ShouldAddDefaultCulture_WhenNotInSupportedCultures()
    {
        var solution = new NoxSolutionBuilder()
              .WithFile($"./files/localization-without-default-culture-in-supported-cultures.solution.nox.yaml")
              .Build();

        solution.Application!.Localization!.ApplyDefaults();

        var defaultCulture = solution.Application.Localization.DefaultCulture;
        var supportedCultures = solution.Application.Localization.SupportedCultures;

        defaultCulture.Should().Be("en-US");
        supportedCultures.Should().BeEquivalentTo("en", "en-US", "de-DE", "fr-FR", "it-IT");
    }

    [Fact]
    public void ApplyDefaults_ShouldRemoveRedundantSupportedCultures()
    {
        var solution = new NoxSolutionBuilder()
              .WithFile($"./files/localization-with-redundant-supported-cultures.solution.nox.yaml")
              .Build();

        solution.Application!.Localization!.ApplyDefaults();

        var defaultCulture = solution.Application.Localization.DefaultCulture;
        var supportedCultures = solution.Application.Localization.SupportedCultures;

        defaultCulture.Should().Be("en-US");
        supportedCultures.Should().BeEquivalentTo("en", "en-US", "de-DE", "fr-FR", "it-IT");
    }
}
