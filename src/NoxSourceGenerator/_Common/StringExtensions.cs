﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NoxSourceGenerator;

internal static class StringExtensions
{
    public static string EnsureEndsWith(this string text, string suffix)
    {
        if (text.EndsWith(suffix)) return text;

        return text + suffix;
    }
 
    public static string EnsureEndsWith(this string text, char suffix)
    {
        if (text.Length == 0) return text; 

        if (text[text.Length - 1] == suffix) return text;

        return text + suffix;
    }
}

