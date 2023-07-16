using System.IO;
using System.Linq;
using Nox.Solution.Events;
using Nox.Solution.Schema;
using Nox.Solution.Exceptions;
using Nox.Solution.Macros;
using Nox.Solution.Utils;
using Nox.Solution.Yaml;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using System;

namespace Nox.Solution
{
    public class NoxSolutionBuilder
    {
        private const string DesignFolderBestPractice = "Best practice is to create a '.nox' folder in your solution folder and in there a 'design' folder which contains your <solution-name>.solution.nox.yaml";

        private string? _yamlFilePath;

        private IDictionary<string,string>? _yamlFilesAndContent;

        private string? _rootFileAndContentKey; 

        private IMacroParser _environmentVariableParser = new EnvironmentVariableMacroParser(new EnvironmentProvider());
        private IMacroParser _secretParser = new SecretMacroParser();

        public delegate void ResolveSecretsEventHandler(object sender, INoxSolutionSecretsEventArgs args);
        public event ResolveSecretsEventHandler? OnResolveSecretsEvent;
        
        public NoxSolutionBuilder UseYamlFile(string yamlFilePath)
        {
            _yamlFilePath = Path.GetFullPath(yamlFilePath);
            return this;
        }

        public NoxSolutionBuilder UseYamlFilesAndContent(IDictionary<string, string> yamlFilesAndContent)
        {
            _yamlFilesAndContent = yamlFilesAndContent
                .ToDictionary(kv => Path.GetFileName(kv.Key), kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            return this;
        }


        public NoxSolutionBuilder UseEnvironmentMacroParser(EnvironmentVariableMacroParser parser)
        {
            _environmentVariableParser = parser;
            return this;
        }

        public NoxSolutionBuilder UseSecretMacroParser(SecretMacroParser parser)
        {
            _secretParser = parser;
            return this;
        }

        public NoxSolutionBuilder OnResolveSecrets(ResolveSecretsEventHandler handler)
        {
            OnResolveSecretsEvent += handler;
            return this;
        }

        public NoxSolution Build()
        {
            ResolveAndValidateFilesAndContent();

            var config = ResolveAndLoadConfiguration();

            config.Validate();

            return config;
        }

        private void ResolveAndValidateFilesAndContent()
        {
            if (_yamlFilesAndContent is null)
            {
                _yamlFilesAndContent = LoadFromFileSystem();
            }

            if (_yamlFilesAndContent is null || _yamlFilesAndContent.Count == 0)
            {
                throw new NoxSolutionConfigurationException("No yaml file(s) specified or found");
            }

            if (_rootFileAndContentKey is null)
            {
                var solutionFiles = _yamlFilesAndContent
                    .Where(kv => kv.Key.ToLower().Contains(".solution.nox.yaml"))
                    .Select(kv => kv.Key)
                    .ToArray();

                if (solutionFiles.Length == 0)
                {
                    throw new NoxSolutionConfigurationException("No solution yaml file(s) specified or found.");
                }

                if (solutionFiles.Length > 1)
                {
                    var fileNames = string.Join(",", solutionFiles);
                    throw new NoxSolutionConfigurationException($"Multiple solution yaml file(s) specified or found. [{fileNames}]");
                }

                _rootFileAndContentKey = solutionFiles[0];
            }
        }

        private IDictionary<string, string> LoadFromFileSystem()
        {
            //If a yaml root configuration has not been specified, search for one in the .nox/design folder in the solution root folder
            if (string.IsNullOrWhiteSpace(_yamlFilePath))
            {
                _yamlFilePath = Path.GetFullPath(FindRootYamlFile());
            }
            else
            {
                //Ensure that the root yaml file exists
                if (!File.Exists(_yamlFilePath))
                {
                    throw new NoxSolutionConfigurationException($"Nox root yaml configuration file ({_yamlFilePath}) not found! Have you created a Nox yaml configuration for your solution? {DesignFolderBestPractice}");
                }
            }

            var path = Path.GetDirectoryName(_yamlFilePath);

            var files = Directory.GetFiles(path!, "*.yaml", SearchOption.AllDirectories);

            if (files.Select(f => Path.GetFileName(f).ToLower()).Distinct().Count() < files.Length)
            {
                files = Directory.GetFiles(path!, "*.yaml", SearchOption.TopDirectoryOnly);
            }

            _rootFileAndContentKey = Path.GetFileName(_yamlFilePath);

            return files.ToDictionary(f => Path.GetFileName(f), File.ReadAllText, StringComparer.OrdinalIgnoreCase);
        }

        private NoxSolution ResolveAndLoadConfiguration()
        {
            var resolver = new YamlReferenceResolver(_yamlFilesAndContent!, _rootFileAndContentKey!);
            var yamlRef = resolver.ResolveReferences();

            var secretsConfig = GetSecretsConfig(yamlRef);
            
            var resolveSecretsArgs = new NoxSolutionSecretsEventArgs(yamlRef, secretsConfig);
            RaiseResolveSecretsEvent(resolveSecretsArgs);
            
            var yaml = _secretParser.Parse(yamlRef, resolveSecretsArgs.Secrets);
            yaml = ExpandEnvironmentMacros(yaml);
            var config = NoxSchemaValidator.Deserialize<NoxSolution>(yaml);
            config.RootYamlFile = _yamlFilePath;
            return config;
        }

        private string? FindSolutionRoot()
        {
            var path = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (path != null)
            {
                if (path.GetDirectories(".git").Any())
                {
                    return path.FullName;
                }
                path = path.Parent;
            }

            return null;
        }

        private string? FindNoxDesignFolder(string rootPath)
        {
            var path = new DirectoryInfo(rootPath);
            if (path.GetDirectories(".nox").Any())
            {
                path = new DirectoryInfo(Path.Combine(path.FullName, ".nox"));
                if (path.GetDirectories("design").Any())
                {
                    return Path.Combine(path.FullName, "design");
                }
            }
            return null;
        }

        private string FindRootYamlFile()
        {
            //look in the current folder
            var rootYaml = FindSolutionYamlFile("./");
            if (rootYaml != null) return rootYaml;

            //look in .nox/design
            var designFolder = FindNoxDesignFolder("./");
            if (designFolder != null)
            {
                rootYaml = FindSolutionYamlFile(designFolder);
                if (rootYaml != null) return rootYaml;
            }
            //look in solution root/.nox/design
            var solutionRoot = FindSolutionRoot();
            if (string.IsNullOrWhiteSpace(solutionRoot))
            {
                throw new NoxSolutionConfigurationException("Unable to locate the root folder of your solution. Have you created a git repo for your solution?");
            }

            designFolder = FindNoxDesignFolder(solutionRoot!);
            if (string.IsNullOrWhiteSpace(designFolder))
            {
                throw new NoxSolutionConfigurationException($"Unable to locate a .nox/design folder in your solution folder ({solutionRoot}). Best practice is to create a '.nox' folder in your solution folder and in there a 'design' folder which contains your <solution-name>.solution.nox.yaml and supporting files.");
            }

            rootYaml = FindSolutionYamlFile(designFolder!);
            if (rootYaml == null)
                throw new NoxSolutionConfigurationException("Unable to locate a *.solution.nox.yaml file, searched current folder, <current>/.nox/design and <solution root>/.nox/design");
            return rootYaml;
        }

        private string? FindSolutionYamlFile(string folder)
        {
            var solutionYamlFiles = Directory.GetFiles(folder, "*.solution.nox.yaml");
            if (solutionYamlFiles.Length > 1)
            {
                throw new NoxSolutionConfigurationException($"Found more than one *.solution.nox.yaml file in folder ({folder}). {DesignFolderBestPractice}");
            }
            else if (solutionYamlFiles.Length == 1) return solutionYamlFiles[0];

            return null;
        }

        private string ExpandEnvironmentMacros(string yaml)
        {
            var definitionVariableParser = new DefinitionVariableParser();
            var variables = definitionVariableParser.Parse(yaml);
            
            yaml = _environmentVariableParser.Parse(yaml, variables);

            return yaml;
        }
        
        private string ExpandSecrets(string yaml)
        {
            return yaml;
        }

        private void RaiseResolveSecretsEvent(NoxSolutionSecretsEventArgs args)
        {
            OnResolveSecretsEvent?.Invoke(this, args);
        }

        private Secrets? GetSecretsConfig(string yaml)
        {
            var source = new StringReader(yaml);
            var yamlStream = new YamlStream();
            yamlStream.Load(source);
            if (yamlStream.Documents.Count == 0) return null;
            var mappingNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;
            try
            {
                //infrastructure -> security -> secrets
                var infraNode = mappingNode.Children[new YamlScalarNode("infrastructure")];
                var securityNode = ((YamlMappingNode)infraNode).Children[new YamlScalarNode("security")];
                var secretsNode = ((YamlMappingNode)securityNode).Children[new YamlScalarNode("secrets")];

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                
                var result = deserializer.Deserialize<Secrets>(
                    new EventStreamParserAdapter(YamlNodeToEventStreamConverter.ConvertToEventStream(secretsNode))
                );
                
                return result;

            }
            catch
            {
                //ignore as the infrastructure -> security -> secrets node does not exist in the yaml or is not valid
            }

            return null;
        }

    }
}