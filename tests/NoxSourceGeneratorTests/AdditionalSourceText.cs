using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace NoxSourceGeneratorTests;

public class AdditionalSourceText: AdditionalText
{
    private readonly string _path;
    private readonly string _content;
    
    public AdditionalSourceText(string content, string path)
    {
        _content = content;
        _path = path;
    }
    
    public override SourceText GetText(CancellationToken cancellationToken = new CancellationToken())
    {
        return SourceText.From(_content);
    }

    public override string Path => _path;
}