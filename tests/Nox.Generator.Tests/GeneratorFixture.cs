using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Nox.Generator.Tests;

public class GeneratorFixture
{
    public Compilation TestCompilation { get; }
    public ISourceGenerator TestGenerator { get; }
    
    public GeneratorFixture()
    {
        var workspace = new AdhocWorkspace();
        var project = workspace.CurrentSolution.AddProject("MyProject", "MyProject.dll", LanguageNames.CSharp);

        project = project.AddDocument("Program.cs", File.ReadAllText("./files/Program.cs")).Project;

        var compilationOptions = project.CompilationOptions as CSharpCompilationOptions;
        compilationOptions = compilationOptions!
            .WithOutputKind(OutputKind.DynamicallyLinkedLibrary)
            .WithMetadataImportOptions(MetadataImportOptions.All);

        project = project.WithCompilationOptions(compilationOptions);

        TestCompilation = project.GetCompilationAsync().Result;
        
        var generator = new NoxCodeGenerator();
        TestGenerator = generator.AsSourceGenerator();
    }
}