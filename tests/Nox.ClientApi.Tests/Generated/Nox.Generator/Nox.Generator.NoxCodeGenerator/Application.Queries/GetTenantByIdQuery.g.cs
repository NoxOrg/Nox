// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetTenantByIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TenantDto>>;

internal partial class GetTenantByIdQueryHandler:GetTenantByIdQueryHandlerBase
{
    public GetTenantByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantByIdQueryHandlerBase:  QueryBase<IQueryable<TenantDto>>, IRequestHandler<GetTenantByIdQuery, IQueryable<TenantDto>>
{
    public  GetTenantByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantDto>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TenantDto>()
            .Include(e => e.TenantBrands)
            .Include(e => e.TenantContact)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}