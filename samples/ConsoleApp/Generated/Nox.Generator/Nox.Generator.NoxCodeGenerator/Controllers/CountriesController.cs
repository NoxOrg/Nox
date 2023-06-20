// Generated

using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using SampleService.Domain;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SampleService.Presentation.Api.OData;

public class CountriesController : ODataController
{
    SampleServiceDbContext _databaseContext = new SampleServiceDbContext();

    public CountriesController(SampleServiceDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public IQueryable<Country> Get()
    {
        return _databaseContext.Countries;
    }
    
    [EnableQuery]
    public SingleResult<Country> Get([FromODataUri] int key)
    {
        IQueryable<Country> result = _databaseContext.Countries.Where(p => p.Id == key);
        return SingleResult.Create(result);
    }
    
    public async Task<IHttpActionResult> Post(Country country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Countries.Add(country);
        await _databaseContext.SaveChangesAsync();
        return Created(country);
    }
    
    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Country> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Countries.FindAsync(key);
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
    
    public async Task<IHttpActionResult> Put([FromODataUri] int key, Country update)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != update.Id)
        {
            return BadRequest();
        }
        _databaseContext.Entry(update).State = EntityState.Modified;
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
        return Updated(update);
    }
    
    private bool CountryExists(int key)
    {
        return _databaseContext.Countries.Any(p => p.Id == key);
    }
    
    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    {
        var country = await _databaseContext.Countries.FindAsync(key);
        if (country == null)
        {
            return NotFound();
        }
        
        _databaseContext.Countries.Remove(country);
        await _databaseContext.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
    
    protected override void Dispose(bool disposing)
    {
        _databaseContext.Dispose();
        base.Dispose(disposing);
    }
}
