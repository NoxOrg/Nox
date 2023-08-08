using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Command;
using SampleWebApp.Application.Queries;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// Extending a OData controller example with additional queries (Action) and commands (Functions)
/// </summary>
public partial class CountriesController
{
    [HttpGet("GetCountriesIManage")]
    public async Task<IResult> GetCountriesIManage()
    {
        var result = await _mediator.Send(new GetCountriesIManageQuery());
        return Results.Ok(result);
    }

    //[HttpDelete("api/[Controller]({id})/Currencies({currencyKey})")]
    //public async Task<IResult> Delete([FromODataUri] int key, [FromODataUri] int currencyKey)
    //{
    //    var result = await _mediator.Send(new DeleteCurrencyFromCountryCommand(10));
    //    return Results.Ok(result);
    //}

    //[HttpDelete("api/[Controller]/{id}/Currencies/{currencyKey}")]
    //public async Task<IResult> DeleteCurrencyFromCountryCommand2([FromRoute] int id, [FromRoute] int currencyKey)
    //{
    //    var result = await _mediator.Send(new DeleteCurrencyFromCountryCommand(10));
    //    return Results.Ok(result);
    //}

    /// <summary>
    /// Example using OData Reference Routing <see cref="https://learn.microsoft.com/en-us/odata/webapi-8/fundamentals/ref-routing?tabs=net60%2Cvisual-studio"/>
    /// Delete /countries/{key}/currencies/{relatedKey}
    /// </summary>
    /// <returns></returns>
    public async Task<IResult> DeleteRefToCurrencies([FromRoute] string key, [FromRoute] int relatedKey)
    {     
        await Task.Delay(100);
        return Results.Ok(true);
    }

    /// <summary>
    /// Example using OData Action for custom commands
    /// </summary>
    [HttpDelete("DeleteCountryContactCommand")]
    public async Task<IResult> DeleteUnConventional(DeleteCountryContactCommand command)
    {
        await Task.Delay(100);
        return Results.Ok(true);
    }

    /// <summary>
    /// Example of adding a Related entity to Countries
    /// POST /countries/{key}/currencies 
    /// with a json body
    /// </summary>
    public async Task<IResult> PostToCurrencies([FromRoute] string key, [FromBody] SampleWebApp.Application.Dto.CurrencyCreateDto currency)
    {
        await Task.Delay(100);
        return Results.Ok(true);
    }

    public async Task<ActionResult> Patch2([FromRoute] System.String key, [FromBody] Delta<SampleWebApp.Application.Dto.CountryDto> country)
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

}
