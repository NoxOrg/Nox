using System.IO;
using System.Linq;
using Nox.Solution.Resolvers;
using Nox.Solution.Exceptions;
using Nox.Solution.Macros;
using Nox.Solution.Utils;

namespace Nox.Solution
{
    public class NoxSolutionBuilder
    {
        private const string DesignFolderBestPractice = "Best practice is to create a '.nox' folder in your solution folder and in there a 'design' folder which contains your <solution-name>.solution.nox.yaml";

        private string _yamlFilePath = string.Empty;

        private IMacroParser _environmentVariableParser = new EnvironmentVariableMacroParser(new EnvironmentProvider());

        public NoxSolutionBuilder UseYamlFile(string yamlFilePath)
        {
            _yamlFilePath = Path.GetFullPath(yamlFilePath);
            return this;
        }

        public NoxSolutionBuilder UseEnvironmentMacroParser(EnvironmentVariableMacroParser parser)
        {
            _environmentVariableParser = parser;
            return this;
        }

        public NoxSolution Build()
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

            var config = ResolveAndLoadConfiguration();
            config.Validate();

            return config;
        }

        private NoxSolution ResolveAndLoadConfiguration()
        {
            var resolver = new YamlReferenceResolver(_yamlFilePath);
            var yamlRef = resolver.ResolveReferences();
            var yaml = ExpandMacros(yamlRef);

            var config = NoxYamlSerializer.Deserialize<NoxSolution>(yaml);

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

        private string ExpandMacros(string yaml)
        {
            yaml = _environmentVariableParser.Parse(yaml);

            return yaml;
        }
    }
}