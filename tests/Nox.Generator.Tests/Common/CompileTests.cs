using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Nox.Generator.Tests.Common;

public class CompileTests
{
    private const string BasePath = "../../../Generated/";
    private readonly ITestOutputHelper _testOutputHelper;

    public CompileTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Generated_Files_Should_Be_Compiled_Successfully()
    {
        var fixture = new GeneratorFixture();

        var path = "files/yaml/design/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new(File.ReadAllText($"./{path}test.solution.nox.yaml"), $"{path}/test.solution.nox.yaml"),
        };

        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            generators: new[] { fixture.TestGenerator },
            additionalTexts: additionalFiles,
            driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

        driver = driver.RunGenerators(fixture.TestCompilation!);

        var result = driver.GetRunResult().Results[0];

        var references = GetReferences().ToList();
        _testOutputHelper.WriteLine("References count: " + references.Count);
        
        var compilation = CreateCompilation(result.GeneratedSources.Select(x => x.SourceText.ToString()), references);

        var diagnostics = compilation.GetDiagnostics().Where(x => x.Severity == DiagnosticSeverity.Error).ToList();

        _testOutputHelper.WriteLine("Diagnostics count: " + diagnostics.Count);
        foreach (var diagnostic in diagnostics)
        {
            _testOutputHelper.WriteLine(diagnostic.ToString());
            _testOutputHelper.WriteLine(diagnostic.Location.SourceTree?.ToString() ?? "No source tree");
            _testOutputHelper.WriteLine(new string('*', 120));
        }

        GenerateFiles(result);
        Assert.Empty(diagnostics);
    }

    private static CSharpCompilation CreateCompilation(IEnumerable<string> sources,
        IEnumerable<MetadataReference> references)
    {
        var globalUsingFile =
            @"global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;";

        sources = sources.Prepend(globalUsingFile);
        return CSharpCompilation.Create(
            assemblyName: "compilation",
            syntaxTrees: sources.Select(source =>
                CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview))),
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }

    private static IEnumerable<MetadataReference> GetReferences()
    {
        var executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var dllFiles = Directory.GetFiles(executingPath!, "*.dll");

        var referencePaths = new HashSet<string>();

        var references = new List<MetadataReference>();

        foreach (var dllFile in dllFiles)
        {
            if (referencePaths.Contains(Path.GetFileName(dllFile)))
                continue;
            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }

        dllFiles = Directory.GetFiles(Path.GetDirectoryName(typeof(IServiceCollection).Assembly.Location)!, "*.dll");

        foreach (var dllFile in dllFiles)
        {
            if (referencePaths.Contains(Path.GetFileName(dllFile)))
                continue;
            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }

        dllFiles = Directory.GetFiles(Path.GetDirectoryName(typeof(JsonDocument).Assembly.Location)!, "*.dll");

        foreach (var dllFile in dllFiles)
        {
            if (referencePaths.Contains(Path.GetFileName(dllFile)))
                continue;
            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }
        

        return references;
    }
    
    private static void GenerateFiles(GeneratorRunResult result)
    {
        if(!Directory.Exists(BasePath))
            Directory.CreateDirectory(BasePath);
        
        foreach (var generatedSource in result.GeneratedSources)
        {
            var fileContent = generatedSource.SourceText.ToString();
            File.WriteAllText($"{BasePath}{generatedSource.HintName}", fileContent);
        }
    }
}