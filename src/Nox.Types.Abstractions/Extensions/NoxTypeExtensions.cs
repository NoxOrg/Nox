using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Nox.Types;

namespace Nox.Types.Extensions;

public static class NoxTypeExtensions
{

    private static MemberInfo ToMemberInfo(this NoxType noxType)
    {
        var memberInfo = typeof(NoxType).GetMember(noxType.ToString());
        var fullMemberInfo = memberInfo.First(m => m.DeclaringType == typeof(NoxType));
        return fullMemberInfo;
    }

    public static bool IsSimpleType(this NoxType noxType)
    {
        return noxType.ToMemberInfo().GetCustomAttribute<SimpleTypeAttribute>(false) != null;
    }
    public static bool IsCompoundType(this NoxType noxType)
    {
        return noxType.ToMemberInfo().GetCustomAttribute<CompoundTypeAttribute>(false) != null;
    }
    public static IDictionary<string, Type>? GetCompoundComponents(this NoxType noxType)
    {
        if (noxType.IsCompoundType())
        {
            return noxType.ToMemberInfo()
                 .GetCustomAttributes<CompoundComponentAttribute>()
                 .ToDictionary(c => c.Name, c => c.UnderlyingType);
        }
        return null;
    }

    public static IDictionary<string, Type>? GetComponents(this NoxType noxType)
    {
        if (noxType.IsSimpleType())
        {
            return new Dictionary<string, Type>()
            {
                { string.Empty, noxType.ToMemberInfo().GetCustomAttribute<SimpleTypeAttribute>().UnderlyingType }
            };
                 
        }
        else if (noxType.IsCompoundType())
        {
            return noxType.GetCompoundComponents();
        }
        return new Dictionary<string,Type>();
    }
}
