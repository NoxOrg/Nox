using Nox.Yaml.Attributes;
using System.Text;

namespace Nox.Lib;

public class ApiRouteMatcher
{

    private readonly string _routePattern;

    private readonly (int StartPos, int EndPos)[] _paramSpanCoords;

    private readonly (int StartPos, int EndPos)[] _segmentSpanCoords;

    private readonly string[] _paramKeys;

    private readonly Dictionary<string,object> _parameterDefaults;

    public ApiRouteMatcher(string pattern)
    {
        var patternSpan = pattern.AsSpan();
        
        var paramCount = ValidateAndCountParams(patternSpan);
        
        var segmentCount = paramCount;
        if (patternSpan[0] == '{') segmentCount--;
        if (patternSpan[pattern.Length-1] != '}') segmentCount++;

        _routePattern = pattern;
        _paramSpanCoords = new (int StartPos, int EndPos)[paramCount];
        _segmentSpanCoords = new (int StartPos, int EndPos)[segmentCount];
        _paramKeys = new string[paramCount]; 

        var paramIndex = 0;
        var segmentIndex = 0;
        var startParamPos = -1;

        for (var i = 0; i < patternSpan.Length; i++)
        {
            if (patternSpan[i] == '{')
            {
                startParamPos = i + 1;
                if (i > 0 && paramIndex > 0)
                {
                    _segmentSpanCoords[segmentIndex++] = 
                        new(_paramSpanCoords[paramIndex-1].EndPos+1,i);
                }
                else if (i > 0)
                {
                    _segmentSpanCoords[segmentIndex++] =
                        new(0, i);
                }
            }
            else if (patternSpan[i] == '}')
            {
                var newParam = patternSpan[startParamPos..i];
                var found = false;
                for (var j = 0; j < paramIndex; j++)
                {
                    var (StartPos, EndPos) = _paramSpanCoords[j];
                    if (patternSpan[StartPos..EndPos].SequenceEqual(newParam))
                    {
                        found = true; break;
                    }
                }
                if (!found)
                {
                    _paramKeys[paramIndex] = patternSpan[startParamPos..i].ToString();
                    _paramSpanCoords[paramIndex++] = new(startParamPos, i);
                    if (paramIndex == paramCount && segmentIndex < segmentCount)
                    {
                        _segmentSpanCoords[segmentIndex++] =
                            new(_paramSpanCoords[paramIndex - 1].EndPos + 1, patternSpan.Length);
                        break;
                    }
                    startParamPos = -1;
                }
                else
                {
                    throw new ArgumentException($"The variable [{newParam}] should only appear once in [{pattern}].");
                }
            }
        }

        _parameterDefaults = new Dictionary<string,object>(16);

    }

    public ApiRouteMatcher(string pattern, IDictionary<string,object> defaults) : this(pattern) 
    {
        foreach (var kv in defaults)
        {
            _parameterDefaults!.Add(kv.Key, kv.Value);
        }
    }

    public bool HasParameter(string paramName) => _paramKeys.Contains(paramName);

    public bool Matches(string stringToMatch, out IDictionary<string, object>? paramValues)
    {
        var routePatternSpan = _routePattern.AsSpan();
        var stringToMatchSpan = stringToMatch.AsSpan();
        var matchedValues = new Dictionary<string, object>();
        var paramPos = 0;
        var pos = 0;

        paramValues = null;

        for (var i = 0; i < _segmentSpanCoords.Length; i++) 
        {
            var segment = routePatternSpan[_segmentSpanCoords[i].StartPos.._segmentSpanCoords[i].EndPos];
            
            pos = stringToMatchSpan[pos..].IndexOf(segment)+pos;

            if (pos >= 0)
            {
                if (i == 0 && pos != 0)
                {
                    var paramKey = _paramKeys[paramPos++];

                    var paramValue = stringToMatchSpan[0..pos];

                    if (paramValue.Contains('/'))
                    {
                        return false;
                    }

                    matchedValues.Add(paramKey, paramValue.ToString());
                }

                int paramStart = pos + (_segmentSpanCoords[i].EndPos - _segmentSpanCoords[i].StartPos);

                int paramEnd = i + 1 < _segmentSpanCoords.Length
                    ? stringToMatchSpan[paramStart..].IndexOf(routePatternSpan[_segmentSpanCoords[i + 1].StartPos.._segmentSpanCoords[i + 1].EndPos]) + paramStart
                    : stringToMatchSpan.Length;


                if (paramEnd < 0)
                {
                    return false;
                }

                if (paramStart < paramEnd)
                {
                    var paramKey = _paramKeys[paramPos++];

                    var paramValue = stringToMatchSpan[paramStart..paramEnd];

                    if (paramValue.Contains('/'))
                    {
                        return false;
                    }

                    matchedValues.Add(paramKey, paramValue.ToString());

                    pos = paramStart;
                }
            }
            else
            {
                return false;
            }
        }

        foreach (var paramKey in _paramKeys)
        {
            if (!matchedValues.TryGetValue(paramKey, out object? matchValue) || matchValue.Equals(string.Empty))
            {
                if (_parameterDefaults.TryGetValue(paramKey, out object? paramValue))
                {
                    matchedValues[paramKey] = paramValue;
                }
                else
                {
                    throw new ArgumentException($"Parameter [{paramKey}] could not be resolved in [{stringToMatch}] and no default was supplied.");
                }
            }
        }

        paramValues = matchedValues;

        return true;
    }

    public string TransformTo(string pattern, IDictionary<string,object> variables)
    {
        var sbTo = new StringBuilder(pattern, 2048);
        foreach (var param in _paramKeys)
        {
            sbTo.Replace($"{{{param}}}", variables[param].ToString());
        }
        return sbTo.ToString();
    }

    private static int ValidateAndCountParams(ReadOnlySpan<char> span)
    {
        var openBraceCount = 0;
        var closedBraceCount = 0;
        foreach (var c in span)
        {
            if (c == '{')
                openBraceCount++;
            else if (c == '}')
                closedBraceCount++;
        }
        if (openBraceCount == closedBraceCount)
        {
            return openBraceCount;
        }
        throw new ArgumentException($"Parameter open and closed brace mismatch in [{span}].");
    }
}
