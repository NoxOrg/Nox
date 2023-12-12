using System.Dynamic;
using ETLBox;
using ETLBox.Json;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Types;
using Uri = System.Uri;

namespace Nox.Integration.Json;

public class JsonFileReceiveAdapter: INoxFileReceiveAdapter
{
    private readonly Uri _uri;

    private readonly List<NoxSimpleTypeDefinition> _attributes;

    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.File;

    public List<NoxSimpleTypeDefinition> Attributes => _attributes;
    
    public JsonFileReceiveAdapter(Uri uri, List<NoxSimpleTypeDefinition> attributes)
    {
        _uri = uri;
        _attributes = attributes;
    }
    
    public void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        throw new NotImplementedException();
    }

    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource => GetDataFlowSource();


    private IDataFlowExecutableSource<ExpandoObject> GetDataFlowSource()
    {
        switch (_uri.Scheme)
        {
            case "file":
                return new JsonSource
                {
                    ResourceType = ResourceType.File,
                    Uri = _uri.ToString()
                };
            case "https":
                return new JsonSource
                {
                    ResourceType = ResourceType.Http,
                    Uri = _uri.ToString()
                };
            case "blob":
            {
                return new JsonSource
                {
                    ResourceType = ResourceType.AzureBlob,
                    Uri = _uri.ToString()
                };
            }
        }

        throw new NotImplementedException($"Uri scheme {_uri.Scheme} has not been implemented." );
    }

}