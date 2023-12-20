using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Nox.Generator.Tests.Common;

public class CompileTests : IClassFixture<GeneratorFixture>
{
    public readonly string BasePath = "../../../Generated/";
    private readonly ITestOutputHelper _testOutputHelper;

    public CompileTests(ITestOutputHelper testOutputHelper, GeneratorFixture generatorFixture)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("./files/yaml/design/api/clientapi.solution.nox.yaml," +
                "./files/yaml/design/api/Entities/country.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/countrylocalname.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/countrybarcode.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/ratingprogram.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/countryqualityoflifeindex.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/store.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/workplace.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/store-owner.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/store-license.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/currency.entity.nox.yaml," +
                "./files/yaml/design/api/Entities/tenant.entity.nox.yaml")]
    [InlineData("./files/yaml/design/test.solution.nox.yaml")]
    public void Generated_Files_Should_Be_Compiled_Successfully(string sources)
    {
        var sourceArray = sources.Split(',');
        
        var result = GeneratorFixture.GenerateSourceCodeFor(sourceArray);
        var references = GetReferences().ToList();
        _testOutputHelper.WriteLine($"References count: {references.Count}");

        var compilation = CreateCompilation(result.Sources, references);

        var diagnostics = compilation.GetDiagnostics().Where(x => x.Severity == DiagnosticSeverity.Error).ToList();

        _testOutputHelper.WriteLine("Diagnostics count: " + diagnostics.Count);
        foreach (var diagnostic in diagnostics)
        {
            _testOutputHelper.WriteLine(diagnostic.ToString());
            _testOutputHelper.WriteLine(diagnostic.Location.SourceTree?.ToString() ?? "No source tree");
            _testOutputHelper.WriteLine(new string('*', 120));
        }

        if (diagnostics.Count > 0)
            GenerateAllFiles(result.Sources);

        diagnostics
            .Should()
            .BeEmpty();

    }

    private static CSharpCompilation CreateCompilation(IDictionary<string, string> sources,
        IEnumerable<MetadataReference> references)
    {
        var globalUsingFileContent =
            @"global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::Microsoft.AspNetCore.Builder;";
        var globalUsingFile = "0.GlobalUsing.g.cs";

        sources.Add(globalUsingFile, globalUsingFileContent);
        return CSharpCompilation.Create(
            assemblyName: "compilation",
            syntaxTrees: sources.Select(source =>
                CSharpSyntaxTree.ParseText(source.Value, new CSharpParseOptions(LanguageVersion.CSharp11))),
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }

    private static IEnumerable<MetadataReference> GetReferences()
    {
        var referencePaths = new HashSet<string>();

        var references = new List<MetadataReference>();

        AddMetadataReferenceFromDlls(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), referencePaths, references);

        AddMetadataReferenceFromDlls(Path.GetDirectoryName(typeof(IServiceCollection).Assembly.Location)!, referencePaths, references);

        AddMetadataReferenceFromDlls(Path.GetDirectoryName(typeof(JsonDocument).Assembly.Location)!, referencePaths, references);
        
        AddMetadataReferenceFromDlls(Path.GetDirectoryName(typeof(System.ComponentModel.DataAnnotations.DataTypeAttribute).Assembly.Location)!, referencePaths, references);

        AddMetadataReferenceFromDlls(Path.GetDirectoryName(typeof(System.ComponentModel.Component).Assembly.Location)!, referencePaths, references);

        return references;
    }

    private static void AddMetadataReferenceFromDlls(string executingPath, HashSet<string> referencePaths, List<MetadataReference> references)
    {
        var dllFiles = Directory.GetFiles(executingPath, "*.dll");
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

    private void GenerateAllFiles(IDictionary<string, string> sources)
    {
        if (!Directory.Exists(BasePath))
        {
            Directory.CreateDirectory(BasePath);
        }
        foreach (var source in sources)
        {
            var path = Path.Combine(BasePath, source.Key);
            var directoryPath = Path.GetDirectoryName(path);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath!);

            File.WriteAllText(path, source.Value);
        }
    }
}