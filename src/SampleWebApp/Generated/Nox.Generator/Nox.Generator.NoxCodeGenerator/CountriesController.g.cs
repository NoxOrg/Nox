// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public class CountriesController : ODataController
{
    SampleWebAppDbContext _databaseContext;

    public CountriesController(SampleWebAppDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Country>> Get()
    {
        return Ok(_databaseContext.Countries);
    }
    
    [EnableQuery]
    public ActionResult<Country> Get([FromRoute] string key)
    {
        var parsedKey = CountryId.From(Text.From(key));
        var item = _databaseContext.Countries.SingleOrDefault(d => d.Id.Equals(parsedKey));
        
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(Country country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Countries.Add(country);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(country);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] Country updatedCountry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CountryId.From(Text.From(key));
        if (parsedKey != updatedCountry.Id)
        {
            return BadRequest();
        }
        _databaseContext.Entry(updatedCountry).State = EntityState.Modified;
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return Updated(updatedCountry);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<Country> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CountryId.From(Text.From(key));
        var entity = await _databaseContext.Countries.FindAsync(parsedKey);
        if (entity == null)
        {
            return NotFound();
        }
        country.Patch(entity);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(key))
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
    
    private bool CountryExists(string key)
    {
        var parsedKey = CountryId.From(Text.From(key));
        return _databaseContext.Countries.Any(p => p.Id == parsedKey);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var parsedKey = CountryId.From(Text.From(key));
        var country = await _databaseContext.Countries.FindAsync(parsedKey);
        if (country == null)
        {
            return NotFound();
        }
        
        _databaseContext.Countries.Remove(country);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
