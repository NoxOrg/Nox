using System.Reflection;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Nox.Generator.Tests;

namespace Nox.Integration.Tests;

public class CompileTests
{

    [Fact]
    public void Generated_Files_Should_Compile_Successfully()
    {
        var _fixture = new GeneratorFixture();

        var path = "DatabaseIntegrationTests/Design/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}test.solution.nox.yaml"), $"{path}/test.solution.nox.yaml"),
        };

        // trackIncrementalGeneratorSteps allows to report info about each step of the generator
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            generators: new[] { _fixture.TestGenerator },
            additionalTexts: additionalFiles,
            driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

        // Run the generator
        driver = driver.RunGenerators(_fixture.TestCompilation!);

        var result = driver.GetRunResult().Results[0];
        
        var compilation = CreateCompilation(result.GeneratedSources.Select(x => x.SourceText.ToString()), GetReferences());

        var diagnostics = compilation.GetDiagnostics().Where(x => x.Severity == DiagnosticSeverity.Error).ToList();


        // ignore CS0246 errors
        diagnostics = diagnostics.Where(d => d.Id != "CS0246" && d.Id != "CS0103" && d.Id != "CS1061").ToList();
        
        Assert.Empty(diagnostics);
    }
    private static CSharpCompilation CreateCompilation(IEnumerable<string> sources, IEnumerable<MetadataReference> references)
    {
        return CSharpCompilation.Create(
            assemblyName: "compilation",
            syntaxTrees: sources.Select(source => CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.LatestMajor))),
            references: references,
            options: new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }
    
    private static IEnumerable<MetadataReference> GetReferences()
    {
            
        //Get all dll files in executing path and add them as references
        var executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
        //Get all dll files in executing path and add them as references
        var dllFiles = Directory.GetFiles(executingPath!, "*.dll");
        var references = new List<MetadataReference>();
            
        foreach (var dllFile in dllFiles)
        {
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }
            
        dllFiles = Directory.GetFiles( Path.GetDirectoryName(typeof(IServiceCollection).Assembly.Location)!, "*.dll");
            
        foreach (var dllFile in dllFiles)
        {
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }
            
        dllFiles = Directory.GetFiles( Path.GetDirectoryName(typeof(JsonDocument).Assembly.Location)!, "*.dll");
            
        foreach (var dllFile in dllFiles)
        {
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }
            
            
        return references;
    }
}