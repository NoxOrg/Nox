// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Application.Dto;
using Nox.Extensions;
using Nox.Exceptions;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class PeopleControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<UserContactSelectionDto>> GetUserContactSelection([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetPersonByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Person", $"{key.ToString()}");
        }
        
        return Ok(item.UserContactSelection);
    }
    
    public virtual async Task<ActionResult<UserContactSelectionDto>> PutToUserContactSelection(System.Guid key, [FromBody] UserContactSelectionUpsertDto userContactSelection)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateUserContactSelectionForPersonCommand(new PersonKeyDto(key), userContactSelection, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetPersonByIdQuery(key))).SingleOrDefault()?.UserContactSelection;
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToUserContactSelection(System.Guid key, [FromBody] Delta<UserContactSelectionUpsertDto> userContactSelection)
    {
        if (!ModelState.IsValid || userContactSelection is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<UserContactSelectionUpsertDto>(userContactSelection);
        
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateUserContactSelectionForPersonCommand(new PersonKeyDto(key), updatedProperties, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetPersonByIdQuery(key))).SingleOrDefault()?.UserContactSelection;
        
        return Ok(child);
    }
    
    #endregion
    
}
