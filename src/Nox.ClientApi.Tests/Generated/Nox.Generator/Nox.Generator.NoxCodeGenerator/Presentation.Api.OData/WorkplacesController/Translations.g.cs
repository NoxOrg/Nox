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

using System;
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
    
    [HttpPatch("api/Workplaces/{key}/WorkplaceLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> PatchWorkplaceLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode, [FromBody] Delta<WorkplaceLocalizedUpsertDto> workplaceLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        var etag = Request.GetDecodedEtagHeader();
        
        foreach (var propertyName in workplaceLocalizedUpsertDto.GetDynamicMemberNames())
        {
            if (workplaceLocalizedUpsertDto.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetWorkplaceTranslationsByIdQuery( updatedKey.keyId, cultureCode))).SingleOrDefault();

        return Ok(item);
    }
}