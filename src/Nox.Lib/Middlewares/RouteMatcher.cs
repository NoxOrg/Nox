using System.Text;

namespace Nox.Lib;

public class ApiRouteMatcher
{

    private readonly HashSet<string> _parameterNames;

    private readonly List<ParameterInfo> _parameterInfos;

    private readonly List<string> _segments;

    private readonly Dictionary<string,object> _parameterDefaults;

    public ApiRouteMatcher(string pattern)
    {
        _parameterNames = new HashSet<string>(16);
        _parameterInfos = new List<ParameterInfo>(16);
        _parameterDefaults = new Dictionary<string,object>(16);
        _segments = new List<string>(16);

        ParseParameters(pattern);
    }

    public ApiRouteMatcher(string pattern, IDictionary<string,object> defaults) : this(pattern) 
    {
        foreach (var kv in defaults)
        {
            _parameterDefaults!.Add(kv.Key, kv.Value);
        }
    }

    public bool HasParameter(string paramName) => _parameterNames.Contains(paramName);

    public bool Matches(string stringToMatch, out IDictionary<string, object>? paramValues)
    {
        var matchedValues = new Dictionary<string, object>();
        var pos = 0;

        paramValues = null;

        for (var i = 0; i < _segments.Count; i++) 
        {
            pos = stringToMatch.IndexOf(_segments[i],pos);

            if (pos >= 0)
            {
                if (i == 0 && pos != 0)
                {
                    return false;
                }

                int paramStart = pos + _segments[i].Length;

                int paramEnd = i + 1 < _segments.Count 
                    ? stringToMatch.IndexOf(_segments[i + 1], paramStart) 
                    : stringToMatch.Length;

                if (paramEnd < 0)
                {
                    return false;
                }

                var paramString = stringToMatch[paramStart..paramEnd];

                if (paramString.Contains('/'))
                {
                    return false;
                }

                matchedValues.Add(_parameterInfos[i].Name, paramString);
            }
            else
            {
                return false;
            }
        }

        foreach (var param in _parameterNames)
        {
            if (!matchedValues.ContainsKey(param) || matchedValues[param].Equals(string.Empty))
            {
                if (_parameterDefaults.TryGetValue(param, out object? value))
                {
                    matchedValues[param] = value;
                }
                else
                {
                    throw new ArgumentException($"Parameter [{param}] could not be resolved in [{stringToMatch}] and no default was supplied.");
                }
            }
        }

        paramValues = matchedValues;

        return true;
    }

    public string TransformTo(string pattern, IDictionary<string,object> variables)
    {
        var sbTo = new StringBuilder(pattern, 2048);

        foreach (var p in _parameterNames)
        {
            sbTo.Replace($"{{{p}}}", variables[p].ToString());
        }
        return sbTo.ToString();
    }

    private const char _leftParamDelimeter = '{';

    private const char _rightParamDelimeter = '}';

    private void ParseParameters(string pattern)
    {
        var isParameter = false;
        var currentParameter = new StringBuilder(64);
        var currentSegment = new StringBuilder(64);
        var pos = 0;
        var startPos = 0;

        foreach (char c in pattern)
        {
            switch (c)
            {
                case _leftParamDelimeter:
                    _segments.Add(currentSegment.ToString());
                    currentSegment.Clear();
                    isParameter = true;
                    startPos = pos;
                    break;

                case _rightParamDelimeter:
                    var paramName = currentParameter.ToString();
                    if(_parameterNames.Contains(paramName))
                    {
                        throw new ArgumentException($"The variable [{paramName}] should only appear once in [{pattern}].");
                    }
                    _parameterNames.Add(paramName);
                    _parameterInfos.Add(new ParameterInfo(paramName, startPos, pos));
                    currentParameter.Clear();
                    isParameter = false;
                    break;

                default:
                    
                    if (isParameter)
                        currentParameter.Append(c);
                    else
                        currentSegment.Append(c);
                    
                    break;
            }
            pos++;
        }

    }

    internal record ParameterInfo(string Name, int StartPos, int EndPos);
}
