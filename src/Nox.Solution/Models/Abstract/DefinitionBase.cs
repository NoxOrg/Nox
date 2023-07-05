using System;
#if !NETSTANDARD
using System.Text.Json.Serialization;
#endif

namespace Nox.Solution
{

    public abstract class DefinitionBase
    {
#if !NETSTANDARD
        [JsonPropertyName("$ref")] 
#endif
        public Uri? Ref { get; set; }
        
    }
}