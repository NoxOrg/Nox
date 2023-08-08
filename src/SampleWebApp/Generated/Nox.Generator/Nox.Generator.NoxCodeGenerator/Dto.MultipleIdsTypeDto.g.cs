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
/// Entity to test all nox types.
/// </summary>
[AutoMap(typeof(MultipleIdsTypeCreateDto))]
[PrimaryKey(nameof(Id1), nameof(Id2))]
public partial class MultipleIdsTypeDto : AuditableEntityBase
{

    /// <summary>
    /// First Id (Required).
    /// </summary>
    [Key, Column(Order=1)]
    public System.String Id1 { get; set; } = default!;

    /// <summary>
    /// Second Id (Required).
    /// </summary>
    [Key, Column(Order=2)]
    public System.String Id2 { get; set; } = default!;

    /// <summary>
    /// Name of the entity (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
}