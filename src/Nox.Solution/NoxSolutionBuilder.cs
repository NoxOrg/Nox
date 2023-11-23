using Nox.Yaml;
using Nox.Yaml.VariableProviders.Environment;
using System;
using System.Collections.Generic;
using System.IO;

namespace Nox.Solution;

public class NoxSolutionBuilder
{

    private readonly YamlConfigurationReader<NoxSolution, NoxSolutionBasicsOnly> _configurationReader;

    public NoxSolutionBuilder()
    {
        _configurationReader = new YamlConfigurationReader<NoxSolution, NoxSolutionBasicsOnly>()
            .WithSingleFileMatching("*.solution.nox.yaml")
            .WithSearchPath("./")
            .WithSearchPath("../.")
            .WithSearchPath("./.nox/design")
            .WithSearchPath("./design")
            .WithSearchPath("./Design")
            .WithSearchFromExecutionFolder("./.nox/design")
            .WithSearchFromExecutionFolder("./design")
            .WithSearchFromExecutionFolder("./Design")
            .WithSearchFromRepositoryRoot("./.nox/design")
            .WithEnvironmentVariableDefaultsProvider(
                new EnvironmentVariableDefaultsProvider<NoxSolutionBasicsOnly>(s => s.Variables ?? new Dictionary<string, object>())
            );

    }

    public NoxSolutionBuilder WithFile(string yamlFilePath)
    {
        _configurationReader.WithFile(yamlFilePath);
        return this;
    }

    public NoxSolutionBuilder WithYamlFilesAndContent(IDictionary<string, Func<TextReader>> yamlFilesAndContent)
    {
        _configurationReader.WithYamlFilesAndContent(yamlFilesAndContent);
        return this;
    }

    public NoxSolutionBuilder AllowMissingSolutionYaml()
    {
        _configurationReader.AllowMissingSolutionYaml();
        return this;
    }

    public NoxSolutionBuilder WithSecretsVariableValueProvider(SecretsVariableValueProvider<NoxSolutionBasicsOnly> secretVariableValueProvider)
    {
        _configurationReader.WithSecretsVariableValueProvider(secretVariableValueProvider);
        return this;
    }

    public NoxSolutionBuilder WithEnvironmentProvider(IEnvironmentProvider provider)
    {
        _configurationReader.WithEnvironmentProvider(provider);
        return this;
    }

    public NoxSolution Build()
    {
        var config = _configurationReader.Read();
        return config;
    }

}
