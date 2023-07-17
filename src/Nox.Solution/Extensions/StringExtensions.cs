using System;
using System.Collections.Generic;
using System.Text;

namespace Nox.Solution.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string input)
    {
        return char.ToLowerInvariant(input[0]) + input.Substring(1);
    }
}
