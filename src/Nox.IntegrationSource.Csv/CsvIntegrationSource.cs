using System.Dynamic;
using System.Globalization;
using CsvHelper.Configuration;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Nox.Integration;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Solution;
using Nox.Solution.Builders;
using SqlKata.Compilers;

namespace Nox.IntegrationSource.File;

public class CsvIntegrationSource: IIntegrationSource
{
    private readonly string _name;
    private readonly Uri _sourceUri;
    private readonly string? _sourcePath;
    
    public string Name => _name;
    
    public string Type => IntegrationSourceTypeNames.Csv;

    public Compiler SqlCompiler { get; } = null!;

    public CsvIntegrationSource(Solution.IntegrationSource sourceDefinition, DataConnection dataConnectionDefinition)
    {
        _name = sourceDefinition.Name;
        var uriBuilder = new NoxUriBuilder(dataConnectionDefinition, "file", $"infrastructure, dependencies, dataConnection: {dataConnectionDefinition.Name}", sourceDefinition.FileOptions!.Filename);
        _sourceUri = uriBuilder.Uri;
        _sourcePath = uriBuilder.AbsolutePath;
    }
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource()
    {
        var dataFlowExecutableSource = new CsvSource<ExpandoObject>
        {
            Configuration = new CsvConfiguration(CultureInfo.InvariantCulture),
            ResourceType = _sourceUri.Scheme.ToLower() switch
            {
                "http" => ResourceType.Http,
                "https" => ResourceType.Http,
                "blob" => ResourceType.AzureBlob,
                "file" => ResourceType.File,
                "filesystem" => ResourceType.File,
                _ => throw new NotImplementedException( $"Resource type {_sourceUri.Scheme} has not been implemented on CSV integration sources.")
            },
        };
        
        dataFlowExecutableSource.Uri = dataFlowExecutableSource.ResourceType == ResourceType.File ? _sourcePath : _sourceUri.ToString();

        return dataFlowExecutableSource;
    }
}