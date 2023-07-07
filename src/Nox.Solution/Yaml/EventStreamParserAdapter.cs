using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace Nox.Solution.Yaml;

public class EventStreamParserAdapter: IParser
{
    private readonly IEnumerator<ParsingEvent> _enumerator;
    
    public EventStreamParserAdapter(IEnumerable<ParsingEvent> events)
    {
        _enumerator = events.GetEnumerator();
    }
    
    public ParsingEvent Current => _enumerator.Current!;

    public bool MoveNext()
    {
        return _enumerator.MoveNext();
    }
}