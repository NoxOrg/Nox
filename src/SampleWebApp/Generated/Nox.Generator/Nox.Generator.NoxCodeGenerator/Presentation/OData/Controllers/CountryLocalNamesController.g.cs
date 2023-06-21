// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using System.Net;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public class CountryLocalNamesController : ODataController
{
    SampleWebAppDbContext _databaseContext;

    public CountryLocalNamesController(SampleWebAppDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<CountryLocalNames>> Get()
    {
        return Ok(_databaseContext.CountryLocalNames);
    }
    
    [EnableQuery]
    public ActionResult<CountryLocalNames> Get([FromRoute] string key)
    {
        var parsedKey = CountryLocalNamesId.From(key);
        var item = _databaseContext.CountryLocalNames.SingleOrDefault(d => d.Id.Equals(parsedKey));
        
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(CountryLocalNames countrylocalnames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.CountryLocalNames.Add(countrylocalnames);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(countrylocalnames);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] CountryLocalNames updatedCountryLocalNames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CountryLocalNamesId.From(key);
        if (parsedKey != updatedCountryLocalNames.Id)
        {
            return BadRequest();
        }
        _databaseContext.Entry(updatedCountryLocalNames).State = EntityState.Modified;
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryLocalNamesExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return Updated(updatedCountryLocalNames);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<CountryLocalNames> countrylocalnames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CountryLocalNamesId.From(key);
        var entity = await _databaseContext.CountryLocalNames.FindAsync(parsedKey);
        if (entity == null)
        {
            return NotFound();
        }
        countrylocalnames.Patch(entity);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryLocalNamesExists(key))
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
    
    private bool CountryLocalNamesExists(string key)
    {
        var parsedKey = CountryLocalNamesId.From(key);
        return _databaseContext.CountryLocalNames.Any(p => p.Id == parsedKey);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var parsedKey = CountryLocalNamesId.From(key);
        var countrylocalnames = await _databaseContext.CountryLocalNames.FindAsync(parsedKey);
        if (countrylocalnames == null)
        {
            return NotFound();
        }
        
        _databaseContext.CountryLocalNames.Remove(countrylocalnames);
        await _databaseContext.SaveChangesAsync();
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}
