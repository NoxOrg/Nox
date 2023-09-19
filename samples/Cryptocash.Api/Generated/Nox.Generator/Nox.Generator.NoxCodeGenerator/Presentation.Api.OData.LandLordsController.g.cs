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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public partial class LandLordsController : LandLordsControllerBase
{
    public LandLordsController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
    {}
}
public abstract class LandLordsControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public LandLordsControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<LandLordDto>>> Get()
    {
        var result = await _mediator.Send(new GetLandLordsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<LandLordDto>> Get([FromRoute] System.Int64 key)
    {
        var query = await _mediator.Send(new GetLandLordByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Post([FromBody]LandLordCreateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateLandLordCommand(landLord));
        
        var item = (await _mediator.Send(new GetLandLordByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Put([FromRoute] System.Int64 key, [FromBody] LandLordUpdateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateLandLordCommand(key, landLord, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetLandLordByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<LandLordDto> landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in landLord.GetChangedPropertyNames())
        {
            if(landLord.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateLandLordCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetLandLordByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteLandLordByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToContractedAreasForVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefLandLordToContractedAreasForVendingMachinesCommand(new LandLordKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToContractedAreasForVendingMachines([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).Select(x => x.ContractedAreasForVendingMachines).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    #endregion
    
}
