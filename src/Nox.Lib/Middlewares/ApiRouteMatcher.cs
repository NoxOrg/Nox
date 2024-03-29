﻿using System.Diagnostics;
using System.Text;

namespace Nox.Lib;

[DebuggerDisplay("{_routePattern}")]
internal class ApiRouteMatcher
{

    private readonly string _routePattern;

    private readonly string _queryPattern;

    private readonly (int StartPos, int EndPos)[] _segmentSpanCoords;

    private readonly (int StartPos, int EndPos)[] _variableSpanCoords;

    private readonly string[] _routeParamKeys;

    private readonly string[] _queryParamKeys;

    private readonly Dictionary<string,string> _parameterDefaults;

    public ApiRouteMatcher(string pattern)
    {
        var patternSpan = pattern.AsSpan();
        var queryPos = patternSpan.IndexOf('?');
        var routeSpan = queryPos >= 0 ? patternSpan[0..queryPos] : patternSpan;
        var querySpan = queryPos >= 0 ? patternSpan[queryPos..] : Span<char>.Empty;

        var routeParamCount = ValidateAndCountParams(routeSpan);
        var queryParamCount = ValidateAndCountParams(querySpan);
        var routeSegmentCount = ValidateAndCountSegments(routeSpan, routeParamCount);

        _routePattern = routeSpan.ToString();
        _queryPattern = querySpan.ToString();
        _segmentSpanCoords = new (int StartPos, int EndPos)[routeSegmentCount];
        _variableSpanCoords = new (int StartPos, int EndPos)[queryParamCount];
        _routeParamKeys = new string[routeParamCount];
        _queryParamKeys = new string[queryParamCount];
        _parameterDefaults = new Dictionary<string, string>(16);

        ExtractRouteParametersAndSegments(routeSpan, routeParamCount, routeSegmentCount);

        ExtractQueryParametersAndKeys(querySpan);

    }

    public ApiRouteMatcher(string pattern, IDictionary<string,string> defaults) : this(pattern) 
    {
        foreach (var kv in defaults)
        {
            _parameterDefaults!.Add(kv.Key, kv.Value);
        }
    }

    public bool HasParameter(string paramName) => _routeParamKeys.Contains(paramName) 
        || _queryParamKeys.Contains(paramName);

