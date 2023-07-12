using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Nox.Integration;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Solution;
using SqlKata.Compilers;

namespace Nox.IntegrationSource.File;

public class CsvIntegrationSource: ISource
{
    private readonly string _name;
    private readonly ResourceType _resourceType;
    
    protected CsvSource<ExpandoObject> _dataFlowExecutableSource = null!;

    public string Name => _name;
    
    public string Type => SourceType.Csv;
    
    public Compiler SqlCompiler { get; }

    public CsvIntegrationSource(Solution.IntegrationSource sourceConfig, DataConnection dataConnection)
    {
        _name = sourceConfig.Name;
        
    }
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource()
    {
        throw new NotImplementedException();
    }

    public void ApplyMergeInfo(IntegrationMergeStates lastMergeInfo, string[] dateTimeStampColumns, string[] targetColumns)
    {
        throw new NotImplementedException();
    }
}