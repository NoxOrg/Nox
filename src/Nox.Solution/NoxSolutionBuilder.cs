using System.IO;
using System.Linq;
using Nox.Solution.Events;
using Nox.Solution.Schema;
using Nox.Solution.Exceptions;
using Nox.Solution.Macros;
using Nox.Solution.Utils;
using System.Collections.Generic;
using System;

namespace Nox.Solution
{
    public class NoxSolutionBuilder
    {
        private const string DesignFolderBestPractice = "Best practice is to create a '.nox' folder in your project or solution folder and in there a 'design' folder which contains your <solution-name>.solution.nox.yaml.";

        private string? _yamlFilePath;

        private IDictionary<string,Func<TextReader>>? _yamlFilesAndContent;

        private string? _rootFileAndContentKey;

        private bool _mustThrowIfYamlNotFound = true;

        private EnvironmentVariableValueProvider _environmentVariableValueProvider = new (new EnvironmentProvider());

        public static NoxSolution? Instance { get; internal set; }

        public delegate void ResolveSecretsEventHandler(object sender, INoxSolutionSecretsEventArgs args);
        public event ResolveSecretsEventHandler? OnResolveSecretsEvent;
        
        public NoxSolutionBuilder UseYamlFile(string yamlFilePath)
        {
            _yamlFilePath = Path.GetFullPath(yamlFilePath);
            return this;
        }

        public NoxSolutionBuilder UseYamlFilesAndContent(IDictionary<string, Func<TextReader>> yamlFilesAndContent)
        {
            _yamlFilesAndContent = yamlFilesAndContent
                .ToDictionary(kv => Path.GetFileName(kv.Key), kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            return this;
        }

        public NoxSolutionBuilder UseEnvironmentProvider(IEnvironmentProvider provider)
        {
            _environmentVariableValueProvider = new EnvironmentVariableValueProvider(provider);
            return this;
        }

        public NoxSolutionBuilder AllowMissingSolutionYaml()
        {
            _mustThrowIfYamlNotFound = false;
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

            if (_yamlFilesAndContent == null) return new NoxSolution();

            var config = ResolveAndLoadConfiguration();

            config.Validate();
            Instance = config;
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
                DeterministicThrow("No yaml file(s) specified or found");
                return;
            }

            if (_rootFileAndContentKey is null)
            {
                var solutionFiles = _yamlFilesAndContent
                    .Where(kv => kv.Key.ToLower().Contains(".solution.nox.yaml"))
                    .Select(kv => kv.Key)
                    .ToArray();

                if (solutionFiles.Length == 0)
                {
                    DeterministicThrow("No solution yaml file(s) specified or found.");
                }

                if (solutionFiles.Length > 1)
                {
                    var fileNames = string.Join(",", solutionFiles);
                    throw new NoxSolutionConfigurationException($"Multiple solution yaml file(s) specified or found. [{fileNames}]");
                }

                _rootFileAndContentKey = solutionFiles[0];
            }
        }

        private IDictionary<string, Func<TextReader>>? LoadFromFileSystem()
        {
            //If a yaml root configuration has not been specified, search for one in the .nox/design folder in the solution root folder
            if (string.IsNullOrWhiteSpace(_yamlFilePath))
            {
                var rootYamlFile = FindRootYamlFile();
                if (string.IsNullOrEmpty(rootYamlFile)) return null;
                _yamlFilePath = Path.GetFullPath(FindRootYamlFile());            }

            if (!File.Exists(_yamlFilePath))
            {
                DeterministicThrow($"Nox root yaml configuration file ({_yamlFilePath}) not found! Have you created a Nox yaml configuration for your solution? {DesignFolderBestPractice}");
                return null;
            }

            var path = Path.GetDirectoryName(_yamlFilePath);

            var files = Directory.GetFiles(path!, "*.yaml", SearchOption.AllDirectories);

            if (files.Select(f => Path.GetFileName(f).ToLower()).Distinct().Count() < files.Length)
            {
                files = Directory.GetFiles(path!, "*.yaml", SearchOption.TopDirectoryOnly);
            }

            _rootFileAndContentKey = Path.GetFileName(_yamlFilePath);

            return files.ToDictionary(
                f => Path.GetFileName(f),
                f => new Func<TextReader>(() => new StreamReader(f)),
                StringComparer.OrdinalIgnoreCase
            );
        }

