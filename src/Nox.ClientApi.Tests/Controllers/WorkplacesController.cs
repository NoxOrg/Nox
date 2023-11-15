
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Presentation.Api.OData;
public partial class WorkplacesController
{
    public override Task<ActionResult<IQueryable<WorkplaceLocalizedDto>>> GetWorkplaceLocalized(uint key)
    {
        return base.GetWorkplaceLocalized(key);
    }
}