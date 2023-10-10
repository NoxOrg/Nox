using Microsoft.AspNetCore.Mvc;
using ClientApi.Application.Dto;


namespace ClientApi.Presentation.Api.OData;

/// <summary>
/// Example of extending a Nox generated controller and override a endpoint
/// To disable validation for certain fields
/// </summary>
public partial class StoreOwnersController
{
    public override async Task<ActionResult<StoreOwnerDto>> Post([FromBody] StoreOwnerCreateDto storeOwner)
    {
        //Example of remove a field from validation
        ModelState.Remove(nameof(StoreOwnerCreateDto.TemporaryOwnerName));

        //For Example get from the Header
        //Request.Headers.TryGetValue(HeaderKeyName, out StringValues headerValue);
        if (string.IsNullOrEmpty(storeOwner.TemporaryOwnerName))
        {
            storeOwner.TemporaryOwnerName = "MJ";
        }
        
        return await base.Post(storeOwner);
    }
}