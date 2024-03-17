// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetTenantBrandTranslationsByParentIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TenantBrandLocalizedDto>>;

internal partial class GetTenantBrandTranslationsByParentIdQueryHandler:GetTenantBrandTranslationsByParentIdQueryHandlerBase
{
    public  GetTenantBrandTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantBrandTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<TenantBrandLocalizedDto>>, IRequestHandler<GetTenantBrandTranslationsByParentIdQuery, IQueryable<TenantBrandLocalizedDto>>
{
    public  GetTenantBrandTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantBrandLocalizedDto>> Handle(GetTenantBrandTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var ownedEntityIds = ReadOnlyRepository.Query<TenantDto>()
                    .Include(e => e.TenantBrands)
                    .Where(r =>
                            r.Id.Equals(request.keyId)
                    ).SelectMany(e => e.TenantBrands.Select(c => c.Id));
        
        var query = ReadOnlyRepository.Query<TenantBrandLocalizedDto>()
           .Where(r =>
                ownedEntityIds.Contains(r.Id)
           );
        
        return Task.FromResult(OnResponse(query));
    }
}