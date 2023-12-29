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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class ThirdTestEntityZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Include(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("ThirdTestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        if (entity.ThirdTestEntityExactlyOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"ThirdTestEntityExactlyOnes/{entity.ThirdTestEntityExactlyOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromBody] ThirdTestEntityExactlyOneCreateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        thirdTestEntityExactlyOne.ThirdTestEntityZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateThirdTestEntityExactlyOneCommand(thirdTestEntityExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityExactlyOneDto>> GetThirdTestEntityExactlyOne(System.String key)
    {
        var query = await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<ThirdTestEntityExactlyOneDto>(Enumerable.Empty<ThirdTestEntityExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.ThirdTestEntityExactlyOne != null).Select(x => x.ThirdTestEntityExactlyOne!));
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> PutToThirdTestEntityExactlyOne(System.String key, [FromBody] ThirdTestEntityExactlyOneUpdateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("ThirdTestEntityExactlyOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityExactlyOneCommand(related.Id, thirdTestEntityExactlyOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> PatchToThirdTestEntityExactlyOne(System.String key, [FromBody] Delta<ThirdTestEntityExactlyOnePartialUpdateDto> thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid || thirdTestEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("ThirdTestEntityExactlyOne", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in thirdTestEntityExactlyOne.GetChangedPropertyNames())
        {
            if(thirdTestEntityExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateThirdTestEntityExactlyOneCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/ThirdTestEntityZeroOrOnes/{key}/ThirdTestEntityExactlyOne")]
    public virtual async Task<ActionResult> DeleteToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("ThirdTestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteThirdTestEntityExactlyOneByIdCommand(new List<ThirdTestEntityExactlyOneKeyDto> { new ThirdTestEntityExactlyOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
