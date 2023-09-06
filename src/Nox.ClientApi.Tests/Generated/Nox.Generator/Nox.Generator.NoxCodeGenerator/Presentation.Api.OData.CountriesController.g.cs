// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class CountriesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CountriesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CountryDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<CountryLocalNameDto>>> GetCountryLocalNames([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CountryLocalNames);
    }
    
    public async Task<ActionResult> PostToCountryLocalNames([FromRoute] System.Int64 key, [FromBody] CountryLocalNameCreateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddCountryLocalNameCommand(new CountryKeyDto(key), countryLocalName));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        return Created(new CountryLocalNameDto { Id = createdKey.keyId });
    }
    
    public async Task<ActionResult> PutToCountryLocalNames([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey, [FromBody] CountryLocalNameUpdateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateCountryLocalNameCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey), countryLocalName));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        return Updated(new CountryLocalNameDto { Id = updatedKey.keyId });
    }
    
    public async Task<ActionResult> PatchToCountryLocalNames([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey, [FromBody] Delta<CountryLocalNameUpdateDto> countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryLocalName.GetChangedPropertyNames())
        {
            if(countryLocalName.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryLocalNameCommand(new CountryKeyDto(key), updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(new CountryLocalNameDto { Id = updated.keyId });
    }
    
    public async Task<ActionResult> Post([FromBody]CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryCommand(country));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateCountryCommand(key, country));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<CountryUpdateDto> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in country.GetChangedPropertyNames())
        {
            if(country.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
