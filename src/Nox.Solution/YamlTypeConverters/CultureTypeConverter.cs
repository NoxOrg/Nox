using System;
using System.Linq;
using Nox.Types;
using Nox.Types.Abstractions;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Nox.Solution.YamlTypeConverters;

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
        if (CultureCode.DisplayNames.TryGetValue(scalar.Value, out var cultureValue))
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
        var kvp = CultureCode.DisplayNames.FirstOrDefault(k => k.Value == culture);
        
        emitter.Emit(new MappingStart(null, null, false, MappingStyle.Block));
        
        emitter.Emit(new Scalar(null,kvp.Key));

        emitter.Emit(new MappingEnd());
    }
}