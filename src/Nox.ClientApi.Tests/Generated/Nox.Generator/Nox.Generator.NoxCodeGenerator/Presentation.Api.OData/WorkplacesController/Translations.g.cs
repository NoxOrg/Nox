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
    
    [HttpPut("/api/v1/Workplaces/{key}/WorkplaceLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> PutWorkplaceLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode, [FromBody] WorkplaceLocalizedUpsertDto workplaceLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var etag = (await _mediator.Send(new GetWorkplaceByIdQuery(Nox.Types.CultureCode.From(cultureCode), key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            return NotFound();
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(workplaceLocalizedUpsertDto.Description), workplaceLocalizedUpsertDto.Description.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetWorkplaceTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/{key}/WorkplaceLocalized/")]
    public virtual async Task<ActionResult<IQueryable<WorkplaceLocalizedDto>>> GetWorkplaceLocalized( [FromRoute] System.UInt32 key)
    {
        var result = (await _mediator.Send(new GetWorkplaceTranslationsQuery(key)));
            
        return Ok(result);
    }
}