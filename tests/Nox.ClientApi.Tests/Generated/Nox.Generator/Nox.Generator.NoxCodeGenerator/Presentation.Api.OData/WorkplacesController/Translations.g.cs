// Generated

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
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;
         


public abstract partial class WorkplacesControllerBase
{
    [HttpPut("/api/v1/Workplaces/{key}/WorkplacesLocalized/{cultureCode}")]
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

    [HttpDelete("/api/v1/Workplaces/{key}/WorkplacesLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> DeleteWorkplaceLocalized( [FromRoute] System.Int64 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
               
        var isDeleted = await _mediator.Send(new DeleteWorkplaceLocalizationsCommand(key, Nox.Types.CultureCode.From(cultureCode)));

        if (!isDeleted)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        return NoContent();
    }

    [HttpGet("/api/v1/Workplaces/{key}/WorkplacesLocalized/")]
    public virtual async Task<ActionResult<IQueryable<WorkplaceLocalizedDto>>> GetWorkplaceLocalizedNonConventional( [FromRoute] System.Int64 key)
    {
        var result = (await _mediator.Send(new GetWorkplaceTranslationsQuery(key)));
            
        return Ok(result);
    }

}