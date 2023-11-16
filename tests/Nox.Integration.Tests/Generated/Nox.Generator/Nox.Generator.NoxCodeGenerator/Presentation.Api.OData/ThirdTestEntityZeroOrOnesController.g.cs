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
using Nox.Extensions;
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
    
    public async Task<ActionResult> CreateRefToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"ThirdTestEntityExactlyOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(new ThirdTestEntityZeroOrOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityExactlyOne([FromRoute] System.String key, [FromBody] ThirdTestEntityExactlyOneCreateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        thirdTestEntityExactlyOne.ThirdTestEntityZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateThirdTestEntityExactlyOneCommand(thirdTestEntityExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityExactlyOneDto>> GetThirdTestEntityExactlyOne(System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Where(x => x.ThirdTestEntityExactlyOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<ThirdTestEntityExactlyOneDto>(Enumerable.Empty<ThirdTestEntityExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.ThirdTestEntityExactlyOne!));
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> PutToThirdTestEntityExactlyOne(System.String key, [FromBody] ThirdTestEntityExactlyOneUpdateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityExactlyOneCommand(related.Id, thirdTestEntityExactlyOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/ThirdTestEntityZeroOrOnes/{key}/ThirdTestEntityExactlyOne")]
    public async Task<ActionResult> DeleteToThirdTestEntityExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteThirdTestEntityExactlyOneByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    #endregion
    
}