    public bool Match(string stringToMatch, out IDictionary<string, string>? paramValues)
    {
        var stringToMatchSpan = stringToMatch.AsSpan();
        var queryPos = stringToMatchSpan.IndexOf('?');
        var routeToMatchSpan = queryPos >= 0 ? stringToMatchSpan[0..queryPos] : stringToMatchSpan;
        var queryToMatchSpan = queryPos >= 0 ? stringToMatchSpan[queryPos..] : Span<char>.Empty;

        var routePatternSpan = _routePattern.AsSpan();
        var queryPatternSpan = _queryPattern.AsSpan();

        var matchedValues = new Dictionary<string, string>();
        var paramPos = 0;
        var pos = 0;

        paramValues = null;

        for (var i = 0; i < _segmentSpanCoords.Length; i++)
        {
            var segment = routePatternSpan[_segmentSpanCoords[i].StartPos.._segmentSpanCoords[i].EndPos];

            pos = routeToMatchSpan[pos..].IndexOf(segment, StringComparison.OrdinalIgnoreCase) + pos;

            if (pos >= 0)
            {
                if (i == 0 && pos != 0)
                {
                    var paramKey = _routeParamKeys[paramPos++];

                    var paramValue = routeToMatchSpan[0..pos];

                    if (paramValue.Contains('/'))
                    {
                        return false;
                    }

                    matchedValues.Add(paramKey, paramValue.ToString());
                }

                var paramStart = pos + (_segmentSpanCoords[i].EndPos - _segmentSpanCoords[i].StartPos);

                //First, we need to check if the route contains the segment or not
                var segmentIndex = -1;
                var segmentExists = false;
                if (i + 1 < _segmentSpanCoords.Length)
                {
                    segmentIndex = routeToMatchSpan[paramStart..].IndexOf(routePatternSpan[_segmentSpanCoords[i + 1].StartPos.._segmentSpanCoords[i + 1].EndPos], StringComparison.OrdinalIgnoreCase);
                    if (segmentIndex > -1)
                        segmentExists = true;
                }
                
                var paramEnd = routeToMatchSpan.Length; //default value
                if (i + 1 < _segmentSpanCoords.Length && segmentIndex > -1)
                {
                    paramEnd = segmentIndex + paramStart;
                }

                if (paramEnd < 0 || i + 1 < _segmentSpanCoords.Length && !segmentExists)
                {
                    return false;
                }


                if (paramStart < paramEnd)
                {
                    if (_routeParamKeys.Length <= paramPos)
                    {
                        return false;
                    }

                    var paramKey = _routeParamKeys[paramPos++];

                    var paramValue = routeToMatchSpan[paramStart..paramEnd];

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

        paramPos = 0;

        for (var i = 0; i < _variableSpanCoords.Length; i++)
        {
            var segment = queryPatternSpan[_variableSpanCoords[i].StartPos.._variableSpanCoords[i].EndPos];

            pos = queryToMatchSpan[0..].IndexOf(segment);

            if (pos >= 0)
            {
                int paramStart = pos + (_variableSpanCoords[i].EndPos - _variableSpanCoords[i].StartPos)+1;

                var nextParamStart = queryToMatchSpan[paramStart..].IndexOf('&');

                int paramEnd = nextParamStart >= 0 ? nextParamStart : queryToMatchSpan.Length;

                if (paramEnd < 0)
                {
                    return false;
                }

                if (paramStart < paramEnd)
                {
                    var paramKey = _queryParamKeys[paramPos++];

                    var paramValue = queryToMatchSpan[paramStart..paramEnd];

                    matchedValues.Add(paramKey, paramValue.ToString());

                }
            }
        }

        foreach (var paramKey in _routeParamKeys.Concat(_queryParamKeys))
        {
            if (!matchedValues.TryGetValue(paramKey, out string? matchValue) || matchValue.Equals(string.Empty))
            {
                if (!_parameterDefaults.TryGetValue(paramKey, out var paramValue))
                {
                    throw new ArgumentException($"Parameter [{paramKey}] could not be resolved in [{stringToMatch}] and no default was supplied.");
                }
                matchedValues[paramKey] = paramValue;
            }
        }

        paramValues = matchedValues;

        return true;
    }

    public string TransformTo(string pattern, IDictionary<string,string> variables)
    {
        var sbTo = new StringBuilder(pattern, 2048);
        foreach (var param in _routeParamKeys)
        {
            sbTo.Replace($"{{{param}}}", variables[param]);
        }
        foreach (var param in _queryParamKeys)
        {
            sbTo.Replace($"{{{param}}}", variables[param]);
        }
        return sbTo.ToString();
    }

    private static int ValidateAndCountParams(ReadOnlySpan<char> span)
    {
        var openBraceCount = 0;
        var closedBraceCount = 0;
        foreach (var c in span)
        {
            switch (c)
            {
                case '{':
                    openBraceCount++;
                    break;
                case '}':
                    closedBraceCount++;
                    break;
            }
        }
        if (openBraceCount == closedBraceCount)
        {
            return openBraceCount;
        }
        throw new ArgumentException($"Parameter open and closed brace mismatch in [{span}].");
    }

    private static int ValidateAndCountSegments(ReadOnlySpan<char> routeSpan, int routeParamCount)
    {
        var routeSegmentCount = routeParamCount;

        if (routeSpan[0] == '{') routeSegmentCount--;
        
        if (routeSpan[^1] != '}') routeSegmentCount++;
        
        return routeSegmentCount;
    }

    private void ExtractRouteParametersAndSegments(ReadOnlySpan<char> routeSpan, int routeParamCount, int routeSegmentCount)
    {
        var routeParamIndex = 0;
        var segmentIndex = 0;
        var startParamPos = -1;
        var paramSpanCoords = new (int StartPos, int EndPos)[routeParamCount];

        for (var i = 0; i < routeSpan.Length; i++)
        {
            if (routeSpan[i] == '{')
            {
                startParamPos = i + 1;
                if (i > 0 && routeParamIndex > 0)
                {
                    _segmentSpanCoords[segmentIndex++] = new(paramSpanCoords[routeParamIndex - 1].EndPos + 1, i);
                }
                else if (i > 0)
                {
                    _segmentSpanCoords[segmentIndex++] =
                        new(0, i);
                }
            }
            else if (routeSpan[i] == '}')
            {
                var newParam = routeSpan[startParamPos..i].ToString();

                if (HasParameter(newParam))
                {
                    throw new ArgumentException($"The variable [{newParam}] should only appear once in [{_routePattern}].");
                }

                _routeParamKeys[routeParamIndex] = newParam;
             
                paramSpanCoords[routeParamIndex] = new(startParamPos, i);
                
                routeParamIndex++;

                if (routeParamIndex == routeParamCount && segmentIndex < routeSegmentCount)
                {
                    _segmentSpanCoords[segmentIndex++] =
                        new(paramSpanCoords[routeParamIndex - 1].EndPos + 1, routeSpan.Length);
                    break;
                }

            }
        }

        if (routeParamCount == 0 && segmentIndex < routeSegmentCount)
        {
            _segmentSpanCoords[segmentIndex] = new(0, routeSpan.Length);
        }

    }

    private void ExtractQueryParametersAndKeys(ReadOnlySpan<char> querySpan)
    {
        var startParamPos = -1;
        var startVarPos = -1;
        var endVarPos = -1;
        var queryParamIndex = 0;

        for (var i = 0; i < querySpan.Length; i++)
        {

            switch (querySpan[i])
            {
                case '?':
                case '&':
                    startVarPos = i + 1;
                    break;
                case '=':
                    endVarPos = i;
                    break;
                case ' ':
                    break;
                case '{':
                    startParamPos = i + 1;
                    break;
                case '}':
                    {
                        var newParam = querySpan[startParamPos..i].ToString();

                        if (HasParameter(newParam))
                        {
                            throw new ArgumentException($"The variable [{newParam}] should only appear once in [{_routePattern}{_queryPattern}].");
                        }

                        _queryParamKeys[queryParamIndex] = newParam;
                        
                        _variableSpanCoords[queryParamIndex] = new(startVarPos, endVarPos);
                        
                        queryParamIndex++;

                        break;
                    }
            }
        }

    }
}
