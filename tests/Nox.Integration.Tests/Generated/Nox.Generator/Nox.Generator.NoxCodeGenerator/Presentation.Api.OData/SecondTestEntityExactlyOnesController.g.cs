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

public abstract partial class SecondTestEntityExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(new SecondTestEntityExactlyOneKeyDto(key), new TestEntityExactlyOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityExactlyOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Include(x => x.TestEntityExactlyOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityExactlyOne", $"{key.ToString()}");
        }
        
        if (entity.TestEntityExactlyOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityExactlyOnes/{entity.TestEntityExactlyOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOne([FromRoute] System.String key, [FromBody] TestEntityExactlyOneCreateDto testEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityExactlyOne.SecondTestEntityExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneCommand(testEntityExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneDto>> GetTestEntityExactlyOne(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneDto>(Enumerable.Empty<TestEntityExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityExactlyOne != null).Select(x => x.TestEntityExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneDto>> PutToTestEntityExactlyOne(System.String key, [FromBody] TestEntityExactlyOneUpdateDto testEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneCommand(related.Id, testEntityExactlyOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneDto>> PatchToTestEntityExactlyOne(System.String key, [FromBody] Delta<TestEntityExactlyOnePartialUpdateDto> testEntityExactlyOne)
    {
        if (!ModelState.IsValid || testEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOne", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityExactlyOne.GetChangedPropertyNames())
        {
            if(testEntityExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityExactlyOneCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
