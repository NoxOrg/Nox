using System;
using System.Collections.Immutable;
using System.Linq;
using Nox.Yaml.Attributes;
using Nox.Yaml.Enums.CultureCode;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Nox.Types.Abstractions.TypeConverters;

public class CultureTypeConverter: IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(Culture);
    }

    public object? ReadYaml(IParser parser, Type type)
    {
        if (parser.Current?.GetType() != typeof(Scalar))
            throw new InvalidOperationException("Expected a YAML scalar");
        
        var scalar = parser!.Consume<Scalar>();
        if (Yaml.Constants.CultureCodes.TryGetValue(scalar.Value, out var cultureValue))
        {
            return cultureValue;
        }

        throw new InvalidOperationException($"Unknown culture code: {scalar.Value}");

    }

    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        if(value is null)
            return;

        Culture culture = (Culture)value;
        var kvp = Yaml.Constants.CultureCodes.FirstOrDefault(k => k.Value == culture);
        
        emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));
        
        emitter.Emit(new Scalar(null,kvp.Key));

        emitter.Emit(new MappingEnd());
    }
}