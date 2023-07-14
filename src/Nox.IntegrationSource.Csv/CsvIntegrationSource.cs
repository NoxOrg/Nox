using System.Dynamic;
using System.Globalization;
using CsvHelper.Configuration;
using ETLBox.Connection;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Nox.Integration;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Integration.Exceptions;
using Nox.Solution;
using Nox.Solution.Builders;
using SqlKata.Compilers;

namespace Nox.IntegrationSource.File;

public class CsvIntegrationSource: ISource
{
    private readonly string _name;
    private readonly Uri _sourceUri;
    
    public string Name => _name;
    
    public string Type => SourceType.Csv;

    public Compiler SqlCompiler { get; } = null!;

    public CsvIntegrationSource(Solution.IntegrationSource sourceConfig, DataConnection dataConnection)
    {
        _name = sourceConfig.Name;
        var uriBuilder = new NoxUriBuilder(dataConnection, "file", $"infrastructure, dependencies, dataConnection: {dataConnection.Name}");
        _sourceUri = uriBuilder.Uri;
    }
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource()
    {
        var dataFlowExecutableSource = new CsvSource<ExpandoObject>
        {
            Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        };

        dataFlowExecutableSource.ResourceType = _sourceUri.Scheme.ToLower() switch
        {
            "http" => ResourceType.Http,
            "https" => ResourceType.Http,
            "blob" => ResourceType.AzureBlob,
            "file" => ResourceType.File,
            "filesystem" => ResourceType.File,
            _ => throw new NotImplementedException( $"Resource type {_sourceUri.Scheme} has not been implemented on CSV integration sources.")
        };
        dataFlowExecutableSource.Uri = _sourceUri.ToString();
        return dataFlowExecutableSource;
    }

    public void ApplyMergeInfo(IntegrationMergeStates lastMergeInfo, string[] dateTimeStampColumns, string[] targetColumns)
    {
        throw new NotImplementedException();
    }
}