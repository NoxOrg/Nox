using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace Nox.Solution.Schema;

internal static class YamlWithLineInfo
{
    internal static Dictionary<string, (object? Value,YamlLineInfo LineInfo)> Parse(string yamlContent, YamlReferenceResolver yamlRefResolver)
    {
        var input = new StringReader(yamlContent);
        var parser = new YamlDotNet.Core.Parser(input);

        return ParseMapping(parser, yamlRefResolver);
    }

    private static Dictionary<string, (object? Value, YamlLineInfo LineInfo)> ParseMapping(IParser parser, YamlReferenceResolver yamlRefResolver)
    {
        var result = new Dictionary<string, (object? Value, YamlLineInfo LineInfo)>();

        while (parser.Current is not MappingEnd)
        {

            if (parser.Current is not Scalar keyEvent)
            {
                parser.MoveNext();
                continue;
            }

            if (!keyEvent.IsKey)
            {
                throw new Exception("Unsupported YAML structure: " + keyEvent);
            }

            parser.MoveNext();

            // Determine the type of the value and parse accordingly
            if (parser.Current is Scalar valueEvent)
            {
                var value = string.IsNullOrEmpty(valueEvent.Value) ? null : valueEvent.Value;

                result[keyEvent.Value] = new (value, yamlRefResolver.GetLineInfo(keyEvent.Start.Line));
            }
            else if (parser.Current is MappingStart)
            {
                var nestedMapping = ParseMapping(parser, yamlRefResolver);
             
                result[keyEvent.Value] = new (nestedMapping, yamlRefResolver.GetLineInfo(keyEvent.Start.Line));

            }
            else if (parser.Current is SequenceStart)
            {
                var objList = new List<object>();

                parser.MoveNext();

                if (parser.Current is Scalar)
                {
                    while (parser.Current is not SequenceEnd)
                    {
                        if (parser.Current is Scalar element) 
                            objList.Add(element.Value);
                        
                        parser.MoveNext();
                    }

                }
                else if (parser.Current is MappingStart)
                {
                    while (parser.Current is not SequenceEnd)
                    {
                        objList.Add(ParseMapping(parser, yamlRefResolver));
                        parser.MoveNext();
                    }
                }
                result[keyEvent.Value] = new( objList.ToArray(), yamlRefResolver.GetLineInfo(keyEvent.Start.Line));
            }
            else
            {
                throw new Exception("Unsupported YAML structure: " + parser.Current);
            }

            parser.MoveNext();
        }

        return result;
    }
}
