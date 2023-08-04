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
/// The name of a country in other languages.
/// </summary>
[AutoMap(typeof(CountryLocalNamesDto))]
public partial class OCountryLocalNames : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public String Id { get; set; } = null!;
}