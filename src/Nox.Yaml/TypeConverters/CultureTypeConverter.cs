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
    private static readonly ImmutableSortedDictionary<string,Culture> CultureCodeToCulture = Enum.GetValues(typeof(Culture))
        .Cast<Culture>()
        .ToImmutableSortedDictionary(x =>
            {
                var field = x.GetType().GetField(x.ToString())!;
                var attribute = field.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
                return attribute?.DisplayName ?? x.ToString();
            }, 
            x => x);
    public bool Accepts(Type type)
    {
        return type == typeof(Culture);
    }

    public object? ReadYaml(IParser parser, Type type)
    {
        if(parser.Current?.GetType() == typeof(Scalar))
        {
            var scalar = parser!.Consume<Scalar>();
            if (CultureCodeToCulture.TryGetValue(scalar.Value, out var cultureValue))
            {
                return cultureValue;
            }
            else
            {
                throw new InvalidOperationException($"Unknown culture code: {scalar.Value}");
            }
        } 
        
        if (parser.TryConsume<MappingStart>(out _))
        {
            return ParseMapping(parser); // We're parsing a YAML object
        }

        if (parser.TryConsume<SequenceStart>(out _))
        {
            return ParseSequence(parser); // We're parsing a YAML array
        }

        throw new InvalidOperationException("Expected a YAML object or array");
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        throw new NotImplementedException();
    }
    
    private static Culture ParseMapping(IParser parser)
    {
        Culture culture = default;

        // Read all until we reached the end of the YAML object
        while (!parser.Accept<MappingEnd>(out _))
        {
            var scalar = parser.Consume<Scalar>();
            if (CultureCodeToCulture.TryGetValue(scalar.Value, out var cultureValue))
            {
                culture = cultureValue;
            }
            else
            {
                throw new InvalidOperationException($"Unknown culture code: {scalar.Value}");
            }
        }
        
        // parser.Accept(out MappingEnd _);
        // parser.Consume<Scalar>();
        
        

        // Consume the mapping end token
        parser.MoveNext();
        return culture;
    }
    
    private static Culture ParseSequence(IParser parser)
    {
        Culture culture = default;

        // Read all the array values until we reach the end of the YAML array
        while (!parser.Accept<SequenceEnd>(out _))
        {
            var scalar = parser.Consume<Scalar>();

            if (CultureCodeToCulture.TryGetValue(scalar.Value, out var cultureValue))
            {
                culture = cultureValue;
            }
            else
            {
                throw new InvalidOperationException("Invalid key value mapping: " + scalar.Value);
            }
        }

        // Consume the mapping end token
        parser.MoveNext();
        return culture;
    }

}