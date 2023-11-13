// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetTenantsQuery() : IRequest<IQueryable<TenantDto>>;

internal partial class GetTenantsQueryHandler: GetTenantsQueryHandlerBase
{
    public GetTenantsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantsQueryHandlerBase : QueryBase<IQueryable<TenantDto>>, IRequestHandler<GetTenantsQuery, IQueryable<TenantDto>>
{
    public  GetTenantsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantDto>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TenantDto>)DataDbContext.Tenants
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}