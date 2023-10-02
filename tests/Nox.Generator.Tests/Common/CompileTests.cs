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
global using global::System.Threading.Tasks;
global using global::Microsoft.AspNetCore.Builder;";

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
            if (!IsManagedAssembly(dllFile))
            {
                referencePaths.Add(Path.GetFileName(dllFile));
                continue;
            }

            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }

        dllFiles = Directory.GetFiles(Path.GetDirectoryName(typeof(IServiceCollection).Assembly.Location)!, "*.dll");

        foreach (var dllFile in dllFiles)
        {
            if (referencePaths.Contains(Path.GetFileName(dllFile)))
                continue;
            if (!IsManagedAssembly(dllFile))
            {
                referencePaths.Add(Path.GetFileName(dllFile));
                continue;
            }

            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }

        dllFiles = Directory.GetFiles(Path.GetDirectoryName(typeof(JsonDocument).Assembly.Location)!, "*.dll");

        foreach (var dllFile in dllFiles)
        {
            if (referencePaths.Contains(Path.GetFileName(dllFile)))
                continue;
            if (!IsManagedAssembly(dllFile))
            {
                referencePaths.Add(Path.GetFileName(dllFile));
                continue;
            }

            referencePaths.Add(Path.GetFileName(dllFile));
            references.Add(MetadataReference.CreateFromFile(dllFile));
        }


        return references;
    }

    private static bool IsManagedAssembly(string fileName)
    {
        using Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        using var binaryReader = new BinaryReader(fileStream);
        if (fileStream.Length < 64)
        {
            return false;
        }

        //PE Header starts @ 0x3C (60). Its a 4 byte header.
        fileStream.Position = 0x3C;
        uint peHeaderPointer = binaryReader.ReadUInt32();
        if (peHeaderPointer == 0)
        {
            peHeaderPointer = 0x80;
        }

        // Ensure there is at least enough room for the following structures:
        //     24 byte PE Signature & Header
        //     28 byte Standard Fields         (24 bytes for PE32+)
        //     68 byte NT Fields               (88 bytes for PE32+)
        // >= 128 byte Data Dictionary Table
        if (peHeaderPointer > fileStream.Length - 256)
        {
            return false;
        }

        // Check the PE signature.  Should equal 'PE\0\0'.
        fileStream.Position = peHeaderPointer;
        uint peHeaderSignature = binaryReader.ReadUInt32();
        if (peHeaderSignature != 0x00004550)
        {
            return false;
        }

        // skip over the PEHeader fields
        fileStream.Position += 20;

        const ushort pe32 = 0x10b;
        const ushort pe32Plus = 0x20b;

        // Read PE magic number from Standard Fields to determine format.
        var peFormat = binaryReader.ReadUInt16();
        if (peFormat != pe32 && peFormat != pe32Plus)
        {
            return false;
        }

        // Read the 15th Data Dictionary RVA field which contains the CLI header RVA.
        // When this is non-zero then the file contains CLI data otherwise not.
        ushort dataDictionaryStart = (ushort)(peHeaderPointer + (peFormat == pe32 ? 232 : 248));
        fileStream.Position = dataDictionaryStart;

        uint cliHeaderRva = binaryReader.ReadUInt32();
        if (cliHeaderRva == 0)
        {
            return false;
        }

        return true;
    }
}