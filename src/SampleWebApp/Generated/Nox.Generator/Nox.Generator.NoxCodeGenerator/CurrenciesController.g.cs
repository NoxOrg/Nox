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

public partial class CurrenciesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    public CurrenciesController(
        ODataDbContext databaseContext,
        IMapper mapper
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Currency>> Get()
    {
        return Ok(_databaseContext.Currencies);
    }
    
    public ActionResult<Currency> Get([FromRoute] String key)
    {
        var item = _databaseContext.Currencies.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(CurrencyDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = _mapper.Map<OCurrency>(currency);
        
        entity.Id = Guid.NewGuid().ToString().Substring(0, 2);
        
        _databaseContext.Currencies.Add(entity);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(entity);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] OCurrency updatedCurrency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedCurrency.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedCurrency).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CurrencyExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedCurrency);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string currency, [FromBody] Delta<OCurrency> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Currencies.FindAsync(currency);
        
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
            if (!CurrencyExists(currency))
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
    
    private bool CurrencyExists(string currency)
    {
        return _databaseContext.Currencies.Any(p => p.Id == currency);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string Id)
    {
        var currency = await _databaseContext.Currencies.FindAsync(Id);
        if (currency == null)
        {
            return NotFound();
        }
        
        _databaseContext.Currencies.Remove(currency);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
