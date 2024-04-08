using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using ETLBox.Json;
using Nox.Integration.Abstractions.Enums;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Uri = System.Uri;

namespace Nox.Integration.Adapters.Json;

public class JsonFileReceiveAdapter: INoxFileReceiveAdapter
{
    private Uri? _uri;
    private string? _filePath;
    private FileAdapterUriKind? _uriKind;

    //private readonly IReadOnlyList<NoxSimpleTypeDefinition> _attributes;

    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.File;

    //public IReadOnlyList<NoxSimpleTypeDefinition> Attributes => _attributes;
    
    public JsonFileReceiveAdapter(string filename, string baseUri)
    {
        ParseUri(baseUri, filename);
        //_attributes = attributes;
    }

    public void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        throw new NotImplementedException();
    }

    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource => GetDataFlowSource();

    private IDataFlowExecutableSource<ExpandoObject> GetDataFlowSource()
    {
        if (_uriKind == FileAdapterUriKind.Url)
        {
            switch (_uri!.Scheme)
            {
                case "file":
                    return new JsonSource
                    {
                        ResourceType = ResourceType.File,
                        Uri = _uri.AbsolutePath
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
                default:
                    throw new NotImplementedException($"Uri scheme {_uri.Scheme} has not been implemented." );
            }
        }

        return new JsonSource
        {
            ResourceType = ResourceType.File,
            Uri = _filePath
        };
    }

    private void ParseUri(string baseUri, string filename)
    {
        if (Uri.TryCreate(baseUri, UriKind.Absolute, out var baseUriResult))
        {
            _uri = new Uri(baseUriResult, filename);
            _uriKind = FileAdapterUriKind.Url;
            return;
        }

        _filePath = Path.Combine(baseUri, filename);
        _uriKind = FileAdapterUriKind.FilePath;
    }

}