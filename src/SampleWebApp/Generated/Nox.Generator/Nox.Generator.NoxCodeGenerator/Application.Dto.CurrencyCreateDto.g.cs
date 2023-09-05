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

    public Currency ToEntity()
    {
        var entity = new Currency();
        entity.Name = Currency.CreateName(Name);
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}