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
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class ClientDatabaseNumbersController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public ClientDatabaseNumbersController(
        ODataDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<ClientDatabaseNumberDto>>> Get()
    {
        var result = await _mediator.Send(new GetClientDatabaseNumbersQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<ClientDatabaseNumberDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetClientDatabaseNumberByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]ClientDatabaseNumberCreateDto clientdatabasenumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateClientDatabaseNumberCommand(clientdatabasenumber));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] ClientDatabaseNumberUpdateDto clientDatabaseNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateClientDatabaseNumberCommand(key, clientDatabaseNumber));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<ClientDatabaseNumberUpdateDto> clientDatabaseNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        var deletedProperties = new HashSet<string>();

        foreach (var propertyName in clientDatabaseNumber.GetChangedPropertyNames())
        {
            if(clientDatabaseNumber.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }
            else
            {
                deletedProperties.Add(propertyName);
            }
        }
        
        var updated = await _mediator.Send(new PartialUpdateClientDatabaseNumberCommand(key, updateProperties, deletedProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new DeleteClientDatabaseNumberByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
