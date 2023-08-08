// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
[AutoMap(typeof(StoreCreateDto))]
[PrimaryKey(nameof(Id))]
public partial class StoreDto : AuditableEntityBase
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    [Key, Column(Order=1)]
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public MoneyDto PhysicalMoney { get; set; } = default!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswordsDto StoreSecurityPasswords { get; set; } = null!;
}