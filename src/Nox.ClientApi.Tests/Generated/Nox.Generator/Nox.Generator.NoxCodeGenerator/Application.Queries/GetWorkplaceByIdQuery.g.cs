// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;
using Nox.Presentation.Api;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Queries;

public partial record GetWorkplaceByIdQuery(CultureCode cultureCode, System.Int64 keyId) : IRequest <IQueryable<WorkplaceDto>>;

internal partial class GetWorkplaceByIdQueryHandler : GetWorkplaceByIdQueryHandlerBase
{
    public GetWorkplaceByIdQueryHandler(DtoDbContext dataDbContext) : base(dataDbContext)
    {

    }
}

internal abstract class GetWorkplaceByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplaceByIdQuery, IQueryable<WorkplaceDto>>
{
    protected GetWorkplaceByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplaceByIdQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = request.cultureCode.Value;

        IQueryable<WorkplaceDto> linqQueryBuilder =
            from item in DataDbContext.Workplaces.Where(r =>
                r.Id.Equals(request.keyId)).AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.WorkplacesLocalized on cultureCode equals itemLocalizedFromJoin.CultureCode into joinedData
            from itemLocalized in joinedData.Where(l => item.Id == l.Id).DefaultIfEmpty()
            select new WorkplaceDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = itemLocalized.Description ?? "[" + item.Description + "]",
                Greeting = item.Greeting,
                CountryId = item.CountryId,
                Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString();

        IQueryable<WorkplaceDto> getItemsQuery =
            from item in DataDbContext.Workplaces.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}