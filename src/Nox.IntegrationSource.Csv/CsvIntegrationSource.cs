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
using SqlKata.Compilers;

namespace Nox.IntegrationSource.File;

public class CsvIntegrationSource: ISource
{
    private readonly string _name;
    private readonly ResourceType _resourceType;
    private readonly DataConnection _dataConnection;
    private readonly IntegrationSourceFileOptions _fileOptions;
    
    public string Name => _name;
    
    public string Type => SourceType.Csv;

    public Compiler SqlCompiler { get; } = null!;

    public CsvIntegrationSource(Solution.IntegrationSource sourceConfig, DataConnection dataConnection)
    {
        _name = sourceConfig.Name;
        _dataConnection = dataConnection;
        _fileOptions = sourceConfig.FileOptions!;
        var sourceUri = new Uri(dataConnection.ServerUri);
        _resourceType = sourceUri.Scheme.ToLower() switch
        {
            "http" => ResourceType.Http,
            "https" => ResourceType.Http,
            "blob" => ResourceType.AzureBlob,
            "file" => ResourceType.File,
            _ => throw new NoxIntegrationException("Invalid Csv source specified in uri scheme. Available options are http, https, blob, file")
        };
    }
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource()
    {
        var dataFlowExecutableSource = new CsvSource<ExpandoObject>
        {
            Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        };
        
        dataFlowExecutableSource.ResourceType = _resourceType;
        
        switch (_resourceType)
        {
            case ResourceType.File:
                var uri = new Uri(_dataConnection.ServerUri);
                
                var filePath = Path.Combine(_folderPath, _sourceConfig.FileOptions!.Filename);
                
                break;
            
            case ResourceType.Http:
                dataFlowExecutableSource.Uri = _dataConnection.ServerUri; 
                break;
            
            case ResourceType.AzureBlob:
                throw new NotImplementedException();
        }

        return dataFlowExecutableSource;
    }

    public void ApplyMergeInfo(IntegrationMergeStates lastMergeInfo, string[] dateTimeStampColumns, string[] targetColumns)
    {
        throw new NotImplementedException();
    }
}