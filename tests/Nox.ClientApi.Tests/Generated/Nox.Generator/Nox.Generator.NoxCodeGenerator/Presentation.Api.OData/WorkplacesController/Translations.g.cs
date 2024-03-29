﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using ClientApi.Application;
using System.Threading.Tasks;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;
         


public abstract partial class WorkplacesControllerBase
{
    [HttpPut("/api/v1/Workplaces/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> PutWorkplaceLocalized( [FromRoute] System.Int64 key, [FromRoute] System.String cultureCode, [FromBody] WorkplaceLocalizedUpsertDto workplaceLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(workplaceLocalizedUpsertDto.Description), workplaceLocalizedUpsertDto.Description.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        var item = (await _mediator.Send(new GetWorkplaceTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Workplaces/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> DeleteWorkplaceLocalized( [FromRoute] System.Int64 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
               
        await _mediator.Send(new DeleteWorkplaceTranslationCommand(key, cultureCodeValue!));

        return NoContent();
    }

    [HttpGet("/api/v1/Workplaces/{key}/Languages/")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceLocalizedDto>>> GetWorkplaceLanguagesNonConventional( [FromRoute] System.Int64 key)
    {
        var result = (await _mediator.Send(new GetWorkplaceTranslationsQuery(key)));
            
        return Ok(result);
    }

    [HttpGet("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}/Languages")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceAddressLocalizedDto>>> GetWorkplaceAddressLanguagesNonConventional([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        var result = (await _mediator.Send(new GetWorkplaceAddressTranslationsByParentIdQuery(key, relatedKey)));
        
        return Ok(result);
    }
    
    [HttpPut("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceAddressLocalizedDto>> PutWorkplaceAddressLocalized([FromRoute] System.Int64 key,[FromRoute] System.Guid relatedKey, [FromRoute] System.String cultureCode, [FromBody] WorkplaceAddressLocalizedUpsertDto workplaceAddressLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
        workplaceAddressLocalizedUpsertDto.Id = relatedKey;
        var etag = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(workplaceAddressLocalizedUpsertDto.AddressLine), workplaceAddressLocalizedUpsertDto.AddressLine.ToValueFromNonNull());
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceAddressesForWorkplaceCommand(
            new WorkplaceKeyDto(key),
            new WorkplaceAddressKeyDto(workplaceAddressLocalizedUpsertDto.Id!.Value),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetWorkplaceAddressTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceAddressLocalizedDto>> DeleteWorkplaceAddressLocalized( [FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteWorkplaceAddressesTranslationsForWorkplaceCommand(key, relatedKey, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
}