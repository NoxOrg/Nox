// generated

#nullable enable


using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using SampleService.Infrastructure.Persistence;
using SampleService.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SampleService.Presentation.Api.OData;

public partial class CountriesController_Sample : ODataController
{
    SampleServiceDbContext_Sample _dbContext;

    public CountriesController_Sample(SampleServiceDbContext_Sample dbContext)
    {
        _dbContext = dbContext;
    }

    // use odata for aspnetcore!
    // https://learn.microsoft.com/en-us/odata/webapi-8/getting-started?tabs=net60%2Cvisual-studio-2022%2Cvisual-studio

    // https://learn.microsoft.com/en-us/odata/webapi-8/tutorials/basic-crud?tabs=net60%2Cvisual-studio-2022%2Cvisual-studio%2Cvs2022

    [EnableQuery]
    public ActionResult<IQueryable<Country>> Get()
    {
        return Ok(_dbContext.Countries);
    }

    [EnableQuery]
    public ActionResult<Country> Get([FromRoute] int key) // check the key type here!
    {
        var item = _dbContext.Countries.SingleOrDefault(d => d.Id.Equals(key));

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    public async Task<ActionResult> Post([FromBody] Country country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _dbContext.Countries.Add(country);

        await _dbContext.SaveChangesAsync();
        
        return Created(country);
    }

    public async Task<ActionResult> Put([FromRoute] string key, Country updatedCountry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (key != updatedCountry.Id.Value.Value)
        {
            return BadRequest();
        }
        _dbContext.Entry(updatedCountry).State = EntityState.Modified;
        try
        {
            await _dbContext.SaveChangesAsync();
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
        return Updated(update);
    }

    public async Task<ActionResult> Patch([FromODataUri] int key, Delta<Country> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var entity = await _dbContext.Countries.FindAsync(key);
        if (entity == null)
        {
            return NotFound();
        }
        country.Patch(entity);
        try
        {
            await _dbContext.SaveChangesAsync();
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

 

    private bool CountryExists(int key)
    {
        return _dbContext.Countries.Any(p => p.Id == key);
    }

    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    {
        var country = await _dbContext.Countries.FindAsync(key);
        if (country == null)
        {
            return NotFound();
        }

        _dbContext.Countries.Remove(country);
        await _dbContext.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
}
