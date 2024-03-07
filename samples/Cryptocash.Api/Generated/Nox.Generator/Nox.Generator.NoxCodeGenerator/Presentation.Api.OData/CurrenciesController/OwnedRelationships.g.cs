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
            
    [HttpDelete("Currencies/{key}/BankNotes")]
    public async Task<IActionResult> DeleteCurrencyOwnedBankNotes([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllBankNotesForCurrencyCommand(new CurrencyKeyDto(key), etag));
        return NoContent();
    }
}
