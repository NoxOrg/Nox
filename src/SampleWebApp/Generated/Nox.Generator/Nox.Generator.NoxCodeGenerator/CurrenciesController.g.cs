// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
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
    
    public CurrenciesController(
        ODataDbContext databaseContext
    )
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Currency>> Get()
    {
        return Ok(_databaseContext.Currencies);
    }
    
    public async Task<ActionResult> Post(Currency currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Currencies.Add(currency);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(currency);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var currency = await _databaseContext.Currencies.FindAsync(key);
        if (currency == null)
        {
            return NotFound();
        }
        
        _databaseContext.Currencies.Remove(currency);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
