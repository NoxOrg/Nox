// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetTenantsStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TenantStatusDto>>;

internal partial class GetTenantsStatusesQueryHandler: GetTenantsStatusesQueryHandlerBase
{
    public GetTenantsStatusesQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetTenantsStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantStatusDto>>, IRequestHandler<GetTenantsStatusesQuery, IQueryable<DtoNameSpace.TenantStatusDto>>
{
    public  GetTenantsStatusesQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantStatusDto>> Handle(GetTenantsStatusesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = (IQueryable<DtoNameSpace.TenantStatusDto>)DataDbContext.TenantsStatuses
            .AsNoTracking();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}