// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoresStatusesQuery(CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.StoreStatusDto>>;

internal partial class GetStoresStatusesQueryHandler: GetStoresStatusesQueryHandlerBase
{
    public GetStoresStatusesQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetStoresStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.StoreStatusDto>>, IRequestHandler<GetStoresStatusesQuery, IQueryable<DtoNameSpace.StoreStatusDto>>
{
    public  GetStoresStatusesQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.StoreStatusDto>> Handle(GetStoresStatusesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = (IQueryable<DtoNameSpace.StoreStatusDto>)DataDbContext.StoresStatuses
            .AsNoTracking();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}