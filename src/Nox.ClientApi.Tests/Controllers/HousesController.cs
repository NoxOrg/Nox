
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ClientApi.Tests.Application.Dto;

namespace ClientApi.Controllers;

/// <summary>
/// Example a a Odata Controller, prefer extending Nox generated controllers, and add the Entity House to the Nox. Solutin
/// </summary>
public class HousesController : ODataController
{

    [EnableQuery]
    public ActionResult<IQueryable<HouseDto>> Get()
    {
        return Ok(new List<HouseDto>()
        {
            new HouseDto(1,"Working"),
            new HouseDto(2,"Vacation"),
        }) ;
    }

    /// <summary>
    /// Example of a non OData end point. Prefer using Odata EndPoints     
    /// <returns></returns>
    [HttpGet("api/[controller]/[action]")]
    public ActionResult<IQueryable<Application.Dto.CountryDto>> HousesToRent()
    {
        return Ok(new List<HouseDto>()
        {
            new HouseDto(1,"Working"),
            new HouseDto(2,"Vacation"),
        });
    }
}

