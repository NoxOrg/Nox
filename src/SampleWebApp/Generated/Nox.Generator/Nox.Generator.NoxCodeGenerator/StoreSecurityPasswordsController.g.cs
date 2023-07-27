// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class StoreSecurityPasswordsController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    public StoreSecurityPasswordsController(
        ODataDbContext databaseContext,
        IMapper mapper
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<StoreSecurityPasswords>> Get()
    {
        return Ok(_databaseContext.StoreSecurityPasswords);
    }
    
    public ActionResult<StoreSecurityPasswords> Get([FromRoute] String key)
    {
        var item = _databaseContext.StoreSecurityPasswords.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(StoreSecurityPasswordsDto storesecuritypasswords)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = _mapper.Map<OStoreSecurityPasswords>(storesecuritypasswords);
        
        entity.Id = Guid.NewGuid().ToString().Substring(0, 2);
        
        _databaseContext.StoreSecurityPasswords.Add(entity);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(entity);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] OStoreSecurityPasswords updatedStoreSecurityPasswords)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedStoreSecurityPasswords.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedStoreSecurityPasswords).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StoreSecurityPasswordsExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedStoreSecurityPasswords);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string storesecuritypasswords, [FromBody] Delta<OStoreSecurityPasswords> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.StoreSecurityPasswords.FindAsync(storesecuritypasswords);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        Id.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StoreSecurityPasswordsExists(storesecuritypasswords))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(entity);
    }
    
    private bool StoreSecurityPasswordsExists(string storesecuritypasswords)
    {
        return _databaseContext.StoreSecurityPasswords.Any(p => p.Id == storesecuritypasswords);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string Id)
    {
        var storesecuritypasswords = await _databaseContext.StoreSecurityPasswords.FindAsync(Id);
        if (storesecuritypasswords == null)
        {
            return NotFound();
        }
        
        _databaseContext.StoreSecurityPasswords.Remove(storesecuritypasswords);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
