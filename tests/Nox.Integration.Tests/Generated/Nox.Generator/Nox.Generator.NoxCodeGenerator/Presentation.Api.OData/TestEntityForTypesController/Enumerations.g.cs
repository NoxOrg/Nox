// Generated

#nullable enable
using Microsoft.AspNetCore.Mvc;

using DtoNameSpace = TestWebApp.Application.Dto;
using ApplicationQueriesNameSpace = TestWebApp.Application.Queries;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityForTypesControllerBase
{
    [HttpGet("api/TestEntityForTypes/TestEntityForTypesEnumerationTestFields")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>> GetEnumerationTestFieldsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTestEntityForTypesEnumerationTestFieldsQuery());                        
        return Ok(result);        
    }
}
