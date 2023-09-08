using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ClientApi.Presentation.Api.OData;

public partial class CountriesController 
{

    //TODO Example custom Action
   // [HttpPost("odata/Books({key})/Rate")]
    //public IActionResult Rate([FromODataUri] string key, ODataActionParameters parameters)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest();
    //    }

    //    int rating = (int)parameters["rating"];

    //    if (rating < 0)
    //    {
    //        return BadRequest();
    //    }

    //    return Ok(new BookRating() { BookID = key, Rating = rating });
    //}
}
