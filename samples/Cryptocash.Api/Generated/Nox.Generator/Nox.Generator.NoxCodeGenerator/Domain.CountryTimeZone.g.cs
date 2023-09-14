﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;
public partial class CountryTimeZone:CountryTimeZoneBase
{

}
/// <summary>
/// Time zone related to country.
/// </summary>
public abstract class CountryTimeZoneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

}