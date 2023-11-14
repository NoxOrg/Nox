using Nox.Solution.Schema;
using Nox.Yaml.Parser;
using Nox.Yaml.Exceptions;
using Nox.Yaml.Extensions;
using System.Reflection;
using Nox.Yaml.Serialization;
using Nox.Yaml.VariableProviders.Environment;
using Nox.Yaml.Validation;
using System.Reflection.Emit;

namespace Nox.Yaml;

public class YamlConfigurationReader<T> : YamlConfigurationReader<T, T>
    where T : YamlConfigNode<T, T>, new () {}


public class YamlConfigurationReader<TFullType, TVarsOnlyType> 
    where TFullType : YamlConfigNode<TFullType,TFullType>, new()
    where TVarsOnlyType : class, new()
{
    private string? _yamlFilePath = null!;

    private string _filePattern = "*.yaml";

    private readonly HashSet<string> _searchPaths = new(StringComparer.OrdinalIgnoreCase);

    private IDictionary<string, Func<TextReader>>? _yamlFilesAndContent;

    private string? _rootFileAndContentKey;

    private bool _mustThrowIfYamlNotFound = true;

    public static TFullType? Instance { get; internal set; }

    private EnvironmentVariableValueProvider _environmentVariableValueProvider = new(new EnvironmentProvider());

    private EnvironmentVariableDefaultsProvider<TVarsOnlyType>? _environmentVariableDefaultsProvider = null!;

    private SecretsVariableValueProvider<TVarsOnlyType>? _secretVariableValueProvider = default!;


    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithFile(string yamlFilePath)
    {
        _yamlFilePath = Path.GetFullPath(yamlFilePath);
        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithYamlFilesAndContent(IDictionary<string, Func<TextReader>> yamlFilesAndContent)
    {
        _yamlFilesAndContent = yamlFilesAndContent
            .ToDictionary(kv => Path.GetFileName(kv.Key), kv => kv.Value, StringComparer.OrdinalIgnoreCase);

        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithSingleFileMatching(string fileNameOrPattern)
    {
        _filePattern = fileNameOrPattern;

        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithSearchPath(string path)
    {
        _searchPaths.Add(Path.GetFullPath(path));

        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithSearchFromRepositoryRoot(string subFolder)
    {
        var root = FindRepositoryRoot();
        if (root is not null)
        {
            _searchPaths.Add(Path.GetFullPath(Path.Combine(root, subFolder)));
        }
        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithSearchFromExecutionFolder(string subFolder)
    {
        var thisAssembly = Assembly.GetAssembly(typeof(YamlConfigurationReader<>));
        if (thisAssembly is not null)
        {
            var assemblyFolder = Path.GetDirectoryName(thisAssembly.Location);

            if (assemblyFolder is not null)
            {
                _searchPaths.Add(Path.GetFullPath(Path.Combine(assemblyFolder, subFolder)));
            }
        }
        return this;
    }

    public YamlConfigurationReader<TFullType,TVarsOnlyType> WithEnvironmentVariableProvider(EnvironmentVariableValueProvider provider)
    {
        _environmentVariableValueProvider = provider;
        return this;
    }

    public YamlConfigurationReader<TFullType, TVarsOnlyType> WithEnvironmentVariableDefaultsProvider(
        EnvironmentVariableDefaultsProvider<TVarsOnlyType> environmentVariableDefaultsProvider)
    {
        _environmentVariableDefaultsProvider = environmentVariableDefaultsProvider;
        return this;
    }
    public YamlConfigurationReader<TFullType, TVarsOnlyType> WithSecretsVariableValueProvider(
        SecretsVariableValueProvider<TVarsOnlyType> secretVariableValueProvider)
    {
        _secretVariableValueProvider = secretVariableValueProvider;
        return this;
    }

    public YamlConfigurationReader<TFullType, TVarsOnlyType> AllowMissingSolutionYaml()
    {
        _mustThrowIfYamlNotFound = false;
        return this;
    }

    public TFullType Read()
    {
        ResolveAndValidateFilesAndContent();

        Instance = _yamlFilesAndContent is null 
            ? new TFullType() 
            : ResolveAndLoadConfiguration();
        
        SetAllDefaults(Instance);
        
        InitializeAll(Instance);

        ValidateAll(Instance);

        return Instance;
    }

    private static void SetAllDefaults(TFullType instance)
    {
        object topNode = instance;

        Type configNodeType = typeof(YamlConfigNode<,>);

        instance.WalkObjectTypes((prop, type, obj, parent) => {

            var baseType = type.BaseType;

            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == configNodeType)
            {
                var method = type.GetMethod(nameof(YamlConfigNode<object,object>.SetDefaults));
                
                method?.Invoke(obj, new object[] { topNode, parent, prop });
            }
        });
    }

    private static void InitializeAll(TFullType instance)
    {
        object topNode = instance;

        Type configNodeType = typeof(YamlConfigNode<,>);

        instance.WalkObjectTypes((prop, type, obj, parent) => {

            var baseType = type.BaseType;

            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == configNodeType)
            {
                var method = type.GetMethod(nameof(YamlConfigNode<object, object>.Initialize));

                method?.Invoke(obj, new object[] { topNode, parent, prop });
            }
        });
    }

    private static void ValidateAll(TFullType instance)
    {
        object topNode = instance;

        Type configNodeType = typeof(YamlConfigNode<,>);

        var allValidationResults = new ValidationResult();

        instance.WalkObjectTypes((prop, type, obj, parent) => {

            var baseType = type.BaseType;

            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == configNodeType)
            {
                var method = type.GetMethod(nameof(YamlConfigNode<object, object>.Validate));

                var result = method?.Invoke(obj, new object[] { topNode, parent, prop });

                if (result is ValidationResult validationResult)
                {
                    allValidationResults.Errors.AddRange(validationResult.Errors);
                }
            }
        });

        if (!allValidationResults.IsValid)
        {
            throw new NoxYamlValidationException(allValidationResults.Errors);
        }
    }

    private TFullType ResolveAndLoadConfiguration()
    {
        var yamlRefResolver = new YamlReferenceResolver(_yamlFilesAndContent!, _rootFileAndContentKey!);

        var variablesOnlyObject = VariablesDeserializer.Deserialize<TVarsOnlyType>(yamlRefResolver.ToYamlString());
        
        var variables = new Dictionary<string, string?>();

        // Resolve Secrets
        var secretVariables = yamlRefResolver.GetVariables(Constants.SecretVariablesKey);

        if (secretVariables.Any() && _secretVariableValueProvider is not null && variablesOnlyObject is not null)
        {
            _secretVariableValueProvider.Resolve(variablesOnlyObject, secretVariables)
                .ToList()
                .ForEach(kv => variables[kv.Key] = kv.Value);
        }

        // Resolve variables
        var envVariables = yamlRefResolver.GetVariables(Constants.EnvironmentVariablesKey);

        if (envVariables.Any() && variablesOnlyObject is not null)
        {
            _environmentVariableValueProvider.Resolve(envVariables, _environmentVariableDefaultsProvider?.Resolve(variablesOnlyObject))
                .ToList()
                .ForEach(kv => variables[kv.Key] = kv.Value);
        }

        // Replace Variables
        yamlRefResolver.ResolveVariables(variables);

        // Validate and deserialize
        var config = NoxSchemaValidator.Deserialize<TFullType>(yamlRefResolver);

        return config;
    }

    private void ResolveAndValidateFilesAndContent()
    {
        _yamlFilesAndContent ??= LoadFromFileSystem();

        if (_yamlFilesAndContent is null || _yamlFilesAndContent.Count == 0)
        {
            var fileName = _yamlFilePath ?? _filePattern;

            DeterministicThrow($"No yaml file(s) matching [{fileName}] was found.");
            return;
        }

        if (_rootFileAndContentKey is null)
        {
            var match = _yamlFilePath ?? _filePattern.WildCardToRegex();

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
                throw new NoxYamlException($"Multiple solution yaml file(s) specified or found. [{fileNames}]");
            }

            _rootFileAndContentKey = solutionFiles[0];
        }
    }

    private IDictionary<string, Func<TextReader>>? LoadFromFileSystem()
    {
        //If a yaml root configuration has not been specified, search for one in the .nox/design folder in the solution root folder
        if (string.IsNullOrWhiteSpace(_yamlFilePath))
        {
            var rootYamlFile = FindRootYamlFile(_searchPaths, _filePattern);

            if (string.IsNullOrEmpty(rootYamlFile)) return null;
            
            _yamlFilePath = Path.GetFullPath(rootYamlFile);
        }

        if (!File.Exists(_yamlFilePath))
        {
            DeterministicThrow($"The file [{_yamlFilePath}] was not found.");
            return null;
        }

        var path = Path.GetDirectoryName(_yamlFilePath);

        var files = Directory.GetFiles(path!, "*.yaml", SearchOption.AllDirectories);

        // If we have duplicates in the directory tree, just include files in the top folder
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

    private static string? FindRootYamlFile(HashSet<string> searchPaths, string filePattern)
    {
        foreach (var path in searchPaths)
        {
            if (Directory.Exists(path))
            {
                var file = FindYamlFile(path, filePattern);

                if (file is not null)
                {
                    return file;
                }
            }
        }
        return null;
    }

    private static string? FindYamlFile(string folder, string pattern)
    {
        var solutionYamlFiles = Directory.GetFiles(folder, pattern);

        if (solutionYamlFiles.Length > 1)
        {
            throw new NoxYamlException($"Found more than one *.solution.nox.yaml file in folder ({folder}).");
        }

        if (solutionYamlFiles.Length == 1) return solutionYamlFiles[0];

        return null;
    }


    private static string? FindRepositoryRoot()
    {
        var path = new DirectoryInfo(Directory.GetCurrentDirectory());

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
        return null;
    }

    private void DeterministicThrow(string message)
    {
        if (_mustThrowIfYamlNotFound)
        {
            throw new NoxYamlException(message);
        }
    }

}

