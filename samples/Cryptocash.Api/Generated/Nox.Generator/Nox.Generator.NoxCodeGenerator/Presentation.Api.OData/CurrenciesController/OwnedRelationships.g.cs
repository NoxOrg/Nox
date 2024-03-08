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
    public virtual async Task<IActionResult> DeleteCurrencyOwnedBankNotes([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllBankNotesForCurrencyCommand(new CurrencyKeyDto(key), etag));
        return NoContent();
    }
}
