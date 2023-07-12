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

public partial class TenantWorkplacesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    public TenantWorkplacesController(
        ODataDbContext databaseContext,
        IMapper mapper
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<TenantWorkplace>> Get()
    {
        return Ok(_databaseContext.TenantWorkplaces);
    }
    
    public ActionResult<TenantWorkplace> Get([FromRoute] string key)
    {
        var item = _databaseContext.TenantWorkplaces.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<TenantWorkplaceContact>> GetContacts([FromRoute] string key)
    {
        return Ok(_databaseContext.TenantWorkplaces.Where(d => d.Id.Equals(key)).SelectMany(m => m.Contacts));
    }
    
    public async Task<ActionResult> Post(TenantWorkplaceDto tenantworkplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = _mapper.Map<TenantWorkplace>(tenantworkplace);
        
        entity.Id = Guid.NewGuid().ToString().Substring(0, 2);
        entity.CreatedBy = "test";
        entity.CreatedAtUtc = DateTime.UtcNow;
        
        _databaseContext.TenantWorkplaces.Add(entity);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(entity);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] TenantWorkplace updatedTenantWorkplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedTenantWorkplace.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedTenantWorkplace).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TenantWorkplaceExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedTenantWorkplace);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string tenantworkplace, [FromBody] Delta<TenantWorkplace> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.TenantWorkplaces.FindAsync(tenantworkplace);
        
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
            if (!TenantWorkplaceExists(tenantworkplace))
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
    
    private bool TenantWorkplaceExists(string tenantworkplace)
    {
        return _databaseContext.TenantWorkplaces.Any(p => p.Id == tenantworkplace);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string Id)
    {
        var tenantworkplace = await _databaseContext.TenantWorkplaces.FindAsync(Id);
        if (tenantworkplace == null)
        {
            return NotFound();
        }
        
        _databaseContext.TenantWorkplaces.Remove(tenantworkplace);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
