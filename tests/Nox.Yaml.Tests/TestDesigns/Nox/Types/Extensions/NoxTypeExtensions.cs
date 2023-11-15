﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Types;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Extensions;

public static class NoxTypeExtensions
{
    private static Dictionary<string, Type> EmptyComponents => new();

    public static MemberInfo ToMemberInfo(this NoxType noxType)
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

    public static IDictionary<string, Type> GetCompoundComponents(this NoxType noxType)
    {
        if (noxType.IsCompoundType())
        {
            return noxType.ToMemberInfo()
                 .GetCustomAttributes<CompoundComponent>()
                 .ToDictionary(c => c.Name, c => c.UnderlyingType);
        }
        return EmptyComponents;
    }

    public static IDictionary<string, Type> GetComponents(this NoxType noxType, NoxSimpleTypeDefinition attribute)
    {
        if (noxType.IsSimpleType())
        {
            return new Dictionary<string, Type>()
            {
                { "Value", noxType.ToMemberInfo().GetCustomAttribute<SimpleTypeAttribute>()!.ComponentDiscover.GetUnderlyingType(attribute) }
            };

        }
        if (noxType.IsCompoundType())
        {
            return noxType.GetCompoundComponents();
        }
        return EmptyComponents;
    }

    public static bool IsReadableType(this NoxType noxType)
    {
        return (noxType.DtoGenerateControl()?.Read) ?? true;
    }

    public static bool IsUpdatableType(this NoxType noxType)
    {
        return (noxType.DtoGenerateControl()?.Update) ?? true;
    }

    private static IDtoGenerateControl? DtoGenerateControl(this NoxType noxType)
    {
        if (noxType.IsSimpleType())
            return noxType.ToMemberInfo().GetCustomAttribute<SimpleTypeAttribute>();
        else if (noxType.IsCompoundType())
            return noxType.ToMemberInfo().GetCustomAttribute<CompoundTypeAttribute>();

        return null;
    }

}
