// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of currencies.
/// </summary>
public partial class CurrencyCreateDto : CurrencyUpdateDto
{

    public SampleWebApp.Domain.Currency ToEntity()
    {
        var entity = new SampleWebApp.Domain.Currency();
        entity.Name = SampleWebApp.Domain.Currency.CreateName(Name);
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}