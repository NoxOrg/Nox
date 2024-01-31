using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Common;

public static class EnumExtensions
{
    public static HashSet<string> ToHashSet<T>() where T : struct, Enum
        => Enum.GetValues<T>().Select(e => nameof(e)).ToHashSet();
}
