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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class CountryQualityOfLifeIndicesController : CountryQualityOfLifeIndicesControllerBase
{
    public CountryQualityOfLifeIndicesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class CountryQualityOfLifeIndicesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CountryQualityOfLifeIndicesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryQualityOfLifeIndexDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryQualityOfLifeIndicesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<CountryQualityOfLifeIndexDto>> Get([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId)
    {
        var query = await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(keyCountryId, keyId));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Post([FromBody]CountryQualityOfLifeIndexCreateDto countryQualityOfLifeIndex)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryQualityOfLifeIndexCommand(countryQualityOfLifeIndex));
        
        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(createdKey.keyCountryId, createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Put([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId, [FromBody] CountryQualityOfLifeIndexUpdateDto countryQualityOfLifeIndex)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryQualityOfLifeIndexCommand(keyCountryId, keyId, countryQualityOfLifeIndex, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(updated.keyCountryId, updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Patch([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId, [FromBody] Delta<CountryQualityOfLifeIndexDto> countryQualityOfLifeIndex)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryQualityOfLifeIndex.GetChangedPropertyNames())
        {
            if(countryQualityOfLifeIndex.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryQualityOfLifeIndexCommand(keyCountryId, keyId, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(updated.keyCountryId, updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryQualityOfLifeIndexByIdCommand(keyCountryId, keyId, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
