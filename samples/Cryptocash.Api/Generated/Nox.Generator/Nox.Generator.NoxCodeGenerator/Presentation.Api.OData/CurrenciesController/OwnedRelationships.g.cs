// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using Cryptocash.Application.Dto;

using ApplicationCommandsNameSpace = Cryptocash.Application.Commands;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class CurrenciesControllerBase
{
            
    [HttpDelete("/api/Currencies/{key}/BankNotes")]
    public virtual async Task<IActionResult> DeleteCurrencyAllOwnedBankNotesNonConventional([FromRoute] System.String key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllBankNotesForCurrencyCommand(new CurrencyKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/Currencies/{key}/BankNotes/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCurrencyOwnedBankNoteNonConventional([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteBankNotesForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), etag));
        return NoContent();
    }
    [HttpDelete("/api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCurrencyOwnedExchangeRateNonConventional([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteExchangeRatesForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), etag));
        return NoContent();
    }
}
