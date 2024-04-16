using Nox.Integration.Abstractions.Enums;

namespace Nox.Integration.Adapters.Json;

public class JsonFileSourceAdapterBase
{
    internal Uri? BaseUri;
    internal string? BaseFilePath;
    internal FileAdapterUriKind? BaseUriKind;
    
    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.File;

    public JsonFileSourceAdapterBase(string filename, string baseUri)
    {
        ParseUri(baseUri, filename);
    }
    
    private void ParseUri(string baseUri, string filename)
    {
        if (Uri.TryCreate(baseUri, UriKind.Absolute, out var baseUriResult))
        {
            BaseUri = new Uri(baseUriResult, filename);
            BaseUriKind = FileAdapterUriKind.Url;
            return;
        }

        BaseFilePath = Path.Combine(baseUri, filename);
        BaseUriKind = FileAdapterUriKind.FilePath;
    }
}