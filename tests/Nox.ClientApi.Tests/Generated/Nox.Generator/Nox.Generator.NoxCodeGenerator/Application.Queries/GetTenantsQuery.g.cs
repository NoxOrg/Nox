// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetTenantsQuery() : IRequest<IQueryable<TenantDto>>;

internal partial class GetTenantsQueryHandler: GetTenantsQueryHandlerBase
{
    public GetTenantsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantsQueryHandlerBase : QueryBase<IQueryable<TenantDto>>, IRequestHandler<GetTenantsQuery, IQueryable<TenantDto>>
{
    public  GetTenantsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantDto>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TenantDto>()
            .Include(e => e.TenantBrands)
            .Include(e => e.TenantContact);
       return Task.FromResult(OnResponse(query));
    }
}