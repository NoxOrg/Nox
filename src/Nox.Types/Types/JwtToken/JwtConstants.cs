using System;
using System.Text.RegularExpressions;

namespace Nox.Types;

internal static class JwtConstants
{
    public const int JwsPartCount = 3;
    public const int JwsPayloadPartIndex = 1;
    public static readonly Regex JwsFormatRegex = new(@"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]*$", RegexOptions.None, TimeSpan.FromSeconds(1));
    
    public const int JwePartCount = 5;
    public static readonly Regex JweFormatRegex = new(@"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]*\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+$", RegexOptions.None, TimeSpan.FromSeconds(1));
}
