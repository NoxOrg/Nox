// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetTenantByIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TenantDto>>;

internal partial class GetTenantByIdQueryHandler:GetTenantByIdQueryHandlerBase
{
    public  GetTenantByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantByIdQueryHandlerBase:  QueryBase<IQueryable<TenantDto>>, IRequestHandler<GetTenantByIdQuery, IQueryable<TenantDto>>
{
    public  GetTenantByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantDto>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Tenants
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}