        private NoxSolution ResolveAndLoadConfiguration()
        {
            var yamlResolver = new YamlReferenceResolver(_yamlFilesAndContent!, _rootFileAndContentKey!);

            var yaml = yamlResolver.ResolveReferences();

            var noxSolutionBasicsOnly = NoxSolutionBasicsOnlySerializer.Deserialize(yaml);

            var secretsConfig = noxSolutionBasicsOnly.Infrastructure?.Security?.Secrets;

            var variables = new Dictionary<string, string?>();

            // Resolve Secrets
            var secretVariables = yamlResolver.GetVariables("secrets");

            if (secretVariables.Any())
            {
                if (secretsConfig is null)
                {
                    throw new NoxSolutionConfigurationException("The solution yaml references secrets but no secrets provider is defined in Infrastructure.Security.Secrets.");
                }

                var resolveSecretsArgs = new NoxSolutionSecretsEventArgs(secretsConfig, secretVariables);
 
                OnResolveSecretsEvent?.Invoke(this, resolveSecretsArgs);

                resolveSecretsArgs.Secrets?
                    .ToList()
                    .ForEach(kv => variables[kv.Key] = kv.Value);
            }

            // Resolve variables
            var envVariables = yamlResolver.GetVariables("env");
            
            if (envVariables.Any())
            {
                _environmentVariableValueProvider.Resolve(envVariables, noxSolutionBasicsOnly.Variables)
                    .ToList()
                    .ForEach(kv => variables[kv.Key] = kv.Value);
            }

            // Replace Variables
            yaml = yamlResolver.ResolveVariables(variables);

            // Validate and deserialize
            var config = NoxSchemaValidator.Deserialize<NoxSolution>(yaml);

            EvaluateCalculatedProperties(config);

            config.RootYamlFile = _yamlFilePath;

            return config;
        }

        private void EvaluateCalculatedProperties(NoxSolution config)
        {
            if (config.Domain != null)
            {
                foreach (var entity in config.Domain.Entities)
                {
                    entity.IsOwnedEntity = config.IsOwnedEntity(entity);
                }
            }
        }

        private static string? FindSolutionRoot()
        {
            var path = new DirectoryInfo(Directory.GetCurrentDirectory());
            var startPath = path;

            while (path != null)
            {
                //Look for a git repo
                if (path.GetDirectories(".git").Any())
                {
                    return path.FullName;
                }
                //Look for a mercurial repo
                if (path.GetDirectories(".gh").Any())
                {
                    return path.FullName;
                }
                //look for a subversion repo
                if (path.GetDirectories(".svn").Any())
                {
                    return path.FullName;
                }
                path = path.Parent;
            }

            return startPath.FullName;
        }

        private static string? FindNoxDesignFolder(string rootPath)
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
                DeterministicThrow("Unable to locate the root folder of your solution. Have you created a git repo for your solution?");
                return "";
            }

            designFolder = FindNoxDesignFolder(solutionRoot!);
            if (string.IsNullOrWhiteSpace(designFolder))
            {
                DeterministicThrow($"Unable to locate a .nox/design folder in your solution folder ({solutionRoot}). {DesignFolderBestPractice}");    
                return "";
            }

            rootYaml = FindSolutionYamlFile(designFolder!);
            if (rootYaml == null)
            {
                DeterministicThrow("Unable to locate a *.solution.nox.yaml file, searched current folder, <current>/.nox/design and <solution root>/.nox/design");
                return "";
            }

            return rootYaml;
        }

        private static string? FindSolutionYamlFile(string folder)
        {
            var solutionYamlFiles = Directory.GetFiles(folder, "*.solution.nox.yaml");
            if (solutionYamlFiles.Length > 1)
            {
                throw new NoxSolutionConfigurationException($"Found more than one *.solution.nox.yaml file in folder ({folder}). {DesignFolderBestPractice}");
            }

            if (solutionYamlFiles.Length == 1) return solutionYamlFiles[0];

            return null;
        }
        
        private void DeterministicThrow(string message)
        {
            if (_mustThrowIfYamlNotFound)
            {
                throw new NoxSolutionConfigurationException(message);
            }
        }

    }
    
    
}