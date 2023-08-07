// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// Stores.
/// </summary>
[AutoMap(typeof(StoreDto))]
public partial class OStore : AuditableEntityBase
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public String Id { get; set; } = null!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public String Name { get; set; } = default!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public Decimal PhysicalMoney { get; set; } = default!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual OStoreSecurityPasswords StoreSecurityPasswords { get; set; } = null!;
}