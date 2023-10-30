// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;
using Nox.Presentation.Api;
using Nox.Solution;

namespace ClientApi.Application.Queries;

public class GetWorkplacesQuery : IRequest<IQueryable<WorkplaceDto>>
{
    public string CultureCode { get; set; }

    public GetWorkplacesQuery(string cultureCode)
    {
        CultureCode = cultureCode;
    }
};

internal partial class GetWorkplacesQueryHandler: GetWorkplacesQueryHandlerBase
{
    public GetWorkplacesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {

    }
}

internal abstract class GetWorkplacesQueryHandlerBase : QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplacesQuery, IQueryable<WorkplaceDto>>
{
    public  GetWorkplacesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplacesQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = request.CultureCode;

        IQueryable<WorkplaceDto> linqQueryBuilder =
            from item in DataDbContext.Workplaces.AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.WorkplacesLocalized on cultureCode equals itemLocalizedFromJoin.CultureCode into joinedData
            from itemLocalized in joinedData.Where(l => item.Id == l.Id).DefaultIfEmpty()
            select new WorkplaceDto()
            {
        Id = item.Id,
        Name = item.Name,
        Description = itemLocalized.Description ?? "[" + item.Description + "]",
        Greeting = item.Greeting,
        BelongsToCountryId = item.BelongsToCountryId,
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"WHERE @__{nameof(cultureCode)}_0", $"WHERE '{cultureCode}'");

        IQueryable<WorkplaceDto> getItemsQuery =
            from item in DataDbContext.Workplaces.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}