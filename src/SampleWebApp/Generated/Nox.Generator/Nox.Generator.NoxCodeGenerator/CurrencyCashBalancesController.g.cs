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

public partial class CurrencyCashBalancesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    public CurrencyCashBalancesController(
        ODataDbContext databaseContext
    )
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<CurrencyCashBalance>> Get()
    {
        return Ok(_databaseContext.CurrencyCashBalances);
    }
    
    public async Task<ActionResult> Post(CurrencyCashBalance currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.CurrencyCashBalances.Add(currencycashbalance);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(currencycashbalance);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var currencycashbalance = await _databaseContext.CurrencyCashBalances.FindAsync(key);
        if (currencycashbalance == null)
        {
            return NotFound();
        }
        
        _databaseContext.CurrencyCashBalances.Remove(currencycashbalance);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
