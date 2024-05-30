using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nox.Generator.Application.Integration;

internal static class MappingConstants
{
    public static ReadOnlyDictionary<string, string[]> ValidMappings => new(new Dictionary<string, string[]>
    {
        {"integer", new []{"integer", "double", "bool", "string"}},
        {"double", new []{"integer", "double", "string"}},
        {"bool", new []{"integer", "bool", "string"}},
        {"string", new []{"integer", "double", "bool", "string", "date", "time", "datetime", "guid"}},
        {"date", new []{"string", "date", "datetime"}},
        {"time", new []{"string", "time"}},
        {"datetime", new []{"string", "date", "time", "datetime"}},
        {"guid", new []{"string", "guid"}}
    });
}
