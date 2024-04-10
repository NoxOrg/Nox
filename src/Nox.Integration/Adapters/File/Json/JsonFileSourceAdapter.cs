using System.Dynamic;
using ETLBox;
using ETLBox.Json;
using Nox.Integration.Abstractions.Enums;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Adapters.Json;

public class JsonFileSourceAdapter: JsonFileSourceAdapterBase, INoxFileSourceAdapter
{
    public JsonFileSourceAdapter(string filename, string baseUri): base(filename, baseUri)
    {
    }

    public void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        throw new NotImplementedException();
    }

    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource => GetDataFlowSource();

    private IDataFlowExecutableSource<ExpandoObject> GetDataFlowSource()
    {
        if (BaseUriKind == FileAdapterUriKind.Url)
        {
            switch (BaseUri!.Scheme)
            {
                case "file":
                    return new JsonSource
                    {
                        ResourceType = ResourceType.File,
                        Uri = BaseUri.AbsolutePath
                    };
                case "https":
                    return new JsonSource
                    {
                        ResourceType = ResourceType.Http,
                        Uri = BaseUri.ToString()
                    };
                case "blob":
                {
                    return new JsonSource
                    {
                        ResourceType = ResourceType.AzureBlob,
                        Uri = BaseUri.ToString()
                    };
                }
                default:
                    throw new NotImplementedException($"Uri scheme {BaseUri.Scheme} has not been implemented." );
            }
        }

        return new JsonSource
        {
            ResourceType = ResourceType.File,
            Uri = BaseFilePath
        };
    }
}

public class JsonFileSourceAdapter<TSource>: JsonFileSourceAdapterBase, INoxFileSourceAdapter<TSource>
    where TSource: INoxTransformDto
{
    public JsonFileSourceAdapter(string filename, string baseUri): base(filename, baseUri)
    {
    }

    public void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        throw new NotImplementedException();
    }

    public IDataFlowExecutableSource<TSource> DataFlowSource => GetDataFlowSource();

    private IDataFlowExecutableSource<TSource> GetDataFlowSource()
    {
        if (BaseUriKind == FileAdapterUriKind.Url)
        {
            switch (BaseUri!.Scheme)
            {
                case "file":
                    return new JsonSource<TSource>
                    {
                        ResourceType = ResourceType.File,
                        Uri = BaseUri.AbsolutePath
                    };
                case "https":
                    return new JsonSource<TSource>
                    {
                        ResourceType = ResourceType.Http,
                        Uri = BaseUri.ToString()
                    };
                case "blob":
                {
                    return new JsonSource<TSource>
                    {
                        ResourceType = ResourceType.AzureBlob,
                        Uri = BaseUri.ToString()
                    };
                }
                default:
                    throw new NotImplementedException($"Uri scheme {BaseUri.Scheme} has not been implemented." );
            }
        }

        return new JsonSource<TSource>
        {
            ResourceType = ResourceType.File,
            Uri = BaseFilePath
        };
    }
}