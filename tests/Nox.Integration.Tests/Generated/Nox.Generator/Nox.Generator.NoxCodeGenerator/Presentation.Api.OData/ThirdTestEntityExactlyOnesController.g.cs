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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class ThirdTestEntityExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToThirdTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(new ThirdTestEntityExactlyOneKeyDto(key), new ThirdTestEntityZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToThirdTestEntityZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Include(x => x.ThirdTestEntityZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        if (entity.ThirdTestEntityZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"ThirdTestEntityZeroOrOnes/{entity.ThirdTestEntityZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityZeroOrOne([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrOneCreateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        thirdTestEntityZeroOrOne.ThirdTestEntityExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrOneCommand(thirdTestEntityZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityZeroOrOneDto>> GetThirdTestEntityZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<ThirdTestEntityZeroOrOneDto>(Enumerable.Empty<ThirdTestEntityZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.ThirdTestEntityZeroOrOne != null).Select(x => x.ThirdTestEntityZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> PutToThirdTestEntityZeroOrOne(System.String key, [FromBody] ThirdTestEntityZeroOrOneUpdateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityZeroOrOneCommand(related.Id, thirdTestEntityZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